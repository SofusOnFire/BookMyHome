using Application.DTO;
using Application.RepositoryInterfaces;
using Common;
using Domain.ModelDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccommodationService
    {
        private IUnitOfWork _unit;

        public AccommodationService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IResult<Accommodation>> UpdateAccommodationAsync(AccommodationUpdateDto accommodationUpdateDto)
        {
            _unit.BeginTransaction();

            Accommodation accommodation = await _unit.AccommodationRepository.GetAccommodationByIdAsync(accommodationUpdateDto.Id);

            AccommodationUpdateModelDto accommodationUpdateModelDto = new AccommodationUpdateModelDto()
            {
                UserId = accommodationUpdateDto.UserId,
                Price = accommodationUpdateDto.Price,
                HouseRules = accommodationUpdateDto.HouseRules,
                Photo = accommodationUpdateDto.Photo,
                Availability = accommodationUpdateDto.Availability,
                RowVersion = accommodationUpdateDto.RowVersion
            };

            accommodation.UpdateAccommodationModel(accommodationUpdateModelDto);

            IResult<Accommodation> result = await _unit.AccommodationRepository.UpdateAccommodationAsync(accommodation);

            if (result.IsSucces() == true)
            {
                _unit.Commit();
            }
            else 
            {
                _unit.Rollback();
            }

            return result;
        }
    }
}

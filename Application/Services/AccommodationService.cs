using Application.DTO;
using Application.RepositoryInterfaces;
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
        private IUnitOfWork _uow;

        public AccommodationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> UpdateAccommodationAsync(AccommodationUpdateDto accommodationUpdateDto)
        {
            _uow.BeginTransaction();

            try
            {
                Accommodation accommodation = await _uow.AccommodationRepository.GetAccommodationByIdAsync(accommodationUpdateDto.Id);

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

                await _uow.AccommodationRepository.UpdateAccommodationAsync(accommodation);

                _uow.Commit();

                return true;
            }
            catch (Exception)
            {
                _uow.Rollback();

                return false;
            }
        }
    }
}

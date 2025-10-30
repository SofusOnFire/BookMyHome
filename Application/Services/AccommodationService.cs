using Application.DTO;
using Application.RepositoryInterfaces;
using Common;
using Common.ResultWrapper;
using Common.ResultWrapper.ResultSubclasses;
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

        public async Task<Result<Accommodation>> UpdateAccommodationAsync(AccommodationUpdateDto accommodationUpdateDto)
        {
            _unit.BeginTransaction();

            Result<Accommodation> accommodation = await _unit.AccommodationRepository.GetAccommodationByIdAsync(accommodationUpdateDto.Id);
            if(accommodation is not SuccessResult<Accommodation>)
            {
                _unit.Rollback();
                return accommodation;
            }

            AccommodationUpdateModelDto accommodationUpdateModelDto = new AccommodationUpdateModelDto()
            {
                UserId = accommodationUpdateDto.UserId,
                Price = accommodationUpdateDto.Price,
                HouseRules = accommodationUpdateDto.HouseRules,
                Photo = accommodationUpdateDto.Photo,
                Availability = accommodationUpdateDto.Availability,
                RowVersion = accommodationUpdateDto.RowVersion
            };

            accommodation.OrignalValue!.UpdateAccommodationModel(accommodationUpdateModelDto);

            Result<Accommodation> result = await _unit.AccommodationRepository.UpdateAccommodationAsync(accommodation.OrignalValue!);
            if(result is SuccessResult<Accommodation>)
            {
                _unit.Commit();
                return result;
            }
            else
            {
                _unit.Rollback();
                return result;
            }
        }
    }
}

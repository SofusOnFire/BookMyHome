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
            try
            {
				Result<Accommodation> accommodation = await _unit.AccommodationRepository.GetAccommodationByIdAsync(accommodationUpdateDto.Id);
				if (!accommodation.IsSuccess)
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
				if (result.IsSuccess)
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
            catch (Exception ex)
            {
				_unit.Rollback();
				return Result<Accommodation>.Failure(null, ex);
            }

        }
    }
}

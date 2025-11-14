using Application.DTO;
using Application.RepositoryInterfaces;
using Domain.Models;
using Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;

namespace Application.Services
{
    public class AccomodationService
    {
        private IUnitOfWork _unitOfWork;

        public AccomodationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> UpdateAccomodationAsync(AccomodationUpdateDTO accomodationUpdateDTO)
        {
            _unitOfWork.BeginTransaction();

            try
            {
                Accomodation accomodation = await _unitOfWork._accomodationRepository.GetAccomodationByIdAsync(accomodationUpdateDTO.Id);
                AccomodationUpdateModelDTO accomodationUpdateModelDTO = new AccomodationUpdateModelDTO()
                {
                    UserId = accomodationUpdateDTO.UserId,
                    Price = accomodationUpdateDTO.Price,
                    HouseRules = accomodationUpdateDTO.HouseRules,
                    Photo = accomodationUpdateDTO.Photo,
                    Availability = accomodationUpdateDTO.Availability,
                    RowVersion = accomodationUpdateDTO.RowVersion
                };

                accomodation.UpdateAccomodation(accomodationUpdateModelDTO);

                await _unitOfWork._accomodationRepository.UpdateAccomodationAsync(accomodation);

                _unitOfWork.Commit();

                return true;
            }
            catch(Exception)
            {
                _unitOfWork.Rollback();

                return false;
            }
        }
    }
}

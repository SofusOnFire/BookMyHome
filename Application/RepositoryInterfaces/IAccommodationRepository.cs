using Application.DTO;
using Common;
using Common.ResultWrapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IAccommodationRepository
    {
        // READ
        public Task<Result<Accommodation>> GetAccommodationByIdAsync(int id);
        public Task<IEnumerable<Accommodation>> GetAllAsync();

        // UPDATE
        public Task<Result<Accommodation>> UpdateAccommodationAsync(Accommodation accommodation);
    }
}

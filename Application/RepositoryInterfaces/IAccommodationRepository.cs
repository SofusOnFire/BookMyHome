using Application.DTO;
using Common;
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
        public Task<Accommodation> GetAccommodationByIdAsync(int id);
        public Task<IEnumerable<Accommodation>> GetAllAsync();

        // UPDATE
        public Task<IResult<Accommodation>> UpdateAccommodationAsync(Accommodation accommodation);
    }
}

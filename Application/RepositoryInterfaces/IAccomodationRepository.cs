using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IAccomodationRepository
    {
        public Task<Accomodation> GetAccomodationByIdAsync(int id);
        public Task<IEnumerable<Accomodation>> GetAllAsync();
        public Task<bool> UpdateAccomodationAsync(Accomodation accomodation);
    }
}

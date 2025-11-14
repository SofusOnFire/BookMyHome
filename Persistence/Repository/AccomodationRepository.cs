using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Domain.Models;
using Application.DTO;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class AccomodationRepository : IAccomodationRepository
    {
        private SQLServerDbContext _context;

        public AccomodationRepository(SQLServerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateAccomodationAsync(Accomodation accomodation)
        {
            try
            {
                _context.Update(accomodation);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Accomodation>> GetAllAsync()
        {
            IEnumerable<Accomodation> allAccomodations = await _context.Accomodations.ToListAsync();

            return allAccomodations;
        }

        public async Task<Accomodation> GetAccomodationByIdAsync(int id)
        {
            Accomodation? accomodation;

            try
            {
                accomodation = await _context.Accomodations.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not find accomodation.");
            }

            return accomodation;
        }
    }
}

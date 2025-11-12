using Application.DTO;
using Application.RepositoryInterfaces;
using Common;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private MSSQLServerDbContext _context;

        public AccommodationRepository(MSSQLServerDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<Accommodation> GetAccommodationByIdAsync(int id)
        {
            Accommodation? accommodation;

            try
            {
                accommodation = await _context.Accomodations
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                throw new Exception("Kunne ikke finde");
            }

            return accommodation;
        }

        // READ

        // UPDATE
        public async Task<IResult<Accommodation>> UpdateAccommodationAsync(Accommodation accommodation)
        {
            try
            {
                _context.Update(accommodation);

                await _context.SaveChangesAsync();

                return Result<Accommodation>.Success(accommodation);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Accommodation currentValue = await _context.Accomodations.FirstAsync(x => x.Id == accommodation.Id);

                return Result<Accommodation>.Conflict(accommodation, currentValue, ex);
            }
        }

        // DELETE

        // LIST
        public async Task<IEnumerable<Accommodation>> GetAllAsync()
        {
            IEnumerable<Accommodation> accommodations = await _context.Accomodations
                .ToListAsync();

            return accommodations;
        }
    }
}

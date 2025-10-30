using Application.DTO;
using Application.RepositoryInterfaces;
using Common;
using Common.ResultWrapper;
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
        public async Task<Result<Accommodation>> GetAccommodationByIdAsync(int id)
        {
            Accommodation? accommodation;

            try
            {
                accommodation = await _context.Accomodations
                    .FirstAsync(x => x.Id == id);

                return Result<Accommodation>.Success(accommodation);
            }
            catch (Exception ex)
            {
                return Result<Accommodation>.Failure(null, ex);
            }

        }

        // READ

        // UPDATE
        public async Task<Result<Accommodation>> UpdateAccommodationAsync(Accommodation accommodation)
        {
            try
            {
                _context.Update(accommodation);

                await _context.SaveChangesAsync();

                return Result<Accommodation>.Success(accommodation);
            }
            catch (DbUpdateConcurrencyException)
            {
                Accommodation currentValue = await _context.Accomodations.FirstAsync(x => x.Id == accommodation.Id);
                return Result<Accommodation>.Conflict(accommodation,currentValue);
            }
            catch (Exception ex)
            {
                return Result<Accommodation>.Failure(accommodation, ex);
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

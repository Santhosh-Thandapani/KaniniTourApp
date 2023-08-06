using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TourPackageAPI.Interfaces;
using TourPackageAPI.Models;
using TourPackageAPI.Models.Context;

namespace TourPackageAPI.Repositorys
{
    public class ItineraryRepo : IITineraryRepo<Itinerary>
    {
        private TourContext _context;

        public ItineraryRepo(TourContext context)
        {
            _context=context;
        }
        public async Task<Itinerary> Add(Itinerary item)
        {
            if (item != null)
            {
                _context.Itineraries.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<bool> DeleteByPackage(int id)
        {
            var itineraiesToRemove =_context.Itineraries.Where(s => s.PackageId == id);

            if (itineraiesToRemove.Any())
            {
                _context.Itineraries.RemoveRange(itineraiesToRemove);
                await _context.SaveChangesAsync();
            }
            if (itineraiesToRemove != null)
                return true;
            return false;
        }

        public async Task<ICollection<Itinerary>> GetAllByPackage(int id)
        {
            var itineraries = await _context.Itineraries.Where(s => s.PackageId == id).ToListAsync();
            if (itineraries.Count >=1)
                return itineraries;
            return null;
        }
    }
}

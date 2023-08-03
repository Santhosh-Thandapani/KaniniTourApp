using Microsoft.EntityFrameworkCore;
using TourPackageAPI.Interfaces;
using TourPackageAPI.Models;
using TourPackageAPI.Models.Context;

namespace TourPackageAPI.Repositorys
{
    public class ActivityRepo : IActivityRepo<Activity>
    {
        private readonly TourContext _context;

        public ActivityRepo(TourContext context)
        {
            _context = context;
        }

        public async Task<Activity> Add(Activity item)
        {
            if (item != null)
            {
                _context.Activities.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<bool> DeleteByPackage(int id)
        {
            var activitiesToRemove = _context.Activities.Where(s => s.PackageId == id);

            if (activitiesToRemove.Any())
            {
                _context.Activities.RemoveRange(activitiesToRemove);
                await _context.SaveChangesAsync();
            }
            if (activitiesToRemove != null)
                return true;
            return false;
        }

        public async Task<ICollection<Activity>> Get(int pId, int iId)
        {
            var activities = await _context.Activities.Where(s => s.PackageId == pId && s.ItineraryId == iId).ToListAsync();
            if (activities != null)
                return activities;
            return null;
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TourPackageAPI.Interfaces;
using TourPackageAPI.Models;
using TourPackageAPI.Models.Context;

namespace TourPackageAPI.Repositorys
{
    public class AccomadationRepo:IAccoRepo<Accomdation>
    {
        private readonly TourContext _context;

        public AccomadationRepo(TourContext context) 
        {
            _context = context;
        }

        public async Task<Accomdation> Add(Accomdation item)
        {
            if (item != null)
            {
                _context.Accomdations.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<bool> DeleteByPackage(int id)
        {
            var accomdationsToRemove = _context.Accomdations.Where(s => s.PackageId == id);

            if (accomdationsToRemove.Any())
            {
                _context.Accomdations.RemoveRange(accomdationsToRemove);
                await _context.SaveChangesAsync();
            }
            if (accomdationsToRemove != null)
                return true;
            return false;
        }

        public async Task<Accomdation> Get(int pId , int iId)
        {
            var accomdations = await _context.Accomdations.FirstOrDefaultAsync(s => s.PackageId == pId && s.ItineraryId == iId);
            if (accomdations!=null)
                return accomdations;
            return null;
        }
    }
}

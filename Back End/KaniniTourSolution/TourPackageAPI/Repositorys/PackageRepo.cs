using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using TourPackageAPI.Interfaces;
using TourPackageAPI.Models;
using TourPackageAPI.Models.Context;
using TourPackageAPI.Models.DTOs;

namespace TourPackageAPI.Repositorys
{
    public class PackageRepo : IRepo<Package,int>
    {
        private readonly TourContext _context;

        public PackageRepo(TourContext context)
        {
            _context = context;
        }

        public async Task<Package> Add(Package item)
        {
            if(item != null) 
            {
                _context.Packages.Add(item);
                 await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<Package> Delete(int key)
        {
            var package = await Get(key);
            if(package != null)
            {
                _context.Packages.Remove(package);
                await _context.SaveChangesAsync();
                return package;
            }
            return null;
        }

        public async Task<Package> Get(int key)
        {
            var result = await _context.Packages.FirstOrDefaultAsync(s => s.Id == key);
            if(result !=null)
                return result;
            return null;
        }

        public async Task<ICollection<Package>> GetAll()
        {
            var packages = await _context.Packages.ToListAsync(); 
            if(packages != null)
                return packages;
            return null;
        }

        public async Task<Package> Update(Package item)
        {
            var package =await _context.Packages.FirstOrDefaultAsync(s=>s.Id==item.Id);
            package.MaxLimit=item.MaxLimit;
            await _context.SaveChangesAsync();
            return package; ;
        }
    }
}

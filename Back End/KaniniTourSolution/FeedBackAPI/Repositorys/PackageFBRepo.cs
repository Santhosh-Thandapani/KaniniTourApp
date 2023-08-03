using FeedBackAPI.Interfaces;
using FeedBackAPI.Models;
using FeedBackAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace FeedBackAPI.Repositorys
{
    public class PackageFBRepo : IRepo<PackageFeedback, int>
    {
        private readonly FeedbackContext _context;

        public PackageFBRepo(FeedbackContext context)
        {
            _context=context;
        }
        public async Task<PackageFeedback> Add(PackageFeedback item)
        {
            if (item != null)
            {
                _context.PackageFeedbacks.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<ICollection<PackageFeedback>> GetAll(int key)
        {
            var feedbacks = await _context.PackageFeedbacks.Where(s => s.PackageId == key).ToListAsync();
            if (feedbacks.Count > 0)
                return feedbacks;
            return null;
        }

        public async Task<ICollection<PackageFeedback>> GetAllByUser(int key)
        {
            var feedbacks = await _context.PackageFeedbacks.Where(s => s.UserId == key).ToListAsync();
            if (feedbacks.Count > 0)
                return feedbacks;
            return null;
        }
    }
}

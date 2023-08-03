using FeedBackAPI.Interfaces;
using FeedBackAPI.Models;
using FeedBackAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace FeedBackAPI.Repositorys
{
    public class HotelFBRepo : IRepo<HotelFeedback, int>
    {
        private readonly FeedbackContext _context;

        public HotelFBRepo(FeedbackContext context)
        {
            _context = context;
        }
        public async Task<HotelFeedback> Add(HotelFeedback item)
        {
            if(item != null) 
            {
                _context.HotelFeedbacks.Add(item);
                await _context.SaveChangesAsync();  
                return item;
            }
            return null;
        }

        public async Task<ICollection<HotelFeedback>> GetAll(int key)
        {
           var feedbacks= await _context.HotelFeedbacks.Where(s=>s.HotelId==key).ToListAsync();
            if (feedbacks.Count > 0)
                return feedbacks;
            return null;
        }

        public async Task<ICollection<HotelFeedback>> GetAllByUser(int key)
        {
            var feedbacks = await _context.HotelFeedbacks.Where(s => s.UserId == key).ToListAsync();
            if (feedbacks.Count > 0)
                return feedbacks;
            return null;
        }
    }
}

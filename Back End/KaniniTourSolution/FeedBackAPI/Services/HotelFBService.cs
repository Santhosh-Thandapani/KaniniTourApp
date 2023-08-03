using FeedBackAPI.Interfaces;
using FeedBackAPI.Models;
using FeedBackAPI.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace FeedBackAPI.Services
{
    public class HotelFBService :IService<HotelFeedback,int,HotelDTO>
    {
        private readonly IRepo<HotelFeedback, int> _hotel;
        public HotelFBService(IRepo<HotelFeedback,int> hotel)
        {
            _hotel=hotel;
        }

        public async Task<HotelFeedback> AddFeedback(HotelFeedback feedback)
        {
           feedback.CreatedAt= DateTime.Now;
           var result = await _hotel.Add(feedback);
           if(result != null) 
                return result;
            return null;
        }

        public async Task<ICollection<HotelFeedback>> GetAll(int key)
        {
            var feedbacks = await _hotel.GetAll(key);
            if(feedbacks != null)
                return feedbacks;
            return null;
        }

        public async Task<ICollection<HotelFeedback>> GetAllByUser(int key)
        {
            var feedbacks = await _hotel.GetAllByUser(key);
            if (feedbacks != null)
                return feedbacks;
            return null;
        }

        public async Task<HotelDTO> OverAllFeedback(int key)
        {
            var feedbacks = await _hotel.GetAll(key);
            if (feedbacks.Count > 0)
            {
                HotelDTO hotelDTO = new HotelDTO();
                foreach (var feedback in feedbacks)
                {
                    hotelDTO.Cleanliness += feedback.Cleanliness;
                    hotelDTO.ServiceSupport += feedback.ServiceSupport;
                    hotelDTO.Food+= feedback.Food;
                    hotelDTO.Amenities += feedback.Amenities;
                    hotelDTO.ValueForMoney += feedback.ValueForMoney;
                }
                hotelDTO.Cleanliness /= feedbacks.Count;
                hotelDTO.ServiceSupport /= feedbacks.Count;
                hotelDTO.Food /= feedbacks.Count;
                hotelDTO.Amenities /= feedbacks.Count;
                hotelDTO.ValueForMoney /= feedbacks.Count;

                return hotelDTO;
            }
            return null;
        }
    }
}

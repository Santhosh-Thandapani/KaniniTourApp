using FeedBackAPI.Interfaces;
using FeedBackAPI.Models;
using FeedBackAPI.Models.DTO;

namespace FeedBackAPI.Services
{
    public class PackageFBService :IService<PackageFeedback,int , PackageDTO>
    {
        private readonly IRepo<PackageFeedback, int> _package;

        public PackageFBService(IRepo<PackageFeedback, int> package)
        {
            _package = package;
        }

        public async Task<PackageFeedback> AddFeedback(PackageFeedback feedback)
        {
            feedback.CreatedAt = DateTime.Now;
            var result = await _package.Add(feedback);
            if (result != null)
                return result;
            return null;
        }

        public async Task<ICollection<PackageFeedback>> GetAll(int key)
        {
            var feedbacks = await _package.GetAll(key);
            if (feedbacks != null)
                return feedbacks;
            return null;
        }

        public async Task<ICollection<PackageFeedback>> GetAllByUser(int key)
        {
            var feedbacks = await _package.GetAllByUser(key);
            if (feedbacks != null)
                return feedbacks;
            return null;
        }

        public async Task<PackageDTO> OverAllFeedback(int key)
        {
            var feedbacks = await _package.GetAll(key);
            if (feedbacks.Count > 0)
            {
                PackageDTO item = new PackageDTO();
                foreach (var feedback in feedbacks)
                {
                    item.Accommodation += feedback.Accommodation;
                    item.LocationExperience += feedback.LocalExperience;
                    item.OverallExperience += feedback.OverallExperience;
                    item.Communication += feedback.Communication;
                    item.ValueForMoney += feedback.ValueForMoney;
                }
                item.Accommodation /= feedbacks.Count;
                item.LocationExperience /= feedbacks.Count;
                item.LocationExperience /= feedbacks.Count;
                item.Communication /= feedbacks.Count;
                item.ValueForMoney /= feedbacks.Count;

                return item;
            }
            return null;
        }
    }
}

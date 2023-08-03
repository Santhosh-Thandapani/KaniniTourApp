namespace FeedBackAPI.Interfaces
{
    public interface IService<T,K,S>
    {
        public Task<T> AddFeedback(T feedback);
        public Task<ICollection<T>> GetAll(K key);
        public Task<ICollection<T>> GetAllByUser(K key);
        public Task<S> OverAllFeedback(K key);
    }
}

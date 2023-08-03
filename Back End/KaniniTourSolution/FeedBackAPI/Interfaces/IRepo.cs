namespace FeedBackAPI.Interfaces
{
    public interface IRepo<T,K>
    {
        public Task<T> Add (T item);
        public Task<ICollection<T>> GetAll(K key);
        public Task<ICollection<T>> GetAllByUser(K key);
    }
}

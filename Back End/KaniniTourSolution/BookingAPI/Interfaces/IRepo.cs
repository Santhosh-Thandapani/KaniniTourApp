namespace BookingAPI.Interfaces
{
    public interface IRepo<T,K>
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(T key);
        public Task<T> Get(K key);
        public Task<ICollection<T>> GetAll();
    }
}

namespace HotelAPI.Interfaces
{
    public interface IRoomService<T,K,S>
    {
        public Task<T> AddRoom(T item);
        public Task<K> UpdateRoom(K item);
        public Task<T> RemoveRoom(S id);
    }
}

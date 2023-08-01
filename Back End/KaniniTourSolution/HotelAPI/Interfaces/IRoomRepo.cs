namespace HotelAPI.Interfaces
{
    public interface IRoomRepo<T,K>:IRepo<T,K>
    {
        public Task<ICollection<T>> GetRoomsByHotel(K key);
    }
}

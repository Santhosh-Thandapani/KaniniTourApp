namespace HotelAPI.Interfaces
{
    public interface IAmenityRepo<T>
    {
        public Task<T> Add(T item);
        public Task<T> Delete(T item);
        public Task<bool> DeleteByHotel(int id);
        public Task<ICollection<T>> GetAll( int id); 

    }
}

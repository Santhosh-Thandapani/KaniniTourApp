namespace HotelAPI.Interfaces
{
    public interface IAmenityRepo<T>
    {
        public Task<T> Add(T item);
        public Task<T> Delete(T item);
    }
}

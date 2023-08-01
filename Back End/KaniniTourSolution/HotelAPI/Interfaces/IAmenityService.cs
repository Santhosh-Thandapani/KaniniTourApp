namespace HotelAPI.Interfaces
{
    public interface IAmenityService<T>
    {
        public Task<T> AddAmenity(T item);
        public Task<T> RemoveAmenity(T item);
    }
}

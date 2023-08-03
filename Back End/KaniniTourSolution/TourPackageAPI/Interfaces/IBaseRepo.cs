namespace TourPackageAPI.Interfaces
{
    public interface IBaseRepo<T>
    {
        public Task<T> Add(T item);
    }
}

namespace TourPackageAPI.Interfaces
{
    public interface IITineraryRepo<T>:IBaseRepo<T>
    {
        public Task<ICollection<T>> GetAllByPackage(int id);
        public Task<bool> DeleteByPackage(int id);
    }
}

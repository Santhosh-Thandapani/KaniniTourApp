namespace TourPackageAPI.Interfaces
{
    public interface IActivityRepo<T>:IBaseRepo<T>
    {
        public Task<ICollection<T>> Get(int pId, int iId);
        public Task<bool> DeleteByPackage(int id);
    }
}

namespace TourPackageAPI.Interfaces
{
    public interface IAccoRepo<T>: IBaseRepo<T>
    {
        public Task<T> Get(int pId , int iId);
        public Task<bool> DeleteByPackage(int id);
    }
}

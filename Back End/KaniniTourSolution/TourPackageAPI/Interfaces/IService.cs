namespace TourPackageAPI.Interfaces
{
    public interface IService<T,K,S>:IBaseRepo<T>
    {
        public Task<S> DeletePackage(K key);
        public Task<T> GetPackage(K key);
        public Task<S> UpdatePackage(S item);
        public Task<ICollection<T>> GetAllPackages();
    }
}

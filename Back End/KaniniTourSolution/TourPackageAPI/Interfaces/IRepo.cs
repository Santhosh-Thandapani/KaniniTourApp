namespace TourPackageAPI.Interfaces
{
    public interface IRepo<T,K>:IBaseRepo<T>
    {
        public Task<T> Delete(K key);
        public Task<T> Get(K key);
        public Task<T> Update(T item);
        public Task<ICollection<T>> GetAll();
    }
}

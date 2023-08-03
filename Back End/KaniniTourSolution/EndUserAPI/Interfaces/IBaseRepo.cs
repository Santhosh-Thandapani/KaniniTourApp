namespace EndUserAPI.Interfaces
{
    public interface IBaseRepo<T>
    {
        public Task<T> Add(T item);
        public Task<ICollection<T>> GetAll();
        public Task<T> Delete(int id);
        public Task<T> GetById(int id);
    }
}

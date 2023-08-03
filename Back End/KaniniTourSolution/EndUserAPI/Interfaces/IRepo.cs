namespace EndUserAPI.Interfaces
{
    public interface IRepo<T>:IBaseRepo<T>
    {
        public Task<T> GetByPhoneNo(string pNo);
        public Task<T> Update(T item);
    }
}

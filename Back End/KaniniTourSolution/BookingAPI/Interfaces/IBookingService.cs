using BookingAPI.Models.DTOs;

namespace BookingAPI.Interfaces
{
    public interface IBookingService<T,K,S>
    {
        public Task<T> AddBooking(T booking);
        public Task<S> RemoveBooking(K key);
        public Task<ICollection<T>> GetAllBooking();
        public Task<ICollection<T>> GetBookingsByUser(K key);
        public Task<InputDTO> CheckAvailable(CheckDTO item);
    }
}

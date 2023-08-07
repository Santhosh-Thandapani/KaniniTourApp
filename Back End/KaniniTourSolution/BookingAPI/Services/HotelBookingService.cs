using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.DTOs;

namespace BookingAPI.Services
{
    public class HotelBookingService : IBookingService<HotelBookDTO, int, CancelDTO>
    {
        private readonly IRepo<HotelBook, int> _hotelBookRepo;
        private readonly IRepo<HotelGuest, int> _hotelGuestRepo;

        public HotelBookingService( IRepo<HotelBook,int> hotelBookRepo,
                                    IRepo<HotelGuest,int> hotelGuestRepo)
        {
            _hotelBookRepo = hotelBookRepo;
            _hotelGuestRepo=hotelGuestRepo;
        }
        public async Task<HotelBookDTO> AddBooking(HotelBookDTO booking)
        {
            var hotelBook = await  _hotelBookRepo.Add(booking);
            foreach(var guest in booking.Guests)
            {
                HotelGuest newGuest = new HotelGuest();
                newGuest.StayId = hotelBook.StayId;
                newGuest.Name=guest.Name;
                newGuest.Age=guest.Age;
                newGuest.Gender=guest.Gender;
                
                var added = await _hotelGuestRepo.Add(newGuest);
            }
            return booking;
        }

        public Task<InputDTO> CheckAvailable(CheckDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<HotelBookDTO>> GetAllBooking()
        {
            List<HotelBookDTO> list = new List<HotelBookDTO>(); 
            var allHotelBooks= await _hotelBookRepo.GetAll();
            foreach(var hotelBook in allHotelBooks)
            {
                HotelBookDTO getBook = new HotelBookDTO();    
                getBook.StayId= hotelBook.StayId;
                getBook.HotelId= hotelBook.HotelId;
                getBook.HotelName=hotelBook.HotelName;
                getBook.RoomId= hotelBook.RoomId;
                getBook.UserId= hotelBook.UserId;
                getBook.Price=hotelBook.Price;
                getBook.UserName=hotelBook.UserName;
                getBook.BookingAt= hotelBook.BookingAt;
                getBook.CheckOut= hotelBook.CheckOut;
                getBook.CheckIn = hotelBook.CheckIn;

                
                var allGuests = await _hotelGuestRepo.GetAll();
                getBook.Guests = allGuests.Where(s => s.StayId == hotelBook.StayId).ToList();
                list.Add(getBook);
            }
            if (list.Count > 0)
                return list;
            return null;
        }

        public async Task<ICollection<HotelBookDTO>> GetBookingsByUser(int key)
        {
            List<HotelBookDTO> list = new List<HotelBookDTO>();
            var allHotelBooks = await _hotelBookRepo.GetAll();
            var userHotelBooks= allHotelBooks.Where(s=>s.UserId==key);
            foreach (var hotelBook in userHotelBooks)
            {
                HotelBookDTO getBook = new HotelBookDTO();
                getBook.StayId = hotelBook.StayId;
                getBook.HotelId = hotelBook.HotelId;
                getBook.HotelName = hotelBook.HotelName;
                getBook.Price = hotelBook.Price;
                getBook.RoomId = hotelBook.RoomId;
                getBook.UserId = hotelBook.UserId;
                getBook.UserName = hotelBook.UserName;
                getBook.BookingAt = hotelBook.BookingAt;
                getBook.CheckOut = hotelBook.CheckOut;
                getBook.CheckIn = hotelBook.CheckIn;


                var allGuests = await _hotelGuestRepo.GetAll();
                getBook.Guests = allGuests.Where(s => s.StayId == hotelBook.StayId).ToList();
                list.Add(getBook);
            }
            if (list.Count > 0)
                return list;
            return null;
        }

        public async Task<CancelDTO> RemoveBooking(int key)
        {
            var allGuests= await _hotelGuestRepo.GetAll();
            var selectedGuests= allGuests.Where(s=>s.StayId==key).ToList();
            foreach(var i in selectedGuests)
            {
                var resullt = await _hotelGuestRepo.Delete(i);
            }
            var getBooking= await _hotelBookRepo.Get(key);
            CancelDTO cancelDTO = new CancelDTO();
            cancelDTO.StayId = key;
            cancelDTO.CancelDate = DateTime.Now;

            DateTime checkInDate = getBooking.CheckIn;
            DateTime cancelDate = DateTime.Now;
            TimeSpan timeDifference = checkInDate - cancelDate;
            int daysInBetween = Math.Abs(timeDifference.Days);
            cancelDTO.DateCount = daysInBetween;
            var delBooking = await _hotelBookRepo.Delete(getBooking);
            return cancelDTO;
        }
    }
}

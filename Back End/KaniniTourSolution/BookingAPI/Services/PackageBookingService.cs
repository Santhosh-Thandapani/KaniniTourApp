using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.DTOs;
using BookingAPI.Repositorys;

namespace BookingAPI.Services
{
    public class PackageBookingService:IBookingService<PackageBookDTO,int,CancelDTO>
    {
        private readonly IRepo<PackageBook, int> _packageBookRepo;
        private readonly IRepo<PackageGuest, int> _packageGuestRepo;

        public PackageBookingService(IRepo<PackageBook,int> packageBookRepo,
                                    IRepo<PackageGuest,int> packageGuestRepo)
        {
            _packageBookRepo=packageBookRepo;
            _packageGuestRepo=packageGuestRepo;
        }

        public async Task<PackageBookDTO> AddBooking(PackageBookDTO booking)
        {
            var packageBook = await _packageBookRepo.Add(booking);
            foreach (var guest in booking.Guests)
            {
                PackageGuest newGuest = new PackageGuest();
                newGuest.BookingId= packageBook.BookingId;
                newGuest.Name = guest.Name;
                newGuest.Age = guest.Age;
                newGuest.Gender = guest.Gender;

                var added = await _packageGuestRepo.Add(newGuest);
            }
            return booking;
        }

        public async Task<ICollection<PackageBookDTO>> GetAllBooking()
        {
            List<PackageBookDTO> list = new List<PackageBookDTO>();
            var allHotelBooks = await _packageBookRepo.GetAll();
            foreach (var hotelBook in allHotelBooks)
            {
                PackageBookDTO getBook = new PackageBookDTO();
                getBook.BookingId = hotelBook.BookingId;
                getBook.PackgeId = hotelBook.PackgeId;
                getBook.UserId = hotelBook.UserId;
                getBook.UserName = hotelBook.UserName;
                getBook.BookingAt = hotelBook.BookingAt;
                getBook.CheckOut = hotelBook.CheckOut;
                getBook.CheckIn = hotelBook.CheckIn;


                var allGuests = await _packageGuestRepo.GetAll();
                getBook.Guests = allGuests.Where(s => s.BookingId == hotelBook.BookingId).ToList();
                list.Add(getBook);
            }
            if (list.Count > 0)
                return list;
            return null;
        }

        public async Task<ICollection<PackageBookDTO>> GetBookingsByUser(int key)
        {
            List<PackageBookDTO> list = new List<PackageBookDTO>();
            var allPackageBooks = await _packageBookRepo.GetAll();
            var userBooks = allPackageBooks.Where(s => s.UserId == key);
            foreach (var hotelBook in userBooks)
            {
                PackageBookDTO getBook = new PackageBookDTO();
                getBook.BookingId = hotelBook.BookingId;
                getBook.PackgeId = hotelBook.PackgeId;
                getBook.UserId = hotelBook.UserId;
                getBook.UserName = hotelBook.UserName;
                getBook.BookingAt = hotelBook.BookingAt;
                getBook.CheckOut = hotelBook.CheckOut;
                getBook.CheckIn = hotelBook.CheckIn;


                var allGuests = await _packageGuestRepo.GetAll();
                getBook.Guests = allGuests.Where(s => s.BookingId == hotelBook.BookingId).ToList();
                list.Add(getBook);
            }
            if (list.Count > 0)
                return list;
            return null;
        }

        public async Task<CancelDTO> RemoveBooking(int key)
        {
            var allGuests = await _packageGuestRepo.GetAll();
            var selectedGuests = allGuests.Where(s => s.BookingId == key).ToList();
            foreach (var i in selectedGuests)
            {
                var resullt = await _packageGuestRepo.Delete(i);
            }
            var getBooking = await _packageBookRepo.Get(key);
            CancelDTO cancelDTO = new CancelDTO();
            cancelDTO.StayId = key;
            cancelDTO.CancelDate = DateTime.Now;

            DateTime checkInDate = getBooking.CheckIn;
            DateTime cancelDate = DateTime.Now;
            TimeSpan timeDifference = checkInDate - cancelDate;
            int daysInBetween = Math.Abs(timeDifference.Days);
            cancelDTO.DateCount = daysInBetween;
            var delBooking = await _packageBookRepo.Delete(getBooking);
            return cancelDTO;
        }
    }
}

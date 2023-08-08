using Microsoft.EntityFrameworkCore.Query.Internal;
using TourPackageAPI.Interfaces;
using TourPackageAPI.Models;
using TourPackageAPI.Models.DTOs;
using TourPackageAPI.Repositorys;

namespace TourPackageAPI.Service
{
    public class PackageService :IService<PackageDTO,int,Package>
    {
        private readonly IRepo<Package, int> _packageRepo;
        private readonly IITineraryRepo<Itinerary> _itineraryRepo;
        private readonly IAccoRepo<Accomdation> _accoRepo;
        private readonly IActivityRepo<Activity> _activityRepo;

        public PackageService(IRepo<Package,int> packageRepo,
                              IITineraryRepo<Itinerary> itineraryRepo,
                              IActivityRepo<Activity> activityRepo,
                              IAccoRepo<Accomdation> accoRepo) 
        {
            _packageRepo = packageRepo;
            _itineraryRepo= itineraryRepo;
            _accoRepo = accoRepo;
            _activityRepo= activityRepo;
        }

        public async Task<PackageDTO> Add(PackageDTO item)
        {
            var package = await _packageRepo.Add(item);
            if(item.Itineraries != null)
            {
                foreach (var itinerary in item.Itineraries)
                {
                    Itinerary newItinerary = new Itinerary();
                    newItinerary.PackageId = package.Id;
                    newItinerary.Transport = itinerary.Transport;
                    newItinerary.TransportFair=itinerary.TransportFair;
                    newItinerary.Food=itinerary.Food;
                    newItinerary.FoodFair=itinerary.FoodFair;
                   

                    var resultItinerary =await _itineraryRepo.Add(newItinerary);

                    foreach (var activity in itinerary.Activities)
                    {
                        Activity newAc = new Activity();
                        newAc.PackageId = package.Id;
                        newAc.ItineraryId= resultItinerary.Id;
                        newAc.ActivityName = activity.ActivityName;
                        newAc.Picture = activity.Picture;
                        newAc.Spot=activity.Spot;
                        newAc.City=activity.City;

                        var resultAc = await _activityRepo.Add(newAc);
                    }

                    Accomdation acco = new Accomdation();
                    acco.PackageId = package.Id;
                    acco.ItineraryId= resultItinerary.Id;
                    acco.HotelId = itinerary.Stay.HotelId;
                    acco.RoomId = itinerary.Stay.RoomId;

                    var resultAcco=await _accoRepo.Add(acco);

                }
                return item;
            }
            return null;
        }

        public async Task<Package> DeletePackage(int key)
        {
            var delAcco = await _accoRepo.DeleteByPackage(key);
            var delActivity = await _activityRepo.DeleteByPackage(key);
            var delItinerary = await _itineraryRepo.DeleteByPackage(key);
            var delPackage = await _packageRepo.Delete(key);
            if (delPackage != null && delAcco == true && delActivity == true && delItinerary == true)
                return delPackage;
            return null;
        }

        public async Task<ICollection<PackageDTO>> GetAllPackages()
        {
            List<PackageDTO> list = new List<PackageDTO>();
            var listPackages = await _packageRepo.GetAll();

            foreach ( var package in listPackages)
            {
                PackageDTO packageDTO = new PackageDTO();
                packageDTO.Id = package.Id;
                packageDTO.PackageName = package.PackageName;
                packageDTO.DaysCount= package.DaysCount;
                packageDTO.NightsCount = package.NightsCount;
                packageDTO.MaxLimit= package.MaxLimit;
                packageDTO.HotelStayStatus= package.HotelStayStatus;
                packageDTO.Picture=package.Picture;
                packageDTO.Price = package.Price;
                packageDTO.City = package.City;
                packageDTO.State = package.State;
                packageDTO.Country= package.Country;
                packageDTO.Editable = package.Editable;

                List<ItineraryDTO> ItineraryList= new List<ItineraryDTO>();
                var listItinerary = await _itineraryRepo.GetAllByPackage(packageDTO.Id);
                foreach(var itinerary in listItinerary)
                {
                    ItineraryDTO temp = new ItineraryDTO();
                    temp.Id = itinerary.Id;
                    temp.PackageId = itinerary.PackageId;
                    temp.Transport= itinerary.Transport;
                    temp.TransportFair= itinerary.TransportFair;
                    temp.Food=itinerary.Food;
                    temp.FoodFair= itinerary.FoodFair;

                    temp.Activities=await _activityRepo.Get(package.Id, itinerary.Id);
                    temp.Stay = await _accoRepo.Get(package.Id, itinerary.Id);
                    ItineraryList.Add(temp);
                }
                packageDTO.Itineraries= ItineraryList;
                list.Add(packageDTO);
            }
            if(list.Count > 0)
                return list;
            return null;
        }

        public async Task<PackageDTO> GetPackage(int key)
        {
            var list=await GetAllPackages();
            var packageDTO = list.FirstOrDefault(p => p.Id == key);
            return packageDTO;
        }

        public async Task<Package> UpdatePackage(Package item)
        {
            var result = await _packageRepo.Update(item);
            if(result != null)
                return result;
            return null;
        }
    }
}

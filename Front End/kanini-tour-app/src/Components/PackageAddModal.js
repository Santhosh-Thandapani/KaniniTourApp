import React, { useState } from "react";

function PackageAddModal({ closeModal }) {

  const [packageData, setPackageData] = useState({
    packageName: "",
    daysCount: 0,
    nightsCount: 0,
    maxLimit: 0,
    picture:"",
    city: "",
    state: "",
    country: "",
    itineraries: [],
  });

  const handleAddActivity = (itineraryIndex) => {
    setPackageData((prevData) => {
      const updatedItineraries = [...prevData.itineraries];
      updatedItineraries[itineraryIndex].activities.push({
        activityName: "",
        picture: "",
        sport: "",
        city: 0,
      });
      return { ...prevData, itineraries: updatedItineraries };
    });
  };

  const handleAddItinerary = () => {
    setPackageData((prevData) => ({
      ...prevData,
      itineraries: [
        ...prevData.itineraries,
        {
          transport: "",
          transportFair: 0,
          food: "",
          foodFair: 0,
          activities: [],
          stay: {
            hotelId: 0,
            roomId: 0,
          },
        },
      ],
    }));
  };

  const handleInputChange = (event, field) => {
    const value = event.target.value;
    setPackageData((prevData) => ({
      ...prevData,
      [field]: value,
    }));
  };

  const handleItineraryInputChange = (itineraryIndex, field, value) => {
    setPackageData((prevData) => {
      const updatedItineraries = [...prevData.itineraries];
      updatedItineraries[itineraryIndex][field] = value;
      return { ...prevData, itineraries: updatedItineraries };
    });
  };

  const handleActivityInputChange = (itineraryIndex, activityIndex, field, value) => {
    setPackageData((prevData) => {
      const updatedItineraries = [...prevData.itineraries];
      updatedItineraries[itineraryIndex].activities[activityIndex][field] = value;
      return { ...prevData, itineraries: updatedItineraries };
    });
  };

  const handleAddPackage = () => {
    const numericPackageData = {
      ...packageData,
      daysCount: Number(packageData.daysCount),
      nightsCount: Number(packageData.nightsCount),
      maxLimit: Number(packageData.maxLimit),
      picture: packageData.picture,
      city: packageData.city,
      state: packageData.state,
      country: packageData.country,
      itineraries: packageData.itineraries.map((itinerary) => ({
        ...itinerary,
        transportFair: Number(itinerary.transportFair),
        foodFair: Number(itinerary.foodFair),
        stay: {
          ...itinerary.stay,
          hotelId: Number(itinerary.stay.hotelId),
          roomId: Number(itinerary.stay.roomId),
        },
        activities: itinerary.activities.map((activity) => ({
          ...activity,
          city: activity.city,
        })),
      })),
    };
    console.log(JSON.stringify(numericPackageData, null, 2));

    console.log("Input data",numericPackageData)
    fetch("https://localhost:7118/api/Package/AddPackage", {
        method: "POST",
        headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
        },
        body: JSON.stringify(numericPackageData)
    })
    .then(async (data)=>{
        if(data.status == 200)
        {
            var myData = await data.json();
            console.log(myData);
        }     
    })
    .catch(error => console.log(error));
    
  };


  return (
    <div className="modalBackground">
      <div className="modalContainer">
        <button onClick={() => closeModal(false)}>X</button>
        <div className="modalTitle">
          <h2>Add Package</h2>
        </div>
        <div className="modelBody">
          <div className="packages">
            <input type="text" placeholder="PackageName" value={packageData.packageName} onChange={(e) => handleInputChange(e, "packageName")} />
            <input type="number" placeholder="Days" value={packageData.daysCount} onChange={(e) => handleInputChange(e, "daysCount")} />
            <input type="number" placeholder="Nights" value={packageData.nightsCount} onChange={(e) => handleInputChange(e, "nightsCount")} />
            <input type="number" placeholder="Max Limit" value={packageData.maxLimit} onChange={(e) => handleInputChange(e, "maxLimit")} />
            <input type="text" placeholder="Picture" value={packageData.picture} onChange={(e) => handleInputChange(e, "picture")} />
            <input type="text" placeholder="City" value={packageData.city} onChange={(e) => handleInputChange(e, "city")} />
            <input type="text" placeholder="State" value={packageData.state} onChange={(e) => handleInputChange(e, "state")} />
            <input type="text" placeholder="Country" value={packageData.country} onChange={(e) => handleInputChange(e, "country")} />
          </div>

          {packageData.itineraries.map((itinerary, itineraryIndex) => (
            <div key={itineraryIndex} className="itinery">
              <h2>Days</h2>
              <input
                type="text"
                placeholder="Transport"
                value={itinerary.transport}
                onChange={(e) => handleItineraryInputChange(itineraryIndex, "transport", e.target.value)}
              />
              <input
                type="number"
                placeholder="Transport Fair"
                value={itinerary.transportFair}
                onChange={(e) => handleItineraryInputChange(itineraryIndex, "transportFair", e.target.value)}
              />
              <input
                type="text"
                placeholder="Food"
                value={itinerary.food}
                onChange={(e) => handleItineraryInputChange(itineraryIndex, "food", e.target.value)}
              />
              <input
                type="number"
                placeholder="Food Fair"
                value={itinerary.foodFair}
                onChange={(e) => handleItineraryInputChange(itineraryIndex, "foodFair", e.target.value)}
              />

              <h3>Stay</h3>
              <input
                type="number"
                placeholder="hotelId"
                value={itinerary.stay.hotelId}
                onChange={(e) => handleItineraryInputChange(itineraryIndex, "stay", { ...itinerary.stay, hotelId: e.target.value })}
              />
              <input
                type="number"
                placeholder="roomId"
                value={itinerary.stay.roomId}
                onChange={(e) => handleItineraryInputChange(itineraryIndex, "stay", { ...itinerary.stay, roomId: e.target.value })}
              />
              <br />
              <h3>Activities</h3>
              {itinerary.activities.map((activity, activityIndex) => (
                <div key={activityIndex}>
                  <input
                    type="text"
                    placeholder="ActivityName"
                    value={activity.activityName}
                    onChange={(e) => handleActivityInputChange(itineraryIndex, activityIndex, "activityName", e.target.value)}
                  />
                  <input
                    type="text"
                    placeholder="Picture"
                    value={activity.picture}
                    onChange={(e) => handleActivityInputChange(itineraryIndex, activityIndex, "picture", e.target.value)}
                  />
                  <input
                    type="text"
                    placeholder="Sport"
                    value={activity.sport}
                    onChange={(e) => handleActivityInputChange(itineraryIndex, activityIndex, "sport", e.target.value)}
                  />
                  <input
                    type="text"
                    placeholder="City "
                    value={activity.cityId}
                    onChange={(e) => handleActivityInputChange(itineraryIndex, activityIndex, "city", e.target.value)}
                  />
                </div>
              ))}
              <button onClick={() => handleAddActivity(itineraryIndex)}>Add Activity</button>
              <br />
            </div>
          ))}

          <button onClick={handleAddItinerary}>Add Itinerary</button>
        </div>
        <div className="modalFooter">
          <button onClick={() => closeModal(false)}>Cancel</button>
          <button onClick={handleAddPackage}>Add</button>
        </div>
      </div>
    </div>
  );
}

export default PackageAddModal;

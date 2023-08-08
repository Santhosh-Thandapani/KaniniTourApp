import React, { useState } from "react";

function PackageAddModal({ closeModal }) {

  const [packageData, setPackageData] = useState({
    packageName: "",
    daysCount: 0,
    nightsCount: 0,
    maxLimit: 0,
    picture: "",
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
        city: "",
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
              alert("Succedsss");
              closeModal(false)
          }     
      })
      .catch(error => console.log(error));
  };

  return (
    <div className="agent">
      <div className="popup">
        <div className="popup-inner">
          <button onClick={() => closeModal(false)}>X</button>
          <div className="modalTitle">
            <h2>Add Package</h2>
          </div>
          <div className="modelBody">
            <div className="form-row">
              <div className="form-column">
                <div className="form-column-inner">
                  <label>
                    Package Name:
                    <input type="text" name="packageName" value={packageData.packageName} onChange={(e) => handleInputChange(e, "packageName")} />
                  </label>

                  <label>
                    Days:
                    <input type="number" name="daysCount" value={packageData.daysCount} onChange={(e) => handleInputChange(e, "daysCount")} />
                  </label>

                  <label>
                    Nights:
                    <input type="number" name="nightsCount" value={packageData.nightsCount} onChange={(e) => handleInputChange(e, "nightsCount")} />
                  </label>

                  <label>
                    Max Limit:
                    <input type="number" name="maxLimit" value={packageData.maxLimit} onChange={(e) => handleInputChange(e, "maxLimit")} />
                  </label>
                </div>
              </div>

              <div className="form-column">
                <div className="form-column-inner">
                  <label>
                    Picture:
                    <input type="text" name="picture" value={packageData.picture} onChange={(e) => handleInputChange(e, "picture")} />
                  </label>

                  <label>
                    City:
                    <input type="text" name="city" value={packageData.city} onChange={(e) => handleInputChange(e, "city")} />
                  </label>

                  <label>
                    State:
                    <input type="text" name="state" value={packageData.state} onChange={(e) => handleInputChange(e, "state")} />
                  </label>

                  <label>
                    Country:
                    <input type="text" name="country" value={packageData.country} onChange={(e) => handleInputChange(e, "country")} />
                  </label>
                </div>
              </div>
            </div>

            {/* Itineraries */}
            {packageData.itineraries.map((itinerary, itineraryIndex) => (
              <div key={itineraryIndex} className="itinery">
                <h2>Itinerary {itineraryIndex + 1}</h2>
                <label>
                  Transport:
                  <input
                    type="text"
                    value={itinerary.transport}
                    onChange={(e) => handleItineraryInputChange(itineraryIndex, "transport", e.target.value)}
                  />
                </label>

                <label>
                  Transport Fair:
                  <input
                    type="number"
                    value={itinerary.transportFair}
                    onChange={(e) => handleItineraryInputChange(itineraryIndex, "transportFair", e.target.value)}
                  />
                </label>

                <label>
                  Food:
                  <input
                    type="text"
                    value={itinerary.food}
                    onChange={(e) => handleItineraryInputChange(itineraryIndex, "food", e.target.value)}
                  />
                </label>

                <label>
                  Food Fair:
                  <input
                    type="number"
                    value={itinerary.foodFair}
                    onChange={(e) => handleItineraryInputChange(itineraryIndex, "foodFair", e.target.value)}
                  />
                </label>

                {/* Activities */}
                <h3>Activities</h3>
                {itinerary.activities.map((activity, activityIndex) => (
                  <div key={activityIndex}>
                    <label>
                      Activity Name:
                      <input
                        type="text"
                        value={activity.activityName}
                        onChange={(e) =>
                          handleActivityInputChange(itineraryIndex, activityIndex, "activityName", e.target.value)
                        }
                      />
                    </label>

                    <label>
                      Picture:
                      <input
                        type="text"
                        value={activity.picture}
                        onChange={(e) => handleActivityInputChange(itineraryIndex, activityIndex, "picture", e.target.value)}
                      />
                    </label>

                    <label>
                      Sport:
                      <input
                        type="text"
                        value={activity.sport}
                        onChange={(e) => handleActivityInputChange(itineraryIndex, activityIndex, "sport", e.target.value)}
                      />
                    </label>

                    <label>
                      City:
                      <input
                        type="text"
                        value={activity.city}
                        onChange={(e) => handleActivityInputChange(itineraryIndex, activityIndex, "city", e.target.value)}
                      />
                    </label>
                  </div>
                ))}

                <button button="button" onClick={() => handleAddActivity(itineraryIndex)}>Add Activity</button>
                <br />
              </div>
            ))}

            <button  button="button" onClick={handleAddItinerary}>Add Itinerary</button>
          </div>

          <div className="form-buttons">
            <button  button="button" onClick={() => closeModal(false)}>Cancel</button>
            <button  button="button" onClick={handleAddPackage}>Add</button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default PackageAddModal;

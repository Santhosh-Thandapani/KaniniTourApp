import React from 'react';

const SearchForm = () => {
  const adultOptions = Array.from({ length: 11 }, (_, i) => i); // [0, 1, 2, ..., 10]
  const childrenOptions = Array.from({ length: 11 }, (_, i) => i); // [0, 1, 2, ..., 10]

  return (
    <div className="tm-section tm-bg-img" id="tm-section-1">
      <div className="tm-bg-white ie-container-width-fix-2">
        <div className="container ie-h-align-center-fix">
          <div className="row">
            <div className="col-xs-12 ml-auto mr-auto ie-container-width-fix">
              <form action="index.html" method="get" className="tm-search-form tm-section-pad-2">
                <div className="form-row tm-search-form-row d-flex justify-content-between align-items-center">
                  <div className="form-group col-md-4">
                    <div className="input-group">
                      <input name="city" type="text" className="form-control" id="inputCity" placeholder="Type your destination..." />
                      <div className="input-group-append">
                        <i className="fa fa-map-marker fa-2x tm-form-element-icon input-group-text"></i>
                      </div>
                    </div>
                  </div>
                  <div className="form-group col-md-4">
                    <div className="input-group">
                      <input name="check-in" type="date" className="form-control" id="inputCheckIn" placeholder="Check In" />
                      <div className="input-group-append">
                        <i className="fa fa-calendar fa-2x tm-form-element-icon input-group-text"></i>
                      </div>
                    </div>
                  </div>
                  <div className="form-group col-md-4">
                    <div className="input-group">
                      <input name="check-out" type="date" className="form-control" id="inputCheckOut" placeholder="Check Out" />
                      <div className="input-group-append">
                        <i className="fa fa-calendar fa-2x tm-form-element-icon input-group-text"></i>
                      </div>
                    </div>
                  </div>
                </div>
                <div className="form-row tm-search-form-row d-flex justify-content-between align-items-center">
                  <div className="form-group col-md-3">
                    <div className="input-group">
                      <select name="adult" className="form-control tm-select" id="adult">
                        <option value="">Adult</option>
                        {adultOptions.map((option) => (
                          <option key={option} value={option}>
                            {option}
                          </option>
                        ))}
                      </select>
                      <div className="input-group-append">
                        <i className="fa fa-2x fa-user tm-form-element-icon input-group-text"></i>
                      </div>
                    </div>
                  </div>
                  <div className="form-group col-md-3">
                    <div className="input-group">
                      <select name="children" className="form-control tm-select" id="children">
                        <option value="">Children</option>
                        {childrenOptions.map((option) => (
                          <option key={option} value={option}>
                            {option}
                          </option>
                        ))}
                      </select>
                      <div className="input-group-append">
                        <i className="fa fa-user tm-form-element-icon tm-form-element-icon-small input-group-text"></i>
                      </div>
                    </div>
                  </div>
                  <div className="form-group col-md-3">
                    <div className="input-group">
                      <select name="room" className="form-control tm-select" id="room">
                        <option value="">Room</option>
                      </select>
                      <div className="input-group-append">
                        <i className="fa fa-2x fa-bed tm-form-element-icon input-group-text"></i>
                      </div>
                    </div>
                  </div>
                  <div className="form-group col-md-3">
                    <button type="submit" className="btn btn-primary btn-block tm-btn-search">Check Availability</button>
                  </div>
                </div>
                <div className="form-row clearfix pl-2 pr-2 tm-fx-col-xs">
                  <p className="tm-margin-b-0">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                  <a href="#" className="ie-10-ml-auto ml-auto mt-1 tm-font-semibold tm-color-primary">Need Help?</a>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SearchForm;

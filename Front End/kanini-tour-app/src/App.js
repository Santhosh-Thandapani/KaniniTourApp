import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import '@fortawesome/fontawesome-free/css/all.min.css';
import { BrowserRouter, Route, Routes} from 'react-router-dom';
import AdminHome from './Components/AdminPage/AdminPage';
import Room from './Components/Room/Room';
import Packages from './Components/Packages/Packages';
import PackageDetail from './Components/PackageDetail/PackageDetail';
import Profile from './Components/Profile/Profile';
import History from './Components/History/History';
import AddHotelModal from './Components/AddHotelModal/AddHotelModal';
import ViewHotelReview from './Components/ViewHotelReview/ViewHotelReview';
import Sample from './Components/Sample';
import LandingPage from './Components/LandingPage';
import Hotel from './Components/Hotels/Hotel';


function App() {
  return (
    <div>

      <BrowserRouter>
         <Routes>
           <Route path='/' element={<LandingPage/>}/>
           <Route path='adminHome' element={<AdminHome/>}/>
           <Route path='/hotels' element={<Hotel/>}/>
           <Route path='/room/:id' element={<Room/>}/> 
           <Route path='/packages' element={<Packages/>}/>
           <Route path='/package/:id' element={<PackageDetail/>}/>
           <Route path='/profile' element={<Profile/>}/>
           <Route path='/history' element={<History/>}/>
           <Route path='/addhotel' element={<AddHotelModal/>}/>
           <Route path='/review' element={<ViewHotelReview/>}/>
           <Route path='/sample' element={<Sample/>}/>
         </Routes>
      </BrowserRouter> 
      
    </div>
  );
}

export default App;

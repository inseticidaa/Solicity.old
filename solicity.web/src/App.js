import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/styles/global.css';

import { Route, Routes } from "react-router-dom";
import { ProtectedRoute } from './components/ProtectedRoute';


// Pages
import LoginPage from './pages/Login';
import { AuthProvider } from './components/AuthProvider';
import TeamPage from './pages/Team';

function App() {
  return (
    <AuthProvider>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/" element={<ProtectedRoute><Home /></ProtectedRoute>} />
        <Route path="/teams/:id" element={<ProtectedRoute><TeamPage /></ProtectedRoute>} />
      </Routes>
    </AuthProvider>
  );
}

// Home.js file
const Home = () => {
  return <div className="element">This is Home page</div>;
};

export default App;

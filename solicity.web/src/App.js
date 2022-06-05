import { Route, Routes } from "react-router-dom";
import { AuthProvider } from './components/AuthProvider';
import { ProtectedLayout } from './components/ProtectedLayout';

import HomePage from './pages/Home';
import LoginPage from './pages/Login';
import TeamPage from './pages/Team';
import TeamsPage from "./pages/Teams";
import CreateTeamPage from "./pages/TeamCreate";

import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/styles/global.css';

function App() {
  return (
    <AuthProvider>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path='/' element={<ProtectedLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/teams" element={<TeamsPage />} />
          <Route path="/teams/:id" element={<TeamPage />} />
          <Route path="/teams/create" element={<CreateTeamPage />} />
        </Route>
      </Routes>
    </AuthProvider>
  );
}

export default App;

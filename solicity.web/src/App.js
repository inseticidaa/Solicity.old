import Request from "./pages/Request";

import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/styles/global.css';

import { AuthProvider, RequireAuth } from "./components/AuthProvider";
import { Route, Routes } from "react-router-dom";
import Layout from "./components/Layout";
import Login from "./pages/Login";

function App() {
  return (
    <AuthProvider>
      <Routes element={<Layout />}>
          <Route path="/login" element={<Login />} />
          <Route path="/" element= {
              <RequireAuth>
                <div>asdoaskdo</div>
              </RequireAuth>
            }
          />
      </Routes>
    </AuthProvider>
  );
}

export default App;

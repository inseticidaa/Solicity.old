import { Navigate, useNavigate } from "react-router-dom";
import { useAuth } from "./AuthProvider";

export const ProtectedRoute = ({ children }) => {
    const { user } = useAuth();
    const navigate = useNavigate();

    if (!user) {
        navigate("/login")
    }

    return children;
};
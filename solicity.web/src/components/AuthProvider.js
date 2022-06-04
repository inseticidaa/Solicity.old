import React from "react";
import { Navigate, useLocation } from "react-router-dom";

let AuthContext = React.createContext(null);

export function AuthProvider({ children }) {
  let [user, setUser] = React.useState(null);

  let signin = (email, password, callback) => {
    fetch('https://localhost:7264/api/Auth/Authenticate',
      {
        method: "POST",
        body: JSON.stringify({ email, password }),
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response, err) => {
        if (err) return callback("Internal Server Error: Error on try parse json from request response");

        response.json().then((body, err) => {
          if (err) return callback("Internal Server Error: Error on try parse json from request response");

          switch (response.status) {
            case 400:
            case 401:
              console.log(body)
              callback({ message: body.message, type: "warning" })
              break;
            case 200:
              setUser(body);
              callback();
              break;
          };
        });
      })
  };

  let signout = (callback) => {
    callback();
    setUser(null);
  };

  let value = { user, signin, signout };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}

export function useAuth() {
  return React.useContext(AuthContext);
}

export function RequireAuth({ children }) {
  let auth = useAuth();
  let location = useLocation();

  if (!auth.user) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  return children;
}

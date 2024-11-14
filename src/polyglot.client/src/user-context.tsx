import React, {createContext, useState, useContext, useEffect, ReactNode} from 'react';

// Define the shape of our user data
interface User {
  firstName: string;
  lastName: string;
  email: string;
}

// Define the shape of our context
interface UserContextType {
  user: User | null;
  fetchUser: () => Promise<void>;
  logout: () => Promise<void>;
}

// Create the UserContext
const UserContext = createContext<UserContextType | undefined>(undefined);

// Create a provider component
export const UserProvider: React.FC<{ children: ReactNode }> = ({children}) => {
  const [user, setUser] = useState<User | null>(null);

  const fetchUser = async () => {
    const response = await fetch('/api/v1/users/me');

    if (response.status !== 200) {
      return;
    }

    const data = await response.json();
    setUser(data);
  };
  
  const logout = async () => {
    await fetch('api/v1/users/logout');
    setUser(null);
  }

  // Fetch user on mount
  useEffect(() => {
    fetchUser();
  }, []);

  return (
    <UserContext.Provider value={{user, fetchUser, logout}}>
      {children}
    </UserContext.Provider>
  );
};

// Custom hook to use the UserContext
export const useUser = () => {
  const context = useContext(UserContext);
  if (!context) throw new Error('useUser must be used within a UserProvider');
  return context;
};

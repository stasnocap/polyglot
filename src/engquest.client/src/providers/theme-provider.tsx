import React, {createContext, useContext, useState, ReactNode} from 'react';

interface ThemeContextType {
    theme: string;
    switchTheme: (theme: string) => void;
}

const ThemeContext = createContext<ThemeContextType | undefined>(undefined);

export const ThemeProvider: React.FC<{ children: ReactNode }> = ({children}) => {
    const savedTheme = localStorage.getItem("theme") ?? "purple";

    const [theme, setTheme] = useState(savedTheme);

    const switchTheme = (theme: string) => {
        localStorage.setItem("theme", theme);
        setTheme(theme);
    };

    return (
        <ThemeContext.Provider value={{theme, switchTheme}}>
            {children}
        </ThemeContext.Provider>
    );
};

export const useTheme = (): ThemeContextType => {
    const context = useContext(ThemeContext);
    if (context === undefined) {
        throw new Error('useTheme must be used within a ThemeProvider');
    }
    return context;
};
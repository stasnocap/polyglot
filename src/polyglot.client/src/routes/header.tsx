import {Navbar, NavbarBrand, NavbarContent, NavbarItem, Link, Button} from "@nextui-org/react";
import {NavLink as RouterLink} from "react-router-dom";
import {useEffect, useState} from "react";

interface User {
  email: string;
}

export default function Header() {
  let emptyUser: User = {email: ""};
  const [user, setUser] = useState<User>(emptyUser);

  useEffect(() => {
    async function fetchUser() {
      const response = await fetch('/ping-auth');

      if (response.status === 200) {
        const json = await response.json();
        setUser({email: json.email});
      }
    }

    fetchUser()
      .catch(e => console.log(e.message));
  }, []);

  const login =
    <>
      <NavbarItem className="hidden lg:flex">
        <a href="/login">Login</a>
      </NavbarItem>
      <NavbarItem>
        <Button as={Link} color="primary" href="#" variant="flat">
          Sign Up
        </Button>
      </NavbarItem>
    </>;

  function handleLogoutClick() {
    window.location.href = `/logout?redirectUri=${window.location.pathname}`;
  }

  const logout =
    <>
      <NavbarItem>
        Hi {user.email}!
      </NavbarItem>
      <NavbarItem>
        <Button as={Link} color="primary" onClick={handleLogoutClick} variant="flat">
          Log Out
        </Button>
      </NavbarItem>
    </>;

  return (
    <Navbar>
      <NavbarBrand>
        <p className="font-bold text-inherit">POLYGLOT</p>
      </NavbarBrand>
      <NavbarContent className="hidden sm:flex gap-4" justify="center">
        <NavbarItem>
          <RouterLink to="/" color="foreground">
            Home
          </RouterLink>
        </NavbarItem>
        <NavbarItem>
          <RouterLink to="/lessons" color="foreground">
            Lessons
          </RouterLink>
        </NavbarItem>
        <NavbarItem>
          <RouterLink to="/contacts" className={({isActive, isPending}) =>
            isActive
              ? "active"
              : isPending
                ? "pending"
                : ""
          } aria-current="page">
            Contacts
          </RouterLink>
        </NavbarItem>
        <NavbarItem>
          <RouterLink to="/weather">
            Weather
          </RouterLink>
        </NavbarItem>
      </NavbarContent>
      <NavbarContent justify="end">
        {user.email ? logout : login}
      </NavbarContent>
    </Navbar>
  );
}
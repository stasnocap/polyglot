import {Navbar, NavbarBrand, NavbarContent, NavbarItem, Link, Button, DropdownItem, DropdownMenu, Dropdown, DropdownTrigger, Avatar, NavbarMenuToggle, NavbarMenu, NavbarMenuItem} from "@nextui-org/react";
import {NavLink as RouterLink} from "react-router-dom";
import {useEffect, useState} from "react";
import PolyglotLogo from "../icons/polyglot-logo.tsx";

interface User {
  email: string;
}

export default function Header() {
  let emptyUser: User = {email: ""};
  const [user, setUser] = useState<User>(emptyUser);
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  useEffect(() => {
    async function fetchUser() {
      const response = await fetch('/ping-auth');

      const json = await response.json();

      if (json.email) {
        setUser({email: json.email});
      }
    }

    fetchUser()
      .catch(e => console.log(e.message));
  }, []);

  const login =
    <>
      <NavbarItem>
        <Link href="/login" color="foreground">Login</Link>
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
      <NavbarContent as="div" justify="end">
        <Dropdown placement="bottom-end">
          <DropdownTrigger>
            <Avatar
              isBordered
              className="transition-transform cursor-pointer"
              color="secondary"
              name="Jason Hughes"
              size="sm"
              src="https://i.pravatar.cc/150?u=a042581f4e29026704d"
            />
          </DropdownTrigger>
          <DropdownMenu aria-label="Profile Actions" variant="flat">
            <DropdownItem key="profile" className="h-14 gap-2" textValue={`Signed in as ${user.email}`}>
              <p className="font-semibold">Signed in as</p>
              <p className="font-semibold">{user.email}</p>
            </DropdownItem>
            <DropdownItem key="logout" color="danger" onClick={handleLogoutClick}>
              Log Out
            </DropdownItem>
          </DropdownMenu>
        </Dropdown>
      </NavbarContent>
    </>;

  return (
    <Navbar shouldHideOnScroll onMenuOpenChange={setIsMenuOpen}>
      <NavbarContent>
        <NavbarMenuToggle
          as="div"
          aria-label={isMenuOpen ? "Close menu" : "Open menu"}
          className="sm:hidden text-foreground cursor-pointer"
        />
        <RouterLink to="/">
          <NavbarBrand>
            <PolyglotLogo height={32} width={32}/>
            <p className="font-bold text-inherit ms-2 text-secondary-400">POLYGLOT</p>
          </NavbarBrand>
        </RouterLink>
      </NavbarContent>
      <NavbarContent className="hidden sm:flex gap-4" justify="center">
        <NavbarItem>
          <Link as="div" color="foreground">
            <RouterLink to="/lessons">
              Lessons
            </RouterLink>
          </Link>
        </NavbarItem>
        <NavbarItem>
          <Link as="div" color="foreground">
            <RouterLink to="/contacts" className={({isActive, isPending}) =>
              isActive
                ? "active"
                : isPending
                  ? "pending"
                  : ""
            } aria-current="page">
              Contacts
            </RouterLink>
          </Link>
        </NavbarItem>
        <NavbarItem>
          <Link as="div" color="foreground">
            <RouterLink to="/weather">
              Weather
            </RouterLink>
          </Link>
        </NavbarItem>
      </NavbarContent>
      <NavbarContent justify="end">
        {user.email ? logout : login}
      </NavbarContent>
      <NavbarMenu>
        <NavbarMenuItem key="lessons">
          <Link
            as="div"
            color="secondary"
            className="w-full"
            size="lg"
          >
            <RouterLink to="/lessons">
              Lessons
            </RouterLink>
          </Link>
        </NavbarMenuItem>
        <NavbarMenuItem key="contacts">
          <Link
            as="div"
            color="foreground"
            className="w-full"
            size="lg"
          >
            <RouterLink to="/contacts">
              Contacts
            </RouterLink>
          </Link>
        </NavbarMenuItem>
        <NavbarMenuItem key="weather">
          <Link
            as="div"
            color="foreground"
            className="w-full"
            size="lg"
          >
            <RouterLink to="/weather">
              Weather
            </RouterLink>
          </Link>
        </NavbarMenuItem>
        {user.email ? (
          <NavbarMenuItem key="logout">
            <Link
              color="danger"
              className="w-full"
              href="/logout"
              size="lg"
            >
              Logout
            </Link>
          </NavbarMenuItem>
        ) : (
          <>
            <NavbarMenuItem key="login">
              <Link
                color="foreground"
                className="w-full"
                href="/login"
                size="lg"
              >
                Login
              </Link>
            </NavbarMenuItem>
            <NavbarMenuItem key="register">
              <Link
                color="primary"
                className="w-full"
                href="/register"
                size="lg"
              >
                Sign up
              </Link>
            </NavbarMenuItem>
          </>
        )}
      </NavbarMenu>
    </Navbar>
  );
}
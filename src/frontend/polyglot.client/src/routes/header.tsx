import {Navbar, NavbarBrand, NavbarContent, NavbarItem, Link, Button, DropdownItem, DropdownMenu, Dropdown, DropdownTrigger, Avatar, NavbarMenuToggle, NavbarMenu, NavbarMenuItem} from "@nextui-org/react";
import {NavLink as RouterLink} from "react-router-dom";
import React, {useEffect, useState} from "react";
import PolyglotLogo from "../icons/polyglot-logo.tsx";
import Palette from "../components/palette.tsx";

interface User {
  email: string;
}

export default function Header({theme, setTheme}: { theme: string, setTheme: React.Dispatch<React.SetStateAction<string>> }) {
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
        <Button as={Link} color="primary" href="/login" variant="light">
          Log In
        </Button>
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
      <Dropdown placement="bottom-end" className={`${theme} bg-background`}>
        <DropdownTrigger>
          <Avatar
            isBordered
            className="transition-transform cursor-pointer"
            color="primary"
            name="Jason Hughes"
            size="sm"
            src="https://i.pravatar.cc/150?u=a042581f4e29026704d"
          />
        </DropdownTrigger>
        <DropdownMenu aria-label="Profile Actions" variant="flat" className="text-foreground">
          <DropdownItem key="profile" className="h-14 gap-2" textValue={`Signed in as ${user.email}`}>
            <p className="font-semibold">Signed in as</p>
            <p className="font-semibold text-primary">{user.email}</p>
          </DropdownItem>
          <DropdownItem key="logout" color="danger" onClick={handleLogoutClick}>
            Log Out
          </DropdownItem>
        </DropdownMenu>
      </Dropdown>
    </>;

  function switchTheme(theme: string) {
    localStorage.setItem("theme", theme);
    setTheme(theme);
  }

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
            <p className="font-bold text-inherit ms-2 text-primary">POLYGLOT</p>
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
        <Dropdown className={`${theme} bg-background`}>
          <NavbarItem>
            <DropdownTrigger>
              <Button
                disableRipple
                className="p-0 bg-transparent data-[hover=true]:bg-transparent"
                radius="sm"
                variant="light"
              >
                Themes
              </Button>
            </DropdownTrigger>
          </NavbarItem>
          <DropdownMenu
            aria-label="themes"
            className="w-[190px]"
          >
            <DropdownItem
              key="purple"
              onClick={() => switchTheme("purple")}
              textValue="purple"
            >
              <Palette theme="Purple" colors={["#F4EEFF", "#DCD6F7", "#A6B1E1", "#424874"]} isLightTheme={true}/>
            </DropdownItem>
            <DropdownItem
              key="cream"
              onClick={() => switchTheme("cream")}
              textValue="cream"
            >
              <Palette theme="Cream" colors={["#FFF5E4", "#FFE3E1", "#FFD1D1", "#FF9494"]} isLightTheme={true}/>
            </DropdownItem>
            <DropdownItem
              key="skin"
              onClick={() => switchTheme("skin")}
              textValue="skin"
            >
              <Palette theme="Skin" colors={["#FFC7C7", "#FFE2E2", "#F6F6F6", "#8785A2"]} isLightTheme={true}/>
            </DropdownItem>
            <DropdownItem
              key="teal"
              onClick={() => switchTheme("teal")}
              textValue="teal"
            >
              <Palette theme="Teal" colors={["#222831", "#393E46", "#00ADB5", "#EEEEEE"]} isLightTheme={false}/>
            </DropdownItem>
            <DropdownItem
              key="navy"
              onClick={() => switchTheme("navy")}
              textValue="navy"
            >
              <Palette theme="Navy" colors={["#1B262C", "#0F4C75", "#3282B8", "#BBE1FA"]} isLightTheme={false}/>
            </DropdownItem>
            <DropdownItem
              key="night"
              onClick={() => switchTheme("night")}
              textValue="night"
            >
              <Palette theme="Night" colors={["#27374D", "#526D82", "#9DB2BF", "#DDE6ED"]} isLightTheme={false} />
            </DropdownItem>
          </DropdownMenu>
        </Dropdown>
        {user.email ? logout : login}
      </NavbarContent>
      <NavbarMenu>
        <NavbarMenuItem key="lessons">
          <Link
            as="div"
            color="primary"
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
                Log In
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
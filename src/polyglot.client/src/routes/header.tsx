import {Navbar, NavbarBrand, NavbarContent, NavbarItem, Link, Button} from "@nextui-org/react";
import {NavLink as RouterLink} from "react-router-dom";

export default function Header() {
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
        <NavbarItem className="hidden lg:flex">
          <a href="/login">Login</a>
        </NavbarItem>
        <NavbarItem>
          <Button as={Link} color="primary" href="#" variant="flat">
            Sign Up
          </Button>
        </NavbarItem>
      </NavbarContent>
    </Navbar>
  );
}
import {Navbar, NavbarBrand, NavbarContent, NavbarItem, Link, Button, DropdownItem, DropdownMenu, Dropdown, DropdownTrigger, Avatar, NavbarMenuToggle, NavbarMenu, NavbarMenuItem} from "@nextui-org/react";
import {NavLink as RouterLink, useNavigate} from "react-router-dom";
import React, {useState} from "react";
import EngQuestLogo from "../icons/eng-quest-logo.tsx";
import Palette from "../components/palette.tsx";
import BrushIcon from "../icons/brush-icon.tsx";
import {useUser} from "../user-context.tsx";

export default function Header({theme, setTheme}: { theme: string, setTheme: React.Dispatch<React.SetStateAction<string>> }) {
  const {user, logout} = useUser();
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const navigate = useNavigate();

  function switchTheme(theme: string) {
    localStorage.setItem("theme", theme);
    setTheme(theme);
  }

  return (
    <Navbar shouldHideOnScroll onMenuOpenChange={setIsMenuOpen} disableAnimation className="sticky">
      <NavbarContent>
        <NavbarMenuToggle
          as="div"
          aria-label={isMenuOpen ? "Close menu" : "Open menu"}
          className="sm:hidden text-foreground cursor-pointer"
        />
        <RouterLink to="/">
          <NavbarBrand>
            <EngQuestLogo height={32} width={32}/>
            <p className="text-inherit ms-2 font-bold"><span className="text-primary">ENG</span><span className="text-primary-100">QUEST</span></p>
          </NavbarBrand>
        </RouterLink>
      </NavbarContent>
      <NavbarContent className="hidden sm:flex gap-4" justify="center">
        <NavbarItem>
          <Link as="div" color="primary">
            <RouterLink to="/lessons">
              Приключение
            </RouterLink>
          </Link>
        </NavbarItem>
        <NavbarItem>
          <Link as="div" color="primary">
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
          <Link as="div" color="primary">
            <RouterLink to="/weather">
              Weather
            </RouterLink>
          </Link>
        </NavbarItem>
      </NavbarContent>
      <NavbarContent justify="end" className="gap-2">
        <Dropdown className={`${theme} bg-background`}>
          <NavbarItem>
            <DropdownTrigger>
              <Button
                as="div"
                disableRipple
                className="p-0 bg-transparent data-[hover=true]:bg-transparent"
                radius="sm"
                variant="light"
                isIconOnly
              >
                <BrushIcon height={32} width={32}/>
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
              <Palette theme="Фиолет" colors={["#F4EEFF", "#DCD6F7", "#A6B1E1", "#424874"]} isLightTheme={true}/>
            </DropdownItem>
            <DropdownItem
              key="cream"
              onClick={() => switchTheme("cream")}
              textValue="cream"
            >
              <Palette theme="Крем" colors={["#FFF5E4", "#FFE3E1", "#FFD1D1", "#FF9494"]} isLightTheme={true}/>
            </DropdownItem>
            <DropdownItem
              key="skin"
              onClick={() => switchTheme("skin")}
              textValue="skin"
            >
              <Palette theme="Кожа" colors={["#FFC7C7", "#FFE2E2", "#F6F6F6", "#8785A2"]} isLightTheme={true}/>
            </DropdownItem>
            <DropdownItem
              key="teal"
              onClick={() => switchTheme("teal")}
              textValue="teal"
            >
              <Palette theme="Бирюза" colors={["#222831", "#393E46", "#00ADB5", "#EEEEEE"]} isLightTheme={false}/>
            </DropdownItem>
            <DropdownItem
              key="navy"
              onClick={() => switchTheme("navy")}
              textValue="navy"
            >
              <Palette theme="Флот" colors={["#1B262C", "#0F4C75", "#3282B8", "#BBE1FA"]} isLightTheme={false}/>
            </DropdownItem>
            <DropdownItem
              key="night"
              onClick={() => switchTheme("night")}
              textValue="night"
            >
              <Palette theme="Ночь" colors={["#27374D", "#526D82", "#9DB2BF", "#DDE6ED"]} isLightTheme={false}/>
            </DropdownItem>
          </DropdownMenu>
        </Dropdown>
        {user ?
          (<>
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
                  <p className="font-semibold">Вы вошли как</p>
                  <p className="font-semibold text-primary">{user.email}</p>
                </DropdownItem>
                <DropdownItem key="logout" color="danger" onClick={logout}>
                  Выйти
                </DropdownItem>
              </DropdownMenu>
            </Dropdown>
          </>)
          :
          (<div className="gap-1 hidden md:flex">
            <NavbarItem>
              <Button as={Link} color="primary" variant="light" onClick={() => navigate("/login")}>
                Войти
              </Button>
            </NavbarItem>
            <NavbarItem>
              <Button as={Link} color="primary" variant="flat" onClick={() => navigate("/signup")}>
                Регистрация
              </Button>
            </NavbarItem>
          </div>)}
      </NavbarContent>
      <NavbarMenu className={theme}>
        <NavbarMenuItem key="lessons">
          <Link
            as="div"
            color="primary"
            className="w-full"
            size="lg"
          >
            <RouterLink to="/lessons">
              Приключение
            </RouterLink>
          </Link>
        </NavbarMenuItem>
        <NavbarMenuItem key="contacts">
          <Link
            as="div"
            color="primary"
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
            color="primary"
            className="w-full"
            size="lg"
          >
            <RouterLink to="/weather">
              Weather
            </RouterLink>
          </Link>
        </NavbarMenuItem>
        {user ? (
          <NavbarMenuItem key="logout">
            <Link
              color="danger"
              className="w-full"
              onClick={logout}
              size="lg"
            >
              Выйти
            </Link>
          </NavbarMenuItem>
        ) : (
          <>
            <NavbarMenuItem key="login">
              <RouterLink
                className="w-full text-primary"
                to="/login"
              >
                Войти
              </RouterLink>
            </NavbarMenuItem>
            <NavbarMenuItem key="register">
              <RouterLink
                color="primary"
                className="w-full text-primary"
                to="/signup"
              >
                Регистрация
              </RouterLink>
            </NavbarMenuItem>
          </>
        )}
      </NavbarMenu>
    </Navbar>
  );
}
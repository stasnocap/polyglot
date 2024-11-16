import {Button, Input} from "@nextui-org/react";
import {Form, useActionData, useNavigate, useSubmit} from "react-router-dom";
import {EyeFilledIcon, EyeSlashFilledIcon, MailIcon} from "../icons/authentication-icons.tsx";
import {useEffect, useState} from "react";
import {Result, ValidationError, post} from "../api.ts";
import {useUser} from "../user-context.tsx";

export function action({request}: { request: Request }): Promise<Result> {
  return post(request, 'api/v1/users/register');
}

export default function SignUp() {
  const [isVisible, setIsVisible] = useState(false);
  const navigate = useNavigate();
  const result = useActionData() as Result;
  const [firstNameError, setFirstNameError] = useState<ValidationError | null>(null);
  const [lastNameError, setLastNameError] = useState<ValidationError | null>(null);
  const [emailError, setEmailError] = useState<ValidationError | null>(null);
  const [passwordError, setPasswordError] = useState<ValidationError | null>(null);
  const [isLoading, setIsLoading] = useState(false);
  const submit = useSubmit();
  const { fetchUser } = useUser();

  useEffect(() => {
    if (!result) {
      return;
    }

    if (!result.ok) {
      result.errors!.forEach(error => {
        if (error.propertyName === 'FirstName') {
          setFirstNameError(error);
        } else if (error.propertyName === 'LastName') {
          setLastNameError(error);
        } else if (error.propertyName === 'Email') {
          setEmailError(error);
        } else if (error.propertyName === 'Password') {
          setPasswordError(error);
        }
      });
      
      setIsLoading(false);
      return;
    }

    fetchUser()
      .then(() => {
        setIsLoading(false);
        navigate('/quests');
      });
  }, [result]);

  function handleSubmitClick(event: any) {
    setIsLoading(true);
    submit(event.currentTarget);
  }

  const toggleVisibility = () => setIsVisible(!isVisible);

  return (
    <Form className="flex flex-col w-80 mx-auto gap-3" method="post">
      <Input
        color="primary"
        type="text"
        label="Имя"
        placeholder="Артур"
        description="Как вас зовут? Представьтесь, как настоящий герой!"
        labelPlacement="outside"
        name="firstName"
        isRequired
        isInvalid={!!firstNameError}
        errorMessage={firstNameError?.errorMessage}
        onInput={() => setFirstNameError(null)}
        isClearable
      />
      <Input
        color="primary"
        type="text"
        label="Фамилия"
        placeholder="Пендрагон"
        description="Ваша семейная история ждёт. Какое имя будет звучать через века?"
        labelPlacement="outside"
        name="lastName"
        isInvalid={!!lastNameError}
        errorMessage={lastNameError?.errorMessage}
        onInput={() => setLastNameError(null)}
        isClearable
        isRequired
      />
      <Input
        color="primary"
        type="email"
        label="Email"
        placeholder="arthur.pendragon@engquest.com"
        description="Впишите ваш магический e-mail"
        labelPlacement="outside"
        endContent={
          <MailIcon className="text-2xl text-default-400 pointer-events-none flex-shrink-0"/>
        }
        name="email"
        isInvalid={!!emailError}
        errorMessage={emailError?.errorMessage}
        onInput={() => setEmailError(null)}
        isRequired
      />
      <Input
        label="Пароль"
        className="max-w-xs"
        color="primary"
        labelPlacement="outside"
        description="Создайте свой тайный код"
        endContent={
          <button className="focus:outline-none" type="button" onClick={toggleVisibility} aria-label="toggle password visibility">
            {isVisible ? (
              <EyeSlashFilledIcon className="text-2xl text-default-400 pointer-events-none"/>
            ) : (
              <EyeFilledIcon className="text-2xl text-default-400 pointer-events-none"/>
            )}
          </button>
        }
        type={isVisible ? "text" : "password"}
        placeholder="Excalibur123!"
        name="password"
        isInvalid={!!passwordError}
        errorMessage={passwordError?.errorMessage}
        onInput={() => setPasswordError(null)}
        isRequired
      />
      <div className="flex justify-between">
        <Button type="submit" color="primary" isLoading={isLoading} onClick={handleSubmitClick}>Присоединиться к квесту!</Button>
        <Button type="button" color="primary" variant="light" onClick={() => navigate('/login')}>Войти</Button>
      </div>
    </Form>
  )
}
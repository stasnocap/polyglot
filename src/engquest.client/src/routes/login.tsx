import {Button, Input} from "@nextui-org/react";
import {Form, useActionData, useNavigate, useSubmit} from "react-router-dom";
import {EyeFilledIcon, EyeSlashFilledIcon, MailIcon} from "../icons/authentication-icons.tsx";
import {useEffect, useState} from "react";
import {post, Result, ApiError} from "../api.ts";
import {useUser} from "../providers/user-provider.tsx";

export function action({request}: { request: Request }): Promise<Result> {
  return post(request, 'api/v1/users/login');
}

export default function LogIn() {
  const [isVisible, setIsVisible] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [passwordError, setError] = useState<ApiError | null>(null);
  const { fetchUser } = useUser();
  const submit = useSubmit();
  const navigate = useNavigate();
  const result = useActionData() as Result;

  function handleSubmitClick(event: any) {
    setIsLoading(true);
    submit(event.currentTarget);
  }

  useEffect(() => {
    if (!result) {
      return;
    }

    if (!result.ok) {
      setError(result.error);
      setIsLoading(false);
      return;
    }
    
    fetchUser()
      .then(() => {
        setIsLoading(false);
        navigate('/quests');
      });
  }, [result]);

  const toggleVisibility = () => setIsVisible(!isVisible);

  return (
    <Form className="flex flex-col w-80 mx-auto gap-3" method="post">
      <Input
        color="primary"
        type="email"
        label="Email"
        placeholder="you@example.com"
        labelPlacement="outside"
        endContent={
          <MailIcon className="text-2xl text-default-400 pointer-events-none flex-shrink-0"/>
        }
        isInvalid={!!passwordError}
        errorMessage={passwordError?.name}
        onInput={() => setError(null)}
        name="email"
      />
      <Input
        label="Пароль"
        className="max-w-xs"
        color="primary"
        labelPlacement="outside"
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
        placeholder="Введите пароль"
        isInvalid={!!passwordError}
        errorMessage={passwordError?.name}
        onInput={() => setError(null)}
        name="password"
      />
      <div className="flex justify-between">
        <Button type="submit" color="primary" className="w-32" isLoading={isLoading} onClick={handleSubmitClick}>Войти</Button>
        <Button type="button" color="primary" variant="flat" className="w-32" onClick={() => navigate("/signup")}>Регистрация</Button>
      </div>
    </Form>
  )
}
interface ProblemDetails {
  type: string;
  title: string;
  status: number;
  detail: string;
  instance: string;
  errors: ValidationError[];
}

export interface ValidationError {
  errorMessage: string;
  propertyName: string;
}

export interface ApiError {
  code: string;
  name: string;
}

export interface Result {
  ok: boolean;
  errors: ValidationError[] | null;
  error: ApiError | null;
}

export async function post(request: Request, uri: string): Promise<Result> {
  const formData = await request.formData();
  const data = Object.fromEntries(formData);

  const response = await fetch(uri, {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify(data)
  });

  const result: Result = {ok: response.ok, errors: null, error: null };

  if (!response.ok && response.status >= 400 && response.status < 500) {
    const responseJson = await response.json();

    const contentType = response.headers.get('Content-Type');
    if (contentType && contentType.includes('application/problem+json')) {
      const problemDetails = responseJson as ProblemDetails;
      result.errors = problemDetails.errors;
      return result;
    }
    
    result.error = responseJson as ApiError;
    return result;
  }

  return result;
}
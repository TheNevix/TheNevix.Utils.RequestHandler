# TheNevix.Utils.RequestHandler

![NuGet](https://img.shields.io/nuget/v/TheNevix.Utils.RequestHandler) ![NuGet Downloads](https://img.shields.io/nuget/dt/TheNevix.Utils.RequestHandler)

A simple and flexible HTTP request handler utility for .NET applications. This library simplifies making API calls by providing an easy-to-use interface for sending HTTP requests.

## Features

- Simplified API for making HTTP requests
- Built-in error handling and response validation
- Supports .NET 6.0, 7.0, and 8.0

## Installation

You can install the package via NuGet Package Manager, .NET CLI, or by adding it to your project file.

### NuGet Package Manager

```bash
Install-Package TheNevix.Utils.RequestHandler
```

## Configuration

Enable the RequestHandler in your program.cs file.

```csharp
builder.Services.AddRequestHandlerServices();
```

## Usage

### HTTP request with ExecuteAsync() 

This example shows how to send an HTTP request and manage the response manually.

```csharp
public class SomeService
{
    private readonly IRequestHandler _requestHandler;

    public SomeService(IRequestHandler requestHandler)
    {
        _requestHandler = requestHandler;
    }

    public async Task DoSomethingAsync(string url)
    {
        var response = await requestHandler
            .CreateRequest("https://www.freetogame.com/api/games?platform=pc")
            .WithMethod(HttpMethod.Get)
            .ExecuteAsync();

        response.EnsureSuccessStatusCode();

        var jsonResponseBody = await response.Content.ReadAsStringAsync();

        var data = JsonConvert.DeserializeObject<List<SimpleExecuteAsync>>(jsonResponseBody);
    }
}

class SimpleExecuteAsync
{
    public string Title { get; set; }
    public string Genre { get; set; }
}
```

In this example, you receive an HttpResponseMessage object. You can then check the status code, deserialize the response body, and handle the data accordingly.

### HTTP request with ExecuteAsync&lt;TResponse&gt;() 

This example demonstrates how to send an HTTP request and let the library convert the JSON response into a provided response model.

```csharp
public class SomeService
{
    private readonly IRequestHandler _requestHandler;

    public SomeService(IRequestHandler requestHandler)
    {
        _requestHandler = requestHandler;
    }

    public async Task DoSomethingAsync(string url)
    {
        var response = await requestHandler
            .CreateRequest("https://www.freetogame.com/api/games?platform=pc")
            .WithMethod(HttpMethod.Get)
            .ExecuteAsync<List<ExecuteAsyncWithResponseModel>>();
    }
}

class ExecuteAsyncWithResponseModel
{
    public string Title { get; set; }
    public string Genre { get; set; }
}

```

Here, the response is automatically deserialized into the specified TResponse model. Remember to handle any potential exceptions, especially deserialization errors.

### HTTP request with ExecuteWithHandlingAsync&lt;TResponse, TData&gt;() 

This example shows how to send an HTTP request where the library not only converts the JSON response into a provided response model but also checks for errors. If an error occurs, the IsSuccess property will be false.

```csharp
public class SomeService
{
    private readonly IRequestHandler _requestHandler;

    public SomeService(IRequestHandler requestHandler)
    {
        _requestHandler = requestHandler;
    }

    public async Task DoSomethingAsync(string url)
    {
        var response = await requestHandler
            .CreateRequest("https://www.freetogame.com/api/games?platform=pc")
            .WithMethod(HttpMethod.Get)
            .ExecuteWithHandlingAsync<ResponseModel, List<GamesData>>();

        if (!response.IsSuccess)
        {
            //Handle an error
        }
    }
}

class ResponseModel : IResponseModel<List<GamesData>>
{
    public List<GamesData> Data { get; set; }
    public bool IsSuccess { get; set ; }
    public string? Message { get ; set ; }
    public int StatusCode { get; set; }
}

class GamesData
{
    public string Title { get; set; }
    public string Genre { get; set; }
}

```

In this case, the library handles the response and error checking for you. You can easily determine if the request was successful by checking the IsSuccess property.

## License

This project is licensed under the MIT License.

## Special thank you to freetogame

This documentation used the free freetogame api to showcase this package.

You can check them out at: https://www.freetogame.com/
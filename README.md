# TheNevix.Utils.RequestHandler

![NuGet](https://img.shields.io/nuget/v/TheNevix.Utils.RequestHandler) ![NuGet Downloads](https://img.shields.io/nuget/dt/TheNevix.Utils.RequestHandler)

A simple and flexible HTTP request handler utility for .NET applications. This library simplifies making API calls by providing an easy-to-use interface for sending HTTP requests with optional headers and handling responses.

## Features

- Simplified API for making HTTP requests
- Support for adding custom headers
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

This is an example of a basic GET request.

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
        var response = await _requestHandler.GetAsync(url);
        // Process the response
    }
}
```

All methods either return a JSON string as a result of the request or an exception.

Here's an example to pass headers to the GET request.

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
        var someHeaders = new Dictionary<string, string>
        {
            { "Authorization", "Bearer ey..." }
        };

        var someRequestOptions = new RequestHandlerOptions(someHeaders);

        var response = await _requestHandler.GetAsync(url, someRequestOptions);
        // Process the response
    }
}
```

This example applies for a methods, except for PUT, PATCH and POST. These methods also expect a body.

## Notes
Since I don't really use the DELETE request I have left it out for now. It will be added in the near future.

## License

This project is licensed under the MIT License.
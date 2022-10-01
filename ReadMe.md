# Configuration and Environment Variables Demo

This demo demonstrates how to read environment variables from configuration.

## Introduction

The default behavior of the configuration system in ASP.NET Core is to include environment variables. If you wish to retrieve and environment variable you can simply inject `IConfiguration` into a class and use the indexer to retrieve the desired environment variable.

```csharp
[Route("api/[controller]")]
[ApiController]
public class ConfigController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ConfigController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpGet]
    [Route("{key}")]
    public IActionResult Get(string key)
    {
        var value = _configuration[key];
        return Ok(value);
    }
}
```

## Usage

1. Open a terminal at the project root directory.
2. Set an environment variable.

```
export my_env_var=foo
echo $my_env_var
```

3. Run the web app.

```
dotnet run
```

4. Execute the config GET in a browser: https://localhost:7285/api/config/my_env_var

```
curl --location --request GET 'https://localhost:7285/api/config/my_env_var'
```

- The value of `foo` should be returned.
- Built-in ASPNETCORE environment variables are also accessible: https://localhost:7285/api/config/ASPNETCORE_ENVIRONMENT
- The value of `Development` should be returned.


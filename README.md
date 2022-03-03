## NebulaNet
[![NuGet version (NebulaNet)](https://img.shields.io/nuget/v/NebulaNet.svg?style=flat-square)](https://www.nuget.org/packages/NebulaNet/)
[![CI](https://github.com/shyboylpf/nebula-net/workflows/E2E/badge.svg)](https://github.com/shyboylpf/nebula-net/actions/workflows/ci.yml)
[![license](https://img.shields.io/badge/license-Apache%202.0-green.svg)](https://github.com/shyboylpf/nebula-net/blob/master-matt/LICENSES/Apache-2.0.txt)
[![issues](https://img.shields.io/github/issues/shyboylpf/nebula-net.svg)](https://github.com/shyboylpf/nebula-net/issues)

Nebula NET client.

## Install with .NET CLI

[https://www.nuget.org/packages/NebulaNet/](https://www.nuget.org/packages/NebulaNet/)
```shell
dotnet add package NebulaNet
```


## Quick Start

### Example-1:

```csharp
using NebulaNet;
using System;
using System.Text;
using System.Threading.Tasks;
NebulaConnection graphClient = new NebulaConnection();
await graphClient.OpenAsync("127.0.0.1", 9669);
var authResponse = await graphClient.AuthenticateAsync("root", "123456");
Console.WriteLine(authResponse.Session_id);

StringBuilder sb = new StringBuilder();
sb.Append("CREATE SPACE IF NOT EXISTS test(vid_type=FIXED_STRING(30));");
sb.Append("USE test;");
sb.Append("CREATE TAG IF NOT EXISTS person(name string, age int);");
sb.Append("CREATE EDGE like (likeness double);");

var executionResponse = await graphClient.ExecuteAsync(authResponse.Session_id, sb.ToString());

await Task.Delay(10000);

executionResponse = await graphClient.ExecuteAsync(authResponse.Session_id, "INSERT VERTEX person(name, age) VALUES \"Bob\":(\"Bob\", 10), \"Lily\":(\"Lily\", 9);");
await Task.Delay(5000);
executionResponse = await graphClient.ExecuteAsync(authResponse.Session_id, "INSERT EDGE like(likeness) VALUES \"Bob\"->\"Lily\":(80.0);");
await Task.Delay(5000);
executionResponse = await graphClient.ExecuteAsync(authResponse.Session_id, "FETCH PROP ON person \"Bob\" YIELD vertex as node;");
await Task.Delay(5000);
executionResponse = await graphClient.ExecuteAsync(authResponse.Session_id, "FETCH PROP ON like \"Bob\"->\"Lily\" YIELD edge as e;");
await Task.Delay(5000);

// 
var testDtos = await graphClient.ExecuteAsync(authResponse.Session_id, "FETCH PROP ON person \"Bob\",\"Lily\" YIELD properties(vertex).name AS name,properties(vertex).age AS age;")
    .ToListAsync<TestDto>();
foreach (var item in testDtos)
{
    Console.WriteLine($"1.name:{item.Name},age:{item.Age}");
}

executionResponse = await graphClient.ExecuteAsync(authResponse.Session_id, "DROP SPACE test;");
await Task.Delay(5000);

await graphClient.SignOutAsync(authResponse.Session_id);

public class TestDto
{
    public string Name { get; set; }
    public long Age { get; set; }
}
```

### Example-2(.NetCore):

Program.cs中配置：

```csharp
builder.Services.AddNebulaGraph(config =>
{
    config.Ip="49.232.18.127";
    config.Port = 8669;
});
```

使用：

```csharp
public class NebulaGraphController : ControllerBase
{
    private readonly NebulaPool _nebulaConnPool;
    public NebulaGraphController(NebulaPool nebulaConnPool)
    {
        _nebulaConnPool = nebulaConnPool;
    }
    
    public async Task<dynamic> MatchMultipleTest(string questionId)
    {
        var session = await _nebulaConnPool.GetSessionAsync();

        var output = await session.ExecuteAsync("FETCH PROP ON person \"Bob\",\"Lily\" YIELD properties(vertex).name AS name,properties(vertex).age AS age;")
            .ToListAsync<TestDto>();

        session.Release();

        return output;
    }
    
    public class TestDto
    {
        public string Name { get; set; }
        public long Age { get; set; }
    }
}
```


## License

Nebula NET is under Apache2.0 license.

using NebulaNet;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GraphClientExample
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
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


            Console.ReadKey();
        }
    }
    public class TestDto
    {
        public string Name { get; set; }
        public long Age { get; set; }
    }
}
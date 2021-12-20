using NebulaNet;
using System;
using System.Text;
using System.Threading.Tasks;

namespace GraphClientExample
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            GraphClient graphClient = new GraphClient("127.0.0.1", 9669);
            graphClient.Authenticate("root", "nebula");
            Console.WriteLine(graphClient.sessionId);

            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE SPACE IF NOT EXISTS test(vid_type=FIXED_STRING(30));");
            sb.Append("USE test;");
            sb.Append("CREATE TAG IF NOT EXISTS person(name string, age int);");
            sb.Append("CREATE EDGE like (likeness double);");

            var executionResponse = await graphClient.Execute(sb.ToString());

            await Task.Delay(10000);

            executionResponse = await graphClient.Execute("INSERT VERTEX person(name, age) VALUES \"Bob\":(\"Bob\", 10), \"Lily\":(\"Lily\", 9);");
            await Task.Delay(5000);
            executionResponse = await graphClient.Execute("INSERT EDGE like(likeness) VALUES \"Bob\"->\"Lily\":(80.0);");
            await Task.Delay(5000);
            executionResponse = await graphClient.Execute("FETCH PROP ON person \"Bob\" YIELD vertex as node;");
            await Task.Delay(5000);
            executionResponse = await graphClient.Execute("FETCH PROP ON like \"Bob\"->\"Lily\" YIELD edge as e;");
            await Task.Delay(5000);
            executionResponse = await graphClient.Execute("DROP SPACE test;");
            await Task.Delay(5000);

            await graphClient.SignOff();
        }
    }
}
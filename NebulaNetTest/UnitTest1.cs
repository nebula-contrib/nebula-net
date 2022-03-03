using NebulaNet;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace NebulaNetTest
{
    public class Tests
    {
        private static NebulaConnection _client;
        private static long Session_id;

        [OneTimeSetUp]
        public void Setup()
        {
            _client = new NebulaConnection();
            _client.OpenAsync("127.0.0.1", 9669).Wait();
            var authResponse = _client.AuthenticateAsync("root", "123456").Result;
            Session_id=authResponse.Session_id;
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _client.SignOutAsync(Session_id);
        }

        [Test]
        public async Task TestAll()
        {
            Assert.IsTrue(Session_id > 0);
            
            await _client.ExecuteAsync(Session_id,"ADD HOSTS 127.0.0.1:9779;");
            await Task.Delay(20000);

            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE SPACE IF NOT EXISTS test(vid_type=FIXED_STRING(30));");
            sb.Append("USE test;");
            sb.Append("CREATE TAG IF NOT EXISTS person(name string, age int);");
            sb.Append("CREATE EDGE like (likeness double);");

            var executionResponse = await _client.ExecuteAsync(Session_id,sb.ToString());
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);
            await Task.Delay(5000);

            executionResponse = await _client.ExecuteAsync(Session_id, "INSERT VERTEX person(name, age) VALUES \"Bob\":(\"Bob\", 10), \"Lily\":(\"Lily\", 9);");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);

            executionResponse = await _client.ExecuteAsync(Session_id, "INSERT EDGE like(likeness) VALUES \"Bob\"->\"Lily\":(80.0);");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);

            executionResponse = await _client.ExecuteAsync(Session_id, "FETCH PROP ON person \"Bob\" YIELD vertex as node;");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);

            executionResponse = await _client.ExecuteAsync(Session_id, "FETCH PROP ON like \"Bob\"->\"Lily\" YIELD edge as e;");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);

            executionResponse = await _client.ExecuteAsync(Session_id, "DROP SPACE test;");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);
        }
    }
}

using NebulaNet;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace NebulaNetTest
{
    public class Tests
    {
        private static GraphClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            _client = new GraphClient("127.0.0.1", 9669);
            _client.Authenticate("root", "nebula");
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _client.SignOff();
        }

        [Test]
        public void TestAll()
        {
            TestConnection();
            CreateTable().Wait();
            InsertTest().Wait();
            FetchTest().Wait();
            DropTest().Wait();
        }

        public void TestConnection()
        {
            Assert.IsTrue(_client.sessionId > 0);
        }

        public async Task CreateTable()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE SPACE IF NOT EXISTS test(vid_type=FIXED_STRING(30));");
            sb.Append("USE test;");
            sb.Append("CREATE TAG IF NOT EXISTS person(name string, age int);");
            sb.Append("CREATE EDGE like (likeness double);");

            var executionResponse = await _client.Execute(sb.ToString());
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);
        }

        public async Task InsertTest()
        {
            var executionResponse = await _client.Execute("INSERT VERTEX person(name, age) VALUES \"Bob\":(\"Bob\", 10), \"Lily\":(\"Lily\", 9);");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);

            executionResponse = await _client.Execute("INSERT EDGE like(likeness) VALUES \"Bob\"->\"Lily\":(80.0);");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);
        }

        public async Task FetchTest()
        {
            var executionResponse = await _client.Execute("FETCH PROP ON person \"Bob\" YIELD vertex as node;");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);

            executionResponse = await _client.Execute("FETCH PROP ON like \"Bob\"->\"Lily\" YIELD edge as e;");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);
        }

        public async Task DropTest()
        {
            var executionResponse = await _client.Execute("DROP SPACE test;");
            await Task.Delay(5000);
            Assert.IsTrue(executionResponse.Error_code == 0);
        }
    }
}
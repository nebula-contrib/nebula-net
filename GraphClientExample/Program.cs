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
            //GraphClient graphClient = new GraphClient("www.hexcopy.com", 8669);
           
            GraphClient graphClient = new GraphClient("49.232.18.127", 8669);
            graphClient.Authenticate("root", "123456");
            Console.WriteLine(graphClient.sessionId);

            await graphClient.Execute("USE test;");
            var a = await graphClient.Execute("FETCH PROP ON question \"0016e9fe-cd3b-4fcc-ba8d-23cfc267bd3a\",\"f4f51cf7-5fa9-4cbb-8e7d-82e52d58b6e9\" yield properties(vertex).questionId as questionId,properties(vertex).difficulty as difficulty")
                .ToListAsync<TestDto>();

            Console.ReadKey();
        }
    }
    public class TestDto
    {
        public string QuestionId { get; set; }

        public int Difficulty { get; set; }
    }
}
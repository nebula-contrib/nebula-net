using Nebula.Graph;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NebulaNet
{
    public class NebulaClient
    {
        private readonly NebulaConnection _connection;
        private readonly long sessionID;
        public NebulaClient(NebulaConnection connection, AuthResponse authResponse)
        {
            _connection=connection;
            sessionID = authResponse.Session_id;
        }

        public async Task<ExecutionResponse> Execute(string statement)
        {
            var executionResponse = await _connection.Execute(sessionID, statement);

            return executionResponse;
        }
    }
}

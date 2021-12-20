using Nebula.Meta;
using System;

namespace GraphClientExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            connection = null;
            try
            {
                connection = getConnection();
                AuthResult authResult = connection.authenticate(userName, password);
                return new Session(connection, authResult, this, reconnect);
            }
            catch (Exception e)
            {
                // if get the connection succeeded, but authenticate failed,
                // needs to return connection to pool
                if (connection != null)
                {
                    setInvalidateConnection(connection);
                }
                throw e;
            }
            Session session;
            session =
            NebulaPool pool = new NebulaPool();
            Console.WriteLine("Hello World!");
        }
    }
}
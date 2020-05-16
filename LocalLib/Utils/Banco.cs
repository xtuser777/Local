using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace LocalLib.Utils
{
    public class Banco
    {
        private static Banco _instance;
        private MySqlConnection _connection; 

        private Banco() {}

        public static Banco Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new Banco();
                }
                
                return _instance;
            }
        }

        public MySqlConnection Connection
        {
            get
            {
                if (_connection == null || _connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _connection = new MySqlConnection("server=localhost; User Id=scr; database=local; password=scr123globo");
                        _connection.Open();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        _connection = null;
                    }
                }

                return _connection;
            }
        }
    }
}
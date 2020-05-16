using System;

namespace LocalLib.Utils
{
    public class Banco
    {
        private static Banco _instance;

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
    }
}
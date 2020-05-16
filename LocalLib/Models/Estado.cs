using System;

namespace LocalLib.Models
{
    public class Estado
    {
        private int _id;
        private string _nome;
        private string _sigla;

        public Estado()
        {
            _id = 0;
            _nome = "";
            _sigla = "";
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Sigla { get => _sigla; set => _sigla = value; }
    }
}
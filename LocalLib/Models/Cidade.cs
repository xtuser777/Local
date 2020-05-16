using System;

namespace LocalLib.Models
{
    public class Cidade
    {
        private int _id;
        private string _nome;
        private Estado _estado;

        public Cidade()
        {
            Id = 0;
            Nome = "";
            Estado = null;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public Estado Estado { get => _estado; set => _estado = value; }
    }
}
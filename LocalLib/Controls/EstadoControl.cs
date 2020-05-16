using System;
using System.Collections.Generic;
using LocalLib.Models;
using LocalLib.Utils;

namespace LocalLib.Controls
{
    public class EstadoControl
    {
        public List<Estado> ObterTudo()
        {
            if (Banco.Instance.Connection == null) return new List<Estado>();
            List<Estado> estados = new Estado().FindAll();
            Banco.Instance.Connection.Close();

            return estados;
        }
    }
}
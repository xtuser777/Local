using System;
using System.Collections.Generic;
using LocalLib.Models;
using LocalLib.Utils;

namespace LocalLib.Controls
{
    public class CidadeControl
    {
        public List<Cidade> ObterPorEstado(int estado)
        {
            if (Banco.Instance.Connection == null) return new List<Cidade>();
            List<Cidade> cidades = new Cidade().FindByState(estado);
            Banco.Instance.Connection.Close();

            return cidades;
        }
    }
}
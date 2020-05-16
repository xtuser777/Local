using System;
using System.Collections.Generic;
using System.Data;
using LocalLib.Utils;
using MySql.Data.MySqlClient;

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

        public List<Cidade> FindByState(int state)
        {
            if (state <= 0) return new List<Cidade>();
            if (Banco.Instance.Connection == null) return new List<Cidade>();
            string sql = @"
                select e.est_id,e.est_nome,e.est_sigla,
                       c.cid_id,c.cid_nome
                from cidade c
                inner join estado e on e.est_id = c.est_id
                where c.est_id = @state
                order by c.cid_id;
            ";
            MySqlCommand cmd = new MySqlCommand(sql, Banco.Instance.Connection);
            cmd.Parameters.AddWithValue("@state", state);
            DataTable table = new DataTable();
            try
            {
                table.Load(cmd.ExecuteReader());
                if (table.Rows.Count <= 0) return new List<Cidade>();
                List<Cidade> cidades = new List<Cidade>();
                foreach (DataRow row in table.Rows)
                {
                    cidades.Add(
                        new Cidade()
                        {
                            Id = Convert.ToInt32(row["cid_id"]),
                            Nome = row["cid_nome"].ToString(),
                            Estado = new Estado()
                            {
                                Id = Convert.ToInt32(row["est_id"]),
                                Nome = row["est_nome"].ToString(),
                                Sigla = row["est_sigla"].ToString()
                            }
                        }
                    );
                }

                return cidades;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Cidade>();
            }
        }
    }
}
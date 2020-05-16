using System;
using System.Collections.Generic;
using System.Data;
using LocalLib.Utils;
using MySql.Data.MySqlClient;

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

        public List<Estado> FindAll()
        {
            if (Banco.Instance.Connection == null) return new List<Estado>();
            string sql = @"
                select est_id,est_nome,est_sigla
                from estado
                order by est_id;
            ";
            MySqlCommand cmd = new MySqlCommand(sql, Banco.Instance.Connection);
            DataTable table = new DataTable();
            try
            {
                table.Load(cmd.ExecuteReader());
                if (table.Rows.Count <= 0) return new List<Estado>();
                List<Estado> estados = new List<Estado>();
                foreach (DataRow row in table.Rows)
                {
                    estados.Add(
                        new Estado()
                        {
                            Id = Convert.ToInt32(row["est_id"]),
                            Nome = row["est_nome"].ToString(),
                            Sigla = row["est_sigla"].ToString()
                        }
                    );
                }

                return estados;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using AgendaWebApplication.Models;

namespace AgendaWebApplication.Repository
{
    public class PessoaRepository
    {
        private SqlConnection _conn;

        public void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _conn = new SqlConnection();
        }

        public bool AddPessoa(Pessoa pessoa)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AddPessoa", _conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nomePessoa",pessoa.nomePessoa);
                command.Parameters.AddWithValue("@telefonePessoa", pessoa.telefonePessoa);
                command.Parameters.AddWithValue("@emailPessoa", pessoa.emailPessoa);

                _conn.Open();
                i = command.ExecuteNonQuery();
            }
            _conn.Close();
            return i >= i;
        }

        public List<Pessoa> ListPessoa()
        {
            Connection();

            List<Pessoa> pessoaList = new List<Pessoa>();

            using (SqlCommand command = new SqlCommand("ListPessoa", _conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                _conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pessoa pessoa = new Pessoa() 
                    { 
                        idPessoa = Convert.ToInt32(reader["idPessoa"]),
                        nomePessoa = Convert.ToString(reader["nomePessoa"]),
                        telefonePessoa = Convert.ToString(reader["telefonePessoa"]),
                        emailPessoa = Convert.ToString(reader["emailPessoa"])
                    };

                    pessoaList.Add(pessoa); 
                }

                _conn.Close();
                return pessoaList;
            }
        }

        public bool UpdatePessoa(Pessoa pessoa)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("UpdatePessoa", _conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idPessoa", pessoa.idPessoa);
                command.Parameters.AddWithValue("@nomePessoa", pessoa.nomePessoa);
                command.Parameters.AddWithValue("@telefonePessoa", pessoa.telefonePessoa);
                command.Parameters.AddWithValue("@emailPessoa", pessoa.emailPessoa);

                _conn.Open();
                i = command.ExecuteNonQuery();
            }
            _conn.Close();
            return i >= i;
        }
        
        public bool DeletePessoa(int idPessoa)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("DeletePessoaById", _conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idPessoa", idPessoa);
               
                _conn.Open();
                i = command.ExecuteNonQuery();
            }
            _conn.Close();

            if(i >= i)
            {
                return true;
            }

            return false;
        }

    }

}
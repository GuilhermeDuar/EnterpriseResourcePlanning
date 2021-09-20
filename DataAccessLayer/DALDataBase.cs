using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALDataBase
    {
        public string Register(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\DALDataBase.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                                 @"INSERT INTO CLIENTES (NOME, CPF, EMAIL, DATA_DE_NASCIMENTO, ESTADO_CIVIL, GENERO, TELEFONE_CELULAR, RUA, NUMERO, BAIRRO, CEP, COMPLEMENTO, CIDADE, UF) VALUES
                (@NOME, @CPF, @EMAIL, @DATA_DE_NASCIMENTO, @ESTADO_CIVIL, @GENERO, @TELEFONE_CELULAR, @RUA, @NUMERO, @BAIRRO, @CEP, @COMPLEMENTO, @CIDADE, @UF)";

                command.Parameters.AddWithValue("@NOME", cliente.Nome);
                command.Parameters.AddWithValue("@CPF", cliente.CPF);
                command.Parameters.AddWithValue("@EMAIL", cliente.Email);
                command.Parameters.AddWithValue("@DATA_DE_NASCIMENTO", cliente.DataDeNascimento);
                command.Parameters.AddWithValue("@ESTADO_CIVIL", cliente.EstadoCivil);
                command.Parameters.AddWithValue("@GENERO", cliente.Genero);
                command.Parameters.AddWithValue("@TELEFONE_CELULAR", cliente.TelefoneCelular);
                command.Parameters.AddWithValue("@RUA", cliente.Rua);
                command.Parameters.AddWithValue("@NUMERO", cliente.Numero);
                command.Parameters.AddWithValue("@BAIRRO", cliente.Bairro);
                command.Parameters.AddWithValue("@CEP", cliente.CEP);
                command.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
                command.Parameters.AddWithValue("@CIDADE", cliente.Cidade);
                command.Parameters.AddWithValue("@UF", cliente.UF);
                command.Connection = connection;
                try
                {
                    connection.Open();
                    command.ExecuteScalar();
                    return "Cadastro efetuado com sucesso!";
                }
                catch (Exception cEx)
                {
                    return "(Erro) - Não foi possível efetuar o cadastro";
                }
            }
        }
    }
}

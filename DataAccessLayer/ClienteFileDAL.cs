using Entities;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClienteFileDAL 
    { 

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            string diretorioCliente = Directory.GetCurrentDirectory();
            string[] arquivos = Directory.GetFiles(diretorioCliente);

            for (int i = 0; i < arquivos.Length; i++)
            {
                string nomeArquivo = arquivos[i];
                if (nomeArquivo.Contains(".txt"))
                {
                    Cliente c = GetClienteByLinhasArquivos(nomeArquivo);
                    clientes.Add(c);
                }
            }
            return clientes;
        }

        private Cliente GetClienteByLinhasArquivos(string nomeArquivo)
        {
            string[] linhasDoArquivo = File.ReadAllLines(nomeArquivo);
            Cliente c = new Cliente();
            c.Nome = linhasDoArquivo[0];
            c.CPF = linhasDoArquivo[1];
            c.Email = linhasDoArquivo[2];
            c.DataDeNascimento = DateTime.Parse(linhasDoArquivo[3]);
            c.Cidade = linhasDoArquivo[4];
            c.UF = linhasDoArquivo[5];
            c.Rua = linhasDoArquivo[6];
            c.Bairro = linhasDoArquivo[7];
            c.CEP = linhasDoArquivo[8];
            c.Complemento = linhasDoArquivo[9];
            c.Numero = linhasDoArquivo[10];
            c.TelefoneCelular = linhasDoArquivo[11];
            c.EstadoCivil = (EstadoCivil)int.Parse(linhasDoArquivo[12]);
            c.Genero = (Genero)int.Parse(linhasDoArquivo[13]);
            return c;
        }
    
        public string Cadastrar(Cliente cliente)
        {
            try
            {
                //Dentro do bloco try, botamos todas as linhas que podem
                //disparar exceptions!
                File.WriteAllText(cliente.CPF + ".txt", cliente.ToString());
                return "Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                //Se exceptions forem disparadas, o bloco catch é executado e 
                //a variável "ex" ganha os detalhes desta exception, podendo
                //escrever a mensagem da exception em um log de erro.
                File.AppendAllText("log.txt", ex.Message + " às " + DateTime.Now);
                return "Sistema encontrou erros. Contate o administrador.";
            }
        }
        

        public bool Exists(Cliente cliente)
        {
            return File.Exists(cliente.CPF + ".txt");
        }
    }
}

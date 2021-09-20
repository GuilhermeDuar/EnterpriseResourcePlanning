using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ClienteBusinessValidator
    {
        public string Cadastrar (Cliente cliente) 
        {
            ClienteFileDAL clienteDAL = new ClienteFileDAL();
            
            string erros = "";

            cliente.Nome = Normatization.NormatizeString(cliente.Nome);
            erros += CommonValidations.IsValidNome(cliente.Nome);

            erros += CommonValidations.IsEmail(cliente.Email, true);

            cliente.CPF = cliente.CPF?.Trim().Replace("-", "").Replace(".", "");
            string errosCPF = CommonValidations.IsCPF(cliente.CPF);
            if (errosCPF == "" && clienteDAL.Exists(cliente))
            {
                errosCPF = "Cliente já cadastrado. \r\n";
            }
            erros += errosCPF;

            cliente.Rua = Normatization.NormatizeString(cliente.Rua);
            erros += CommonValidations.IsValidRua(cliente.Rua);

            cliente.Cidade = Normatization.NormatizeString(cliente.Cidade);
            erros += CommonValidations.IsValidCidadeUF(cliente.UF, cliente.Cidade);

            //cliente.UF = Normatization.NormatizeString(cliente.UF);
            //erros += CommonValidations.IsValidUF(cliente.UF);

            cliente.Bairro = Normatization.NormatizeString(cliente.Bairro);
            erros += CommonValidations.IsValidBairro(cliente.Bairro);

            cliente.Complemento = Normatization.NormatizeString(cliente.Complemento);
            erros += CommonValidations.IsValidComplementoNumero(cliente.Complemento, cliente.Numero);

            cliente.CEP = cliente.CEP?.Trim().Replace("-", "");
            erros += CommonValidations.IsValidCEP(cliente.CEP);

            cliente.TelefoneCelular = Normatization.NormatizeString(cliente.TelefoneCelular);
            erros += CommonValidations.IsValidTelefoneCelular(cliente.TelefoneCelular);

            //cliente.EstadoCivil = Normatization.NormatizeString(cliente.EstadoCivil);
            //erros += CommonValidations.IsValidEstadoCivil(cliente.EstadoCivil);

            //cliente.Genero = Normatization.NormatizeString(cliente.Genero);
            //erros += CommonValidations.IsValidGenero(cliente.Genero);

            erros += CommonValidations.IsValidAge(cliente.DataDeNascimento);

            if (erros != "")
            {
                return erros;
            }

            return clienteDAL.Cadastrar(cliente);
        }
        public List<Cliente> GetAllClientes()
        {
            ClienteFileDAL fileDal = new ClienteFileDAL();
            List<Cliente> clientes = fileDal.GetAllClientes();
            for (int i = 0; i < clientes.Count; i++)
            {
                clientes[i].CPF = clientes[i].CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                clientes[i].CEP = clientes[i].CEP.Insert(5, "-");
            }
            return clientes;
        }
    }
}

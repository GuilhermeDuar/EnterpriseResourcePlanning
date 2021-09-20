using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cliente
    {
        //public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string TelefoneCelular { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Genero Genero { get; set; }

        public override string ToString()
        {
            return Nome + "\r\n" +
                   CPF + "\r\n" +
                   Email + "\r\n" +
                   DataDeNascimento + "\r\n" +
                   Cidade + "\r\n" +
                   UF + "\r\n" +
                   Rua + "\r\n" +
                   Bairro + "\r\n" +
                   CEP + "\r\n" +
                   Complemento + "\r\n" +
                   Numero + "\r\n" +
                   TelefoneCelular + "\r\n" +
                   EstadoCivil + "\r\n" +
                   (int)Genero + "\r\n;";
        }
    }
}

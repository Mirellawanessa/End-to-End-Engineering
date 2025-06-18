using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaHospedagem.Models
{
     public class Pessoa
    {
        public Pessoa() { }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public required string Nome { get; set; } 
        public required string Sobrenome { get; set; } 
        public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
    }
}
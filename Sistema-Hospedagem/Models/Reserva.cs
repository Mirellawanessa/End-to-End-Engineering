using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaHospedagem.Models
{
    public class Reserva
    {
        
        public List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();

        
        public Suite? Suite { get; set; }

        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(Suite suite, int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new Exception("A suíte deve ser cadastrada antes de adicionar os hóspedes.");
            }

            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade da suíte é menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public (decimal valorFinal, bool descontoAplicado) CalcularValorDiaria()
{
    
    if (Suite == null)
    {
        throw new Exception("A suíte não foi cadastrada.");
    }

    
    decimal valor = DiasReservados * Suite.ValorDiaria;
    bool descontoAplicado = false;

    
    if (DiasReservados >= 10)
    {
        valor -= valor * 0.10m; 
        descontoAplicado = true;
    }

    
    return (valor, descontoAplicado);
}


    }
}
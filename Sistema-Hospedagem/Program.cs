using System.Text;
using SistemaHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;


List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa { Nome = "Hóspede", Sobrenome = "1" };
Pessoa p2 = new Pessoa { Nome = "Hóspede", Sobrenome = "2" };




Suite suite = new Suite
{
    TipoSuite = "Premium",
    Capacidade = 2,
    ValorDiaria = 30
};

hospedes.Add(p1);
hospedes.Add(p2);

Reserva reserva = new Reserva(suite, 15);  
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);


var (valorDiaria, descontoAplicado) = reserva.CalcularValorDiaria();

Console.WriteLine($"Suite: {suite.TipoSuite}");
Console.WriteLine($"Capacidade da suíte: {suite.Capacidade}");



Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");


Console.WriteLine($"Valor diária: {valorDiaria:C}");


if (descontoAplicado)
{
    Console.WriteLine("Você recebeu um desconto de 10% para estadias de 10 dias ou mais!");
}
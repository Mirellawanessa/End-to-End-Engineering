using System;
using SistemaDeEstacionamento.Models;

double precoInicial = 0;
double precoPorHora;
int opcao;
bool exibirmenu = true;


Console.WriteLine("Bem vindo ao sistema de estacionamento!");
Console.WriteLine("-------------------------------------- ");
Console.WriteLine("Digite o preço da hora:");


precoPorHora = double.Parse(Console.ReadLine());
Console.WriteLine(" ");

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

while(exibirmenu){
Console.WriteLine("         MENU:          ");
Console.WriteLine("------------------------");
Console.WriteLine("1 - Estacionar Veículos");
Console.WriteLine("2 - Remover Veículo");
Console.WriteLine("3 - Listar veículos");
Console.WriteLine("4 - Sair");

opcao = int.Parse(Console.ReadLine());

switch (opcao){
        
        case 1:
          es.AdicionarVeiculo();
        break;

        case 2:
            es.RemoverVeiculo();
        break;

        case 3:
          es.ListarVeiculos();
        break;
        
        case 4:
        exibirmenu = false;
        Console.WriteLine("Saindo...");
        break;
        default:

        break;

}

}



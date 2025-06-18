using System.Collections.Generic;
using System;

namespace SistemaDeEstacionamento.Models{


public class Estacionamento{


    private double precoInicial = 0;
    private double precoPorHora = 0;

    private List<string> veiculos = new List<string>();

    public Estacionamento(double precoInicial, double precoPorhora){
          this.precoInicial = precoInicial;

          this.precoPorHora = precoPorhora;
    }


   public void AdicionarVeiculo(){
         
         string placa;
         Console.WriteLine("Digite a placa do veículo para estacionar:");
         Console.WriteLine("----------------------------------------- ");
         placa = Console.ReadLine();
         veiculos.Add(placa);
         Console.WriteLine(" ");
         Console.WriteLine("Veículo Adicionado com sucesso!!");
         Console.WriteLine(" ");

   }


  public void RemoverVeiculo(){
        Console.WriteLine("Digite a placa do veículo para remover:");
        string placa = Console.ReadLine();

    if (veiculos.Contains(placa))
    {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
        double horas;
        horas = double.Parse(Console.ReadLine());

         
        double valorTotal = precoPorHora * horas;
            veiculos.Remove(placa);
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            Console.WriteLine(" ");
    }
    else
    {
        Console.WriteLine(" ");
        Console.WriteLine("Desculpe, este veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
        Console.WriteLine(" ");
    }


  }

 public void ListarVeiculos(){
    
    if (veiculos.Any()){
       
       Console.WriteLine("Os Veículos Estacionados são:");

       for (int i = 0; i < veiculos.Count; i++){

        Console.WriteLine(veiculos[i]);
       }

        Console.WriteLine(" ");
    }

    else {

        Console.WriteLine(" Ainda não há veículos estacionados. ");
        Console.WriteLine(" ");
    }



 }



















}















}
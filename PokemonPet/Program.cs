using Newtonsoft.Json;
using Pokemon;
using PokemonPet.Atendimento;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

class program
{
    static void Main(string[] args)
    {
        AtendimentoPokemon atendimento = new AtendimentoPokemon();
        #region
        //    int num = 0;
        //    while (num != 4)
        //    {

        //        Console.WriteLine("=======================================");
        //        Console.WriteLine("=Bem vindo ao centro de adoção Pokemon=");
        //        Console.WriteLine("=======================================");
        //        Console.WriteLine("\n");

        //        Console.WriteLine("Por favor informe em numeros a geração que deseja adotar \n (Temos disponíveis gerações de 1 a 3, digite 4 para sair)");
        //        num = int.Parse(Console.ReadLine());
        //        if (num < 1 || num > 4)
        //        {
        //            Console.WriteLine("Numero inválido, digite um numero de 1 a 3");
        //        }
        //        else
        //        {
        //            switch (num)
        //            {
        //                case 1:
        //                    PrimeiraGeracao();
        //                    break;
        //                case 2:
        //                    SegundaGeracao();
        //                    break;
        //                case 3:
        //                    TerceiraGeracao();
        //                    break;
        //                case 4:
        //                    Console.WriteLine("...Saindo do sistema");
        //                    Console.ReadKey();
        //                    break;
        //            }
        //        }
        //    }


        //    Console.ReadKey();
        //}

        //private static void TerceiraGeracao()
        //{
        //    HttpClient client = new HttpClient();
        //    var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon/?offset=251&limit=12").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        var listPokemon = JsonConvert.DeserializeObject<PokemonListModel>(result);
        //        Console.Clear();
        //        Console.WriteLine("==============================================");
        //        Console.WriteLine("== Obrigado por escolher a terceira Geração ==");
        //        Console.WriteLine("=== Temos os seguintes Pokemons disponíveis ==");
        //        Console.WriteLine("==============================================");
        //        for (int i = 0; i < listPokemon.Results.Count; i++)
        //        {
        //            Console.WriteLine($"Pokemon número {i+1}: {listPokemon.Results[i].Name}");
        //        }
        //        Console.WriteLine("\n");
        //        Console.WriteLine("Qual deseja escolher?");
        //        int num = int.Parse(Console.ReadLine());
        //        for (int i = 0; i < listPokemon.Results.Count; i++)
        //        {
        //            if (listPokemon.Results[i].Name == listPokemon.Results[num - 1].Name)
        //            {
        //                HttpClient client2 = new HttpClient();
        //                var response2 = client2.GetAsync($"{listPokemon.Results[i].Url}").Result;
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var resultPokemon = response2.Content.ReadAsStringAsync().Result;
        //                    var pokemonObject = JsonConvert.DeserializeObject<PokemonMascote>(resultPokemon);
        //                    AdotarPokemon(pokemonObject);

        //                }
        //            }
        //        }
        //    }
        //}

        //private static void SegundaGeracao()
        //{
        //    HttpClient client = new HttpClient();
        //    var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon/?offset=151&limit=12").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        var listPokemon = JsonConvert.DeserializeObject<PokemonListModel>(result);
        //        Console.Clear();
        //        Console.WriteLine("==============================================");
        //        Console.WriteLine("== Obrigado por escolher a segunda Geração ==");
        //        Console.WriteLine("=== Temos os seguintes Pokemons disponíveis ==");
        //        Console.WriteLine("==============================================");
        //        for (int i = 0; i < listPokemon.Results.Count; i++)
        //        {
        //            Console.WriteLine($"Pokemon número {i+1}: {listPokemon.Results[i].Name}");
        //        }
        //        Console.WriteLine("\n");
        //        Console.WriteLine("Qual deseja escolher?");
        //        int num = int.Parse(Console.ReadLine());
        //        for (int i = 0; i < listPokemon.Results.Count; i++)
        //        {
        //            if (listPokemon.Results[i].Name == listPokemon.Results[num - 1].Name)
        //            {
        //                HttpClient client2 = new HttpClient();
        //                var response2 = client2.GetAsync($"{listPokemon.Results[i].Url}").Result;
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var resultPokemon = response2.Content.ReadAsStringAsync().Result;
        //                    var pokemonObject = JsonConvert.DeserializeObject<PokemonMascote>(resultPokemon);
        //                    AdotarPokemon(pokemonObject);

        //                }
        //            }
        //        }
        //    }

        //}

        //public static void PrimeiraGeracao()
        //{
        //    HttpClient client = new HttpClient();
        //    var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=12").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        var listPokemon = JsonConvert.DeserializeObject<PokemonListModel>(result);
        //        Console.Clear();
        //        Console.WriteLine("==============================================");
        //        Console.WriteLine("== Obrigado por escolher a primeira Geração ==");
        //        Console.WriteLine("=== Temos os seguintes Pokemons disponíveis ==");
        //        Console.WriteLine("==============================================");
        //        for (int i = 0; i < listPokemon.Results.Count; i++)
        //        {
        //            Console.WriteLine($"Pokemon número {i+1}: {listPokemon.Results[i].Name}");
        //        }
        //        Console.WriteLine("\n");
        //        Console.WriteLine("Qual deseja escolher?");
        //        int num = int.Parse(Console.ReadLine());
        //        for (int i = 0; i < listPokemon.Results.Count; i++)
        //        {
        //            if (listPokemon.Results[i].Name == listPokemon.Results[num-1].Name)
        //            {
        //                HttpClient client2 = new HttpClient();
        //                var response2 = client2.GetAsync($"{listPokemon.Results[i].Url}").Result;
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var resultPokemon = response2.Content.ReadAsStringAsync().Result;
        //                    var pokemonObject = JsonConvert.DeserializeObject<PokemonMascote>(resultPokemon);
        //                    AdotarPokemon(pokemonObject);

        //                }
        //            }
        //        }

        //    }

        //}
        //public static void AdotarPokemon(PokemonMascote pokemon)
        //{
        //    Console.Clear();
        //    PokemonMascote pokemonEscolhido = new PokemonMascote();
        //    pokemonEscolhido.Name = pokemon.Name;
        //    pokemonEscolhido.Types = pokemon.Types;
        //    pokemonEscolhido.Weight = pokemon.Weight;
        //    pokemonEscolhido.Height = pokemon.Height;
        //    pokemonEscolhido.Abilities = pokemon.Abilities;
        //    Console.WriteLine("--------------------------------------");
        //    Console.WriteLine("Características do Pokemon escolhido: ");
        //    Console.WriteLine("--------------------------------------");
        //    Console.WriteLine("---------------- Nome ----------------");
        //    Console.WriteLine(pokemonEscolhido.Name);
        //    Console.WriteLine("---------------- Tipo ----------------");
        //    foreach(var tipos in pokemonEscolhido.Types)
        //    {
        //        Console.WriteLine(tipos.Type.Name);
        //    }

        //    Console.WriteLine("---------------- Peso ----------------");
        //    Console.WriteLine(pokemonEscolhido.Weight);
        //    Console.WriteLine("--------------- Altura ---------------");
        //    Console.WriteLine(pokemonEscolhido.Height);
        //    Console.WriteLine("------------- Habilidades ------------");
        //    foreach (var habilidades in pokemonEscolhido.Abilities)
        //    {
        //        Console.WriteLine(habilidades.AbilityAbility.Name);
        //    }

        //}
        #endregion
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("\n");
        Console.WriteLine(" ######   #####   ###  ##  ######   ##   ##   #####   ##   ##");
        Console.WriteLine(" ##  ##  ##   ##   ##  ##   ##   #  ### ###  ##   ##  ###  ##");
        Console.WriteLine(" ##  ##  ##   ##   ## ##    ## #    #######  ##   ##  #### ##");
        Console.WriteLine(" #####   ##   ##   ####     ####    #######  ##   ##  ## ####");
        Console.WriteLine("  ##     ##   ##   ## ##    ## #    ## # ##  ##   ##  ##  ###");
        Console.WriteLine(" ####     #####   ###  ##  #######  ##   ##   #####   ##   ##");
        Console.WriteLine("\n");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Bem vindo ao centro de adoção Pokemon!");
        Console.WriteLine("Qual seu nome?");
        string nome = Console.ReadLine();
        int numAtendimento = 0;
        while (numAtendimento != 3)
        {
            Console.WriteLine("---------------------------- MENU ----------------------------");
            Console.WriteLine($"Olá {nome}! O que deseja?");
            Console.WriteLine("1 - Adotar um Pokemon");
            Console.WriteLine("2 - Ver seus Pokemons");
            Console.WriteLine("3 - Sair");
            numAtendimento = int.Parse(Console.ReadLine());

            switch (numAtendimento)
            {
                case 1:
                    atendimento.Adocao();
                    break;
                case 2:
                    atendimento.VerPokemons();
                    break;
                case 3:
                    Console.WriteLine("Saindo do sistema...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção não implementada");
                    break;
            }
        }

    }
}
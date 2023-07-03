using Newtonsoft.Json;
using Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPet.Atendimento
{
    public class AtendimentoPokemon
    {
        public List<PokemonMascote> _listaDosSeusPokemons = new List<PokemonMascote>
        {

        };

        public void Adocao()
        {
            Console.Clear();
            int num = 0;
            Console.WriteLine("Por favor informe em numeros a geração que deseja adotar \n (Temos disponíveis gerações de 1 a 3, digite 4 para sair)");
            num = int.Parse(Console.ReadLine());
            if (num < 1 || num > 3)
            {
                Console.WriteLine("Numero inválido, digite um numero de 1 a 3");
            }
            else
            {
                switch (num)
                {
                    case 1:
                        PrimeiraGeracao();
                        break;
                    case 2:
                        SegundaGeracao();
                        break;
                    case 3:
                        TerceiraGeracao();
                        break;
                }
            }


            Console.ReadKey();
        }

        private void TerceiraGeracao()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon/?offset=251&limit=12").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var listPokemon = JsonConvert.DeserializeObject<PokemonListModel>(result);
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("== Obrigado por escolher a terceira Geração ==");
                Console.WriteLine("=== Temos os seguintes Pokemons disponíveis ==");
                Console.WriteLine("==============================================");
                for (int i = 0; i < listPokemon.Results.Count; i++)
                {
                    Console.WriteLine($"Pokemon número {i + 1}: {listPokemon.Results[i].Name}");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Qual deseja escolher?");
                int num = int.Parse(Console.ReadLine());
                for (int i = 0; i < listPokemon.Results.Count; i++)
                {
                    if (listPokemon.Results[i].Name == listPokemon.Results[num - 1].Name)
                    {
                        HttpClient client2 = new HttpClient();
                        var response2 = client2.GetAsync($"{listPokemon.Results[i].Url}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var resultPokemon = response2.Content.ReadAsStringAsync().Result;
                            var pokemonObject = JsonConvert.DeserializeObject<PokemonMascote>(resultPokemon);
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("Características do Pokemon: ");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("---------------- Nome ----------------");
                            Console.WriteLine(pokemonObject.Name);
                            Console.WriteLine("---------------- Tipo ----------------");
                            foreach (var tipos in pokemonObject.Types)
                            {
                                Console.WriteLine(tipos.Type.Name);
                            }

                            Console.WriteLine("---------------- Peso ----------------");
                            Console.WriteLine(pokemonObject.Weight);
                            Console.WriteLine("--------------- Altura ---------------");
                            Console.WriteLine(pokemonObject.Height);
                            Console.WriteLine("------------- Habilidades ------------");
                            foreach (var habilidades in pokemonObject.Abilities)
                            {
                                Console.WriteLine(habilidades.AbilityAbility.Name);
                            }
                            Console.WriteLine("Quer adotar esse pokemon? responda com sim ou não");
                            string resposta = Console.ReadLine();
                            if (resposta == "sim")
                            {
                                AdotarPokemon(pokemonObject);
                            }
                            else
                            {
                                Console.WriteLine("Voltando para tela inicial");
                                Adocao();
                            }

                        }
                    }
                }
            }
        }

        private void SegundaGeracao()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon/?offset=151&limit=12").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var listPokemon = JsonConvert.DeserializeObject<PokemonListModel>(result);
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("== Obrigado por escolher a segunda Geração ==");
                Console.WriteLine("=== Temos os seguintes Pokemons disponíveis ==");
                Console.WriteLine("==============================================");
                for (int i = 0; i < listPokemon.Results.Count; i++)
                {
                    Console.WriteLine($"Pokemon número {i + 1}: {listPokemon.Results[i].Name}");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Qual deseja escolher?");
                int num = int.Parse(Console.ReadLine());
                for (int i = 0; i < listPokemon.Results.Count; i++)
                {
                    if (listPokemon.Results[i].Name == listPokemon.Results[num - 1].Name)
                    {
                        HttpClient client2 = new HttpClient();
                        var response2 = client2.GetAsync($"{listPokemon.Results[i].Url}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var resultPokemon = response2.Content.ReadAsStringAsync().Result;
                            var pokemonObject = JsonConvert.DeserializeObject<PokemonMascote>(resultPokemon);
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("Características do Pokemon: ");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("---------------- Nome ----------------");
                            Console.WriteLine(pokemonObject.Name);
                            Console.WriteLine("---------------- Tipo ----------------");
                            foreach (var tipos in pokemonObject.Types)
                            {
                                Console.WriteLine(tipos.Type.Name);
                            }

                            Console.WriteLine("---------------- Peso ----------------");
                            Console.WriteLine(pokemonObject.Weight);
                            Console.WriteLine("--------------- Altura ---------------");
                            Console.WriteLine(pokemonObject.Height);
                            Console.WriteLine("------------- Habilidades ------------");
                            foreach (var habilidades in pokemonObject.Abilities)
                            {
                                Console.WriteLine(habilidades.AbilityAbility.Name);
                            }
                            Console.WriteLine("Quer adotar esse pokemon? responda com sim ou não");
                            string resposta = Console.ReadLine();
                            if (resposta == "sim")
                            {
                                AdotarPokemon(pokemonObject);
                            }
                            else
                            {
                                Console.WriteLine("Voltando para tela inicial");
                                Adocao();
                            }
                        }
                    }
                }
            }

        }

        public void PrimeiraGeracao()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=12").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var listPokemon = JsonConvert.DeserializeObject<PokemonListModel>(result);
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("== Obrigado por escolher a primeira Geração ==");
                Console.WriteLine("=== Temos os seguintes Pokemons disponíveis ==");
                Console.WriteLine("==============================================");
                for (int i = 0; i < listPokemon.Results.Count; i++)
                {
                    Console.WriteLine($"Pokemon número {i + 1}: {listPokemon.Results[i].Name}");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Qual deseja escolher?");
                int num = int.Parse(Console.ReadLine());
                for (int i = 0; i < listPokemon.Results.Count; i++)
                {
                    if (listPokemon.Results[i].Name == listPokemon.Results[num - 1].Name)
                    {
                        HttpClient client2 = new HttpClient();
                        var response2 = client2.GetAsync($"{listPokemon.Results[i].Url}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var resultPokemon = response2.Content.ReadAsStringAsync().Result;
                            var pokemonObject = JsonConvert.DeserializeObject<PokemonMascote>(resultPokemon);
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("Características do Pokemon: ");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("---------------- Nome ----------------");
                            Console.WriteLine(pokemonObject.Name);
                            Console.WriteLine("---------------- Tipo ----------------");
                            foreach (var tipos in pokemonObject.Types)
                            {
                                Console.WriteLine(tipos.Type.Name);
                            }

                            Console.WriteLine("---------------- Peso ----------------");
                            Console.WriteLine(pokemonObject.Weight);
                            Console.WriteLine("--------------- Altura ---------------");
                            Console.WriteLine(pokemonObject.Height);
                            Console.WriteLine("------------- Habilidades ------------");
                            foreach (var habilidades in pokemonObject.Abilities)
                            {
                                Console.WriteLine(habilidades.AbilityAbility.Name);
                            }
                            Console.WriteLine("Quer adotar esse pokemon? responda com sim ou não");
                            string resposta = Console.ReadLine();
                            if (resposta == "sim")
                            {
                                AdotarPokemon(pokemonObject);
                            }
                            else
                            {
                                Console.WriteLine("Voltando para tela inicial");
                                Adocao();
                            }

                        }
                    }
                }

            }

        }
        public void AdotarPokemon(PokemonMascote pokemon)
        {
            Console.Clear();
            PokemonMascote pokemonEscolhido = new PokemonMascote();
            pokemonEscolhido.Name = pokemon.Name;
            pokemonEscolhido.Types = pokemon.Types;
            pokemonEscolhido.Weight = pokemon.Weight;
            pokemonEscolhido.Height = pokemon.Height;
            pokemonEscolhido.Abilities = pokemon.Abilities;
            _listaDosSeusPokemons.Add(pokemonEscolhido);

            Console.WriteLine("...Pokemon adicionado á sua lista com sucesso! O ovo está chocando: ");
            Console.WriteLine("          ████████");
            Console.WriteLine("        ██        ██");
            Console.WriteLine("      ██▒▒▒▒        ██ ");
            Console.WriteLine("    ██▒▒▒▒▒▒      ▒▒▒▒██ ");
            Console.WriteLine("    ██▒▒▒▒▒▒      ▒▒▒▒██");
            Console.WriteLine("  ██  ▒▒▒▒        ▒▒▒▒▒▒██ ");
            Console.WriteLine("  ██                ▒▒▒▒██  ");
            Console.WriteLine("██▒▒      ▒▒▒▒▒▒          ██ ");
            Console.WriteLine("██      ▒▒▒▒▒▒▒▒▒▒        ██   ");
            Console.WriteLine("██      ▒▒▒▒▒▒▒▒▒▒    ▒▒▒▒██ ");
            Console.WriteLine("██▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒██ ");
            Console.WriteLine("  ██▒▒▒▒  ▒▒▒▒▒▒    ▒▒▒▒██  ");
            Console.WriteLine("  ██▒▒▒▒            ▒▒▒▒██  ");
            Console.WriteLine("    ██▒▒              ██ ");
            Console.WriteLine("      ████        ████ ");
            Console.WriteLine("          ████████ ");

            Console.WriteLine("");
            Console.WriteLine("Voltando para tela inicial.");
        }
        public void VerPokemons()
        {
            if (_listaDosSeusPokemons.Count == 0)
            {
                Console.WriteLine("Não há dados para mostrar. Adote um Pokemon no Menu!");
            }
            else
            {
                foreach (PokemonMascote item in _listaDosSeusPokemons)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Características do Pokemon {item.Name}: ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Nome do Pokemon: {item.Name}");
                Console.WriteLine("---------------- Tipo(s) ----------------");
                foreach (var tipos in item.Types)
                {
                    Console.WriteLine(tipos.Type.Name);
                }

                Console.WriteLine("---------------- Peso ----------------");
                Console.WriteLine(item.Weight);
                Console.WriteLine("--------------- Altura ---------------");
                Console.WriteLine(item.Height);
                Console.WriteLine("------------- Habilidades ------------");
                foreach (var habilidades in item.Abilities)
                {
                    Console.WriteLine(habilidades.AbilityAbility.Name);
                }
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.ReadKey();
            }

        }

    }

}
}


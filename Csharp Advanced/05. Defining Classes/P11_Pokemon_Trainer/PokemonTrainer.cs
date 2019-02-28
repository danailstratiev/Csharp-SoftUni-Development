using System;
using System.Linq;
using System.Collections.Generic;


namespace P11_Pokemon_Trainer
{
    public class PokemonTrainer
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var allTrainers = new List<Trainer>();

            while (input != "Tournament")
            {
                //Pesho Charizard Fire 100

                var trainerData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var trainerName = trainerData[0];
                var pokemonName = trainerData[1];
                var element = trainerData[2];
                var health = int.Parse(trainerData[3]);

                var pokemon = new Pokemon(pokemonName, element, health);
                var currentTrainer = allTrainers.FirstOrDefault(x => x.Name == trainerName);

                if (currentTrainer == null)
                {
                    var pokemons = new List<Pokemon>();
                    currentTrainer = new Trainer(trainerName, pokemons);
                    allTrainers.Add(currentTrainer);
                }

                currentTrainer.Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            var battleElemet = Console.ReadLine();

            while (battleElemet != "End")
            {
                foreach (var trainer in allTrainers)
                {
                    var earnedBadgesPerRound = 0;

                    if (trainer.Pokemons.Any(x => x.Element == battleElemet))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                        }
                    }

                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                }

                battleElemet = Console.ReadLine();
            }

            foreach (var trainer in allTrainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}

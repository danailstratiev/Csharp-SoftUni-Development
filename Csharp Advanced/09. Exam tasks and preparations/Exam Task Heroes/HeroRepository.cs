using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            var heroToRemove = this.data.FirstOrDefault(x => x.Name == name);

            if (heroToRemove != null)
            {
                var index = this.data.IndexOf(heroToRemove);
                this.data.RemoveAt(index);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            var strongestHero = this.data[0];

            foreach (var hero in this.data)
            {
                if (hero.Item.Strength > strongestHero.Item.Strength)
                {
                    strongestHero = hero;
                }
            }

            return strongestHero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var mostSkilledHero = this.data[0];

            foreach (var hero in this.data)
            {
                if (hero.Item.Ability > mostSkilledHero.Item.Ability)
                {
                    mostSkilledHero = hero;
                }
            }

            return mostSkilledHero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var smartestHero = this.data[0];

            foreach (var hero in this.data)
            {
                if (hero.Item.Intelligence > smartestHero.Item.Intelligence)
                {
                    smartestHero = hero;
                }
            }

            return smartestHero;
        }

        public int Count => this.data.Count;

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.data);
        }
    }
}

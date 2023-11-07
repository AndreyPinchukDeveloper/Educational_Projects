using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooker.LINQ.GroupBY
{
    internal class GroupBY
    {
        IQueryable<Fruit> GetFruits()
        {
            return new List<Fruit>()
            {
                new Fruit { Id = 1, Description = "Tasty", Name="apple"},
                new Fruit { Id = 1, Description = "Spicy", Name="apricot"},
                new Fruit { Id = 1, Description = "Acidic", Name="avocado"},
                new Fruit { Id = 1, Description = "good", Name="banana"},
                new Fruit { Id = 1, Description = "Tasty", Name="grapefruit"},
                new Fruit { Id = 1, Description = "Acidic", Name="kiwi"},
                new Fruit { Id = 1, Description = "good", Name="lime"},
                new Fruit { Id = 1, Description = "Acidic", Name="lemon"},
            }.AsQueryable();
        }

        IQueryable<FruitType> GetFruitsType()
        {
            return new List<FruitType>()
            {
                new FruitType { Id = 1, Name="citruses"},
                new FruitType { Id = 1, Name="apples"},
                new FruitType { Id = 1, Name="berries"}
            }.AsQueryable();
        }

        private void DoQuery1()
        {
            var result =
                from fruits in GetFruits()
                join ftuitsTypes in GetFruitsType()
                    on fruits.Id equals ftuitsTypes.Id
                group fruits by new { fruits.Id, ftuitsTypes.Name };

            foreach (var fruit in result)
            {
                Console.WriteLine($"{fruit.Key.Name} | {fruit.Count()}");

                foreach (var item in fruit)
                {
                    Console.WriteLine($"\t{item.Name} - {item.Description}");
                }
            }
        }

        private void DoQuery2()
        {
            var result = GetFruits()
                .Join(GetFruitsType(),
                      fruits => fruits.Id,
                      fruitType => fruitType.Id,
                      (fruits, fruitType) => new {fruits, fruitType})
                .GroupBy(x => new { x.fruits.Id, x.fruitType.Name});

            foreach (var fruit in result)
            {
                Console.WriteLine($"{fruit.Key.Name} | {fruit.Count()}");
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatSim
{
    internal class Player
    {
        public List<string> Inventory { get; set; } = new List<string>();
        public Cat Cat { get; set; } = new Cat();
        public int Money { get; set; } = 10;
        public int Tiredness { get; set; } = 0;

        public void GoToWork()
        {
            Console.WriteLine("You went to work and earned $5");
            Money = Money + 5;
            Cat.Happiness = Cat.Happiness - 1;
            Cat.Hunger = Cat.Hunger + 1;
            Tiredness = Tiredness + 2;
        }

        public void PlayWithCat()
        {
            Cat.Hunger = Cat.Hunger + 1;
            Tiredness = Tiredness - 1;
            if (Inventory.Contains("Cat Toy, "))
            {
                Console.WriteLine("You used the Cat toy to play with " + Cat.Name);
                Cat.Happiness = Cat.Happiness + 3;
            }
            else
            {
                Console.WriteLine("You played with " + Cat.Name);
                Cat.Happiness = Cat.Happiness + 2;
            }
        }

        public void GoRest(string message)
        {
            Cat.Hunger = Cat.Hunger + 1;
            if (Inventory.Contains("Premium mattress, "))
            {
                Console.WriteLine(message + " on the Premium mattress");
                Tiredness = Tiredness - 4;
            }
            else
            {
                Console.WriteLine(message);
                Tiredness = Tiredness - 2;
            }
        }

        public void FeedCat()
        {
            Cat.Happiness = Cat.Happiness + 1;
            Tiredness = Tiredness - 1;
            if (Inventory.Contains("Gourmet Cat food, "))
            {
                Console.WriteLine("You fed " + Cat.Name + " with the Gourmet Cat food");
                Cat.Hunger = Cat.Hunger - 4;
            }
            else
            {
                Console.WriteLine("You fed " + Cat.Name);
                Cat.Hunger = Cat.Hunger - 2;
            }
        }

        public void GoToShop()
        {
            string playerChoice = "";
            int itemCost = 0;
            string shopInventory = "";

            do
            {
                Console.WriteLine("What would you like to buy?");
                Console.WriteLine(" 1 - Cat toy - $10 (Happiness + 1 when playing) \n 2 - Gourmet Cat food - $15 (Hunger - 2 when feeding) \n 3 - Premium mattress - $5 ( Tiredness - 3 when resting) \n 4 to leave");
                playerChoice = Console.ReadLine().ToLower();

                switch (playerChoice)
                {
                    case "1":
                        itemCost = 10;
                        shopInventory = "Cat Toy, ";
                        Console.WriteLine(AttemptPurchase(itemCost, shopInventory));
                        break;
                    case "2":
                        itemCost = 15;
                        shopInventory = "Gourmet Cat food, ";
                        Console.WriteLine(AttemptPurchase(itemCost, shopInventory));
                        break;
                    case "3":
                        itemCost = 5;
                        shopInventory = "Premium mattress, ";
                        Console.WriteLine(AttemptPurchase(itemCost, shopInventory));
                        break;
                    case "4":
                        break;
                }
            } while (playerChoice != "4");
        }

        public string AttemptPurchase(int itemCost, string shopInventory)
        {
            if (Inventory.Contains(shopInventory))
            {
                return "You already own this!";
            }

            if (Money - itemCost < 0)
            {
                return "You can't afford this!";
            }
            else
            {
                Money = Money - itemCost;
                Inventory.Add(shopInventory);
                return "You brought a " + shopInventory;
            }
        }
    }
}

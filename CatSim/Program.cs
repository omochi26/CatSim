namespace CatSim
{
    internal class Program
    {
        public static int gameTurn = 1;
        public static Player player = new Player();

        public static void Main(string[] args)
        {
            Console.WriteLine("Please name your cat!");
            player.Cat.Name = Console.ReadLine();

            Console.WriteLine("You will reach a game over if " + player.Cat.Name + "'s Happiness reaches 0 or Hunger reaches 5 or -5 \nyou will win after completing turn 10");
            Console.WriteLine("You will be unable to do any actions except Rest if your Tiredness reaches 5");

            while (player.Cat.IsAlive)
            {
                Console.WriteLine($"\n turn {gameTurn++}");
                Console.WriteLine($"Status \n Money = ${player.Money} \n Tiredness = {player.Tiredness} \n {player.Cat.Name}'s hunger = {player.Cat.Hunger} \n {player.Cat.Name}'s happiness = {player.Cat.Happiness} \n Inventory = {String.Join("", player.Inventory)}");
                Console.WriteLine("What would you like to do? \n W - Go to work (+$5, -1 hapiness, +1 hunger, +2 tiredness) " +
                    "\n P - Play with your cat (+2 hapiness, +1 hunger, +1 tiredness) \n R - Rest (+1 hunger, -2 tiredness) " +
                    "\n F - Feed your Cat (-2 hunger, +1 Tiredness) \n S - Go shopping (Does not progress a turn)");

                TakeTurn();

                CheckVictory();
            }
            Console.WriteLine("Game over!");
        }

        public static void TakeTurn()
        {
            string choice = "";
            choice = Console.ReadLine().ToLower();
            while (choice != "w" && choice != "p" && choice != "r" && choice != "f" && choice != "s")
            {
                Console.WriteLine("Please enter a valid choice");
                choice = Console.ReadLine().ToLower();
            }

            if (player.Tiredness >= 5)
            {
                player.GoRest("You're too tired to do anything and went to bed");
            }
            else
            {
                switch (choice)
                {
                    case "w":
                        player.GoToWork();
                        break;
                    case "p":
                        player.PlayWithCat();
                        break;
                    case "r":
                        player.GoRest("You decided to rest");
                        break;
                    case "f":
                        player.FeedCat();
                        break;
                    case "s":
                        player.GoToShop();
                        break;
                }
            }
        }

        public static void CheckVictory()
        {
            if (gameTurn == 11)
            {
                Console.WriteLine("You made it past turn 10 and won!, Press any input to continue playing or Q to quit");
                if (Console.ReadLine().ToLower() == "q")
                {
                    player.Cat.IsAlive = false;
                }
            }
        } 
    }
}
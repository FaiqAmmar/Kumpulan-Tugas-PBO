using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant
{
    using Main_Data;
    using System.Security.Cryptography.X509Certificates;

    class PickAgent : Agent, Action
    {
        public void SetAgentName()
        {
            Console.WriteLine("Choose your agent :");
            Console.WriteLine("1. Phoenix");
            Console.WriteLine("2. Jett");
            Console.WriteLine("3. Raze");
            Console.WriteLine("4. Chamber");
            Console.WriteLine("Pick 1/2/3/4");
            int NoAgent = int.Parse(Console.ReadLine());
            if (NoAgent == 1)
            {
                this.AgentName = "Phoenix";
            }
            else if (NoAgent == 2)
            {
                this.AgentName = "Jett";
            }
            else if (NoAgent == 3)
            {
                this.AgentName = "Raze";
            }
            else if (NoAgent == 4)
            {
                this.AgentName = "Chamber";
            }
            else
            {
                Console.WriteLine("Pick your agent, this game cannot run without it. Please restart");
            }
            Console.WriteLine($"You have choose {this.AgentName}");
        }
        public override void EntryLine()
        {
            Console.Clear();
            if (this.AgentName == "Phoenix")
            {
                Console.WriteLine("Just take a seat, I got this.");
            }
            else if (this.AgentName == "Jett")
            {
                Console.WriteLine("Cool. Let's go.");
            }
            else if (this.AgentName == "Raze")
            {
                Console.WriteLine("Yes, I'm pumped.");
            }
            else if (this.AgentName == "Chamber")
            {
                Console.WriteLine("You have good taste, my friend.");
            }
            else
            {
                Console.WriteLine("Pick your agent first before playing");
            }
        }
        public void GetAgentName()
        {
            Console.WriteLine($"\nYou have picked {this.AgentName} as your agent");
            Console.WriteLine($"HP : {this.hpfriend}");
        }
        public void WarmUp()
        {
            Console.WriteLine("\nPress any key to start");
            string start = Console.ReadLine();
            Console.Clear();
        }
        public void WarmUp(string enemy)
        {
            var random = new Random();
            var list = new List<string> { "Phoenix", "Jett", "Raze", "Chamber" };
            int index = random.Next(list.Count);
            this.EnemyAgent = list[index];
            Console.WriteLine("You're playing against " + enemy);
            Console.WriteLine($"\nYour enemy is : {EnemyAgent}");
            Console.WriteLine($"HP : {this.hpenemy}");
        }
        public void Shoot1(sbyte yourdamage)
        {
            var random = new Random();
            var list = new List<sbyte> { 0, 30, 60, 100 };
            sbyte index = (sbyte)random.Next(list.Count);
            yourdamage = list[index];
            this.hpenemy -= yourdamage;
            this.yourdamage = yourdamage;
        }
        public void Shoot2(sbyte enemydamage)
        {
            var random = new Random();
            var list = new List<sbyte> { 0, 30, 60, 100 };
            sbyte index = (sbyte)random.Next(list.Count);
            enemydamage = list[index];
            this.hpfriend -= enemydamage;
            this.enemydamage = enemydamage;
        }
        public void BattleStart()
        {
            Console.WriteLine("\nPress any key to Continue");
            string Continue = Console.ReadLine();
            Console.Clear();

            bool battle = true;
            while (battle == true)
            {
                Console.WriteLine($"Your {AgentName} HP : {hpfriend}");
                Console.WriteLine($"Enemy {EnemyAgent} HP : {hpenemy}");
                Console.WriteLine("\nIt's your turn");
                Console.WriteLine("Press any key to shoot");
                string shoot1 = Console.ReadLine();
                this.Shoot1(hpenemy);
                Console.WriteLine($"You did {yourdamage} damage");
                Console.WriteLine("\nPress any key to initiate enemy turn");
                string pause1 = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Your {AgentName} HP : {hpfriend}");
                Console.WriteLine($"Enemy {EnemyAgent} HP : {hpenemy}");
                Console.WriteLine("\nIt's enemy turn");
                Console.WriteLine("Press any key to continue");
                string shoot2 = Console.ReadLine();
                this.Shoot2(hpfriend);
                Console.WriteLine($"Your enemy did {enemydamage} damage");
                Console.WriteLine("\nPress any key to initiate your turn");
                string pause2 = Console.ReadLine();
                Console.Clear();
                var random = new Random();
                var test = new List<sbyte> { 1, 2, 3, 4 };
                sbyte index1 = (sbyte)random.Next(test.Count);
                sbyte ultimate = 1;
                if (ultimate == test[index1] && hpenemy > 0 && hpfriend > 0)
                {
                    Console.WriteLine("You can use your ultimate type this string below to use it");
                    var keyword = new List<string> { "Thrash", "Radiant", "Wingman", "Prime", "Headhunter" };
                    int index2 = random.Next(keyword.Count);
                    Console.WriteLine(keyword[index2]);
                    Console.WriteLine("Insert the string : ");
                    string answer = Console.ReadLine();
                    Console.Clear();
                    if (answer == keyword[index2])
                    {
                        battle = false;
                        Console.WriteLine("You've activated your ultimate!");
                        Console.WriteLine("You've won in style");
                    }
                    else
                    {
                        battle = false;
                        Console.WriteLine("You've failed to use your ultimate");
                        Console.WriteLine("Your enemy just 1 tap you");
                        Console.WriteLine("You've lost in style");
                        Console.WriteLine("GAME OVER");
                    }

                }
                else if (hpenemy <= 0 && hpfriend <= 0)
                {
                    Console.WriteLine("Over Time");
                    hpenemy = 100;
                    hpfriend = 100;
                    Console.WriteLine("Press anything to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (hpfriend <= 0)
                {
                    battle = false;
                    Console.WriteLine("Game Over LOL");
                }
                else if (hpenemy <= 0)
                {
                    battle = false;
                    Console.WriteLine("You win GG");
                }
            }

        }

    }
}
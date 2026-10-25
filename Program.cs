using System;
using System.Threading;

namespace BattleTurns
{
    class PersonalCharacter
    {
        static void Main(string[]args)
        {
            Random Lucky = new Random();

            Console.WriteLine("=== Battle Turns ====");
            Console.WriteLine();

            Console.WriteLine("Welcome to the Battle Turns! Before starting, let's create your character.");
            Console.WriteLine("What is his name?");
            string Name = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine("Great! Every Status is RANDOM (just not Life). Let's see your Lucky! (Wait for a moment...)");

            int Life = 100;
            int Attack = Lucky.Next(10, 25);
            int Defense = Lucky.Next(10, 25);
            int HitTaxe = 50;

            Thread.Sleep(3000);

            Console.WriteLine();
            Console.WriteLine($"Your CHARACTER is Ready! Your Life is: {Life}. Attack: {Attack}. Defense: {Defense}.");

            Console.WriteLine();
            Console.WriteLine("Your attack has a minimal chance for a Critical Hit! Your defense will protect you reducing the opponent's attack!");
            Console.WriteLine("But remender, has a minimal chance too when your attack don't hit your enemy! If, the Life reaches 0, you LOSE. (Loading...)");

            Thread.Sleep(15000);

            Console.WriteLine();
            Console.WriteLine("Let's BEGIN! (Wait a second....)");

            Thread.Sleep(3000);

            int EnemyLife = Lucky.Next(80, 100);
            int EnemyAttack = Lucky.Next(10, 25);
            int EnemyDefense = Lucky.Next(10, 25);

            Console.WriteLine();

            bool Turns = true;
            int Option;

            Console.WriteLine($"An Enemy approaches of you! Protect YOURSELF! What {Name} will do?");
            Console.WriteLine($"Enemy Stats - Life {EnemyLife}. Attack: {EnemyAttack}. Defense: {EnemyDefense}");

            Console.WriteLine();
            Console.WriteLine("1. Attack");
            Console.WriteLine();
            Console.WriteLine("2. Up chance of Critical Hit");
            Console.WriteLine();
            Console.WriteLine("3. Defense");
            Console.WriteLine();
            Console.WriteLine("4. Power Attack (Random)");

            while (Turns)
            {
                if (int.TryParse(Console.ReadLine(), out Option))
                {
                    switch (Option)
                    {
                        case 1:

                        Console.WriteLine();
                        Console.WriteLine($"{Name} Attack!");
                        Thread.Sleep(2000);

                        HitTaxe = Lucky.Next(1, 131);

                        if (HitTaxe <= 15)
                            {
                                Console.WriteLine($"{Name} have tried... But your enemy evades!");
                            }
                        else if (HitTaxe <= 100)
                            {
                                Console.WriteLine($"{Name} hit your enemy!");
                                EnemyLife = EnemyLife - Attack;
                            }
                        else if (HitTaxe >= 101)
                            {
                                Console.WriteLine($"{Name} attack with a Critical Hit!");
                                int CriticalHit = Lucky.Next(5, 10);
                                EnemyLife = EnemyLife - Attack;
                                EnemyLife = EnemyLife - CriticalHit;
                            }

                        Console.WriteLine();
                        Console.WriteLine($"{Name}'s enemy life is: {EnemyLife}.");
                        break;

                        case 2:

                        Console.WriteLine();
                        Console.WriteLine($"{Name} upgrade your chances to Critical Hit!");
                        int UpChances = Lucky.Next(1, 15);
                        HitTaxe = HitTaxe + UpChances;
                        break;

                        case 3:

                        Console.WriteLine();
                        Console.WriteLine($"{Name}'s defense has been Increased!");
                        int UpDefense = Lucky.Next(1, 15);
                        Defense = Defense + UpDefense;
                        break;

                        case 4:

                        Console.WriteLine();
                        Console.WriteLine($"{Name} feel a strange power in your body.");
                        Thread.Sleep(2000);
                        int ChancePower = Lucky.Next(1, 101);

                        if (ChancePower <= 75)
                            {
                                Console.WriteLine($"The POWER refused {Name}...");
                            }
                        else
                            {
                                Console.WriteLine($"The POWER accept {Name}, make a change!");
                                int Power = Lucky.Next(20, 40);
                                EnemyLife = EnemyLife - Power;
                            }
                        Console.WriteLine();
                        Console.WriteLine($"{Name}'s enemy life is: {EnemyLife}.");
                        break;

                        default:

                        Console.WriteLine();
                        Console.WriteLine($"{Name} are afraid of your enemy! (Option Invalid)");
                        break;
                    }

                    if (EnemyLife <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{Name} defeat your enemy! Congratulations!");
                        Turns = false;
                        break;
                    }

                    Thread.Sleep(7000);
                    Console.WriteLine();

                    Console.WriteLine("Enemy's TURN!");
                    int EnemyTurn = Lucky.Next(1, 5);

                    if (EnemyTurn == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Enemy attacks {Name}!");
                        Thread.Sleep(2000);
                        int EnemyHT = Lucky.Next(1, 131);

                        if (EnemyHT <= 15)
                        {
                            Console.WriteLine($"But {Name} has evaded!");
                        }
                        else if (EnemyHT <= 100)
                        {
                            Console.WriteLine($"Enemy hits {Name}!");
                            Life = Life - EnemyAttack;
                        }
                        else if (EnemyHT >= 101)
                        {
                            Console.WriteLine($"{Name}'s enemy hit a Critical Hit!");
                            int EnemyCH = Lucky.Next(5, 10);
                            Life = Life - EnemyAttack;
                            Life = Life - EnemyCH;
                        }

                        Console.WriteLine();
                        Console.WriteLine($"{Name}´s life: {Life}.");
                    }
                    else if (EnemyTurn == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("The enemy are healing yourself!");
                        int NewLife = Lucky.Next(5, 20);
                        EnemyLife = EnemyLife + NewLife;
                    }
                    else if (EnemyTurn == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("The enemy feels a strange power...");
                        int ECPower = Lucky.Next(1, 101);
                        if (ECPower <= 75)
                        {
                            Console.WriteLine("Looks the POWER has REFUSED HIM!");
                        }
                        else
                        {
                            Console.WriteLine("The enemy is powerful and HITS you! DAMN!");
                            int EPower = Lucky.Next(20, 40);
                            Life = Life - EPower;
                        }
                    }
                    else if (EnemyTurn == 4)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{Name}'s enemy hits you with a Magic Power!");
                        int StatusChanged = Lucky.Next(1, 3);
                        if (StatusChanged == 1)
                        {
                            Console.WriteLine($"{Name}'s Defense fell!");
                            int DefenseFell = Lucky.Next(1, 6);
                            Defense = Defense - DefenseFell;
                        }
                        else
                        {
                            Console.WriteLine($"{Name}'s Attack fell!");
                            int AttackFell = Lucky.Next(1, 6);
                            Attack = Attack - AttackFell;
                        }
                    }

                    if (Life <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{Name}'s Life reaches 0... Your legacy has been gone");
                        Turns = false;
                        break;
                    }

                    Thread.Sleep(7000);
                    Console.WriteLine();

                    Console.WriteLine($"What {Name} will do?");
                    Console.WriteLine();
                    Console.WriteLine($"Enemy Stats - Life {EnemyLife}. Attack: {EnemyAttack}. Defense: {EnemyDefense}");
                    Console.WriteLine($"{Name} Stats - Life {Life}. Attack: {Attack}. Defense: {Defense}");

                    Console.WriteLine();
                    Console.WriteLine("1. Attack");
                    Console.WriteLine();
                    Console.WriteLine("2. Up chance of Critical Hit");
                    Console.WriteLine();
                    Console.WriteLine("3. Defense");
                    Console.WriteLine();
                    Console.WriteLine("4. Power Attack (Random)");
                }
            }
        }
    }
}

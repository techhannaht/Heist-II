using System.Net;
using Bank;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>
            {
                new Hacker { Name = "Lil Dawg HT", SkillLevel = 30, PercentageCut = 20 },
                new LockSpecialist { Name = "The Pickpocket KP", SkillLevel = 25, PercentageCut = 15 },
                new Muscle { Name = "Big Dawg RP", SkillLevel = 40, PercentageCut = 25 },
                new Hacker { Name = "Ole Boy AP", SkillLevel = 70, PercentageCut = 20 },
                new LockSpecialist { Name = "I'm All Ears, Aaron P", SkillLevel = 55, PercentageCut = 15 }

            };

            // Print the message "Plan Your Heist!".
            Console.WriteLine("Ah, so you'd like to heist... I see... let me show you your team:");

            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine(robber.Name);
            }

            {
                Console.WriteLine("_________________");
                Console.WriteLine("Any new recruits?");

                while (true)
                {

                    Console.WriteLine("What's your team member's name?");
                    string newName = Console.ReadLine();

                    Console.WriteLine("Choose the type of robber:");
                    Console.WriteLine("1. Hacker (Disables Alarms)");
                    Console.WriteLine("2. LockSpecialist (Cracks Vault)");
                    Console.WriteLine("3. Muscle (Disarms Guards)");
                    Console.WriteLine("Enter the number corresponding to the robber type: ");


                    if (int.TryParse(Console.ReadLine(), out int robberType))
                    {
                        IRobber newRobber;

                        switch (robberType)
                        {
                            case 1:
                                newRobber = new Hacker { Name = newName, SkillLevel = 0, PercentageCut = 0 };

                                break;
                            case 2:
                                newRobber = new LockSpecialist { Name = newName, SkillLevel = 0, PercentageCut = 0 };

                                break;
                            case 3:
                                newRobber = new Muscle { Name = newName, SkillLevel = 0, PercentageCut = 0 };
                                break;
                            default:
                                Console.WriteLine("Invalid Entry");
                                continue;
                        }



                        Console.WriteLine("Enter the team member's skill level:");

                        newRobber.SkillLevel = int.Parse(Console.ReadLine());


                        if (newRobber.SkillLevel <= 0 || newRobber.SkillLevel > 100)
                        {
                            Console.Write("Invalid input. Please enter a number between 1-100 for skill level: ");
                            newRobber.SkillLevel = int.Parse(Console.ReadLine());
                        };

                        Console.WriteLine("Nice! Your team member's skill level has been saved.");
                        Console.WriteLine("-------------------------------");


                        Console.WriteLine("Enter the team member's percentage cut:");

                        newRobber.PercentageCut = int.Parse(Console.ReadLine());


                        if (newRobber.PercentageCut <= 0 || newRobber.PercentageCut > 100)
                        {
                            Console.Write("Invalid input. Please enter a number between 1-100 for percentage cut: ");
                            newRobber.PercentageCut = int.Parse(Console.ReadLine());
                        };

                        Console.WriteLine("Nice! Your team member's percentage cut has been saved.");
                        Console.WriteLine("-------------------------------");

                        rolodex.Add(newRobber);

                        Console.WriteLine("Updated Rolodex:");
                        foreach (IRobber robber in rolodex)
                        {
                            Console.WriteLine($"{robber.Name}, Skill: {robber.SkillLevel}, Cut: {robber.PercentageCut}%");
                        }
                    }

                }

            }

        }
    }
}


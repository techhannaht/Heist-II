using System.Reflection;
using System.Runtime.CompilerServices;

namespace Bank
{
    public class BankInfo
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure
        {
            get
            {
                if (CashOnHand > 0 | AlarmScore > 0 | VaultScore > 0 | SecurityGuardScore > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }

    public class Hacker : IRobber
    {

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Speciality { get; set; } = string.Empty;
        public void PerformSkill(BankInfo bank)
        {
            bank.AlarmScore -= SkillLevel;

            Console.WriteLine($"{Name} is hacking the alarm system! Decreased security by {SkillLevel}.");

            if (bank.AlarmScore >= 0)
            {
                Console.WriteLine($"{Name} has disable the alarm system!");
            }

        }


    }

    public class Muscle : IRobber
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Speciality { get; set; } = string.Empty;
        public void PerformSkill(BankInfo bank)
        {
            bank.SecurityGuardScore -= SkillLevel;

            Console.WriteLine($"{Name} is wiping out the security detail! Decreased security by {SkillLevel}.");

            if (bank.SecurityGuardScore >= 0)
            {
                Console.WriteLine($"{Name} has disabled the security guards!");
            }

        }

    }

    public class LockSpecialist : IRobber
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Speciality { get; set; } = string.Empty;

        public void PerformSkill(BankInfo bank)
        {
            bank.VaultScore -= SkillLevel;

            Console.WriteLine($"{Name} is picking the locks! Decreased security by {SkillLevel}.");

            if (bank.VaultScore >= 0)
            {
                Console.WriteLine($"{Name} has picked the lock!");
            }

        }

    }

    public interface IRobber
    {

        string Name { get; set; }
        int SkillLevel { get; set; }
        int PercentageCut { get; set; }
        string Speciality { get; set; }
        int ID { get; set; }
        void PerformSkill(BankInfo bank);

    }

}
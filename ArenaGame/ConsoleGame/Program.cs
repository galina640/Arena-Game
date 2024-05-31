using ArenaGame;

namespace ConsoleGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of battles: ");
            int rounds = Int32.Parse(Console.ReadLine());
            int oneWins = 0, twoWins = 0;

            Weapon[] weapons = { new Sword(), new Bow(), new MagicWand() };
            Random rand = new Random();

            Hero one = GetRandomHero("Hero One", weapons[rand.Next(weapons.Length)]);
            Hero two = GetRandomHero("Hero Two", weapons[rand.Next(weapons.Length)]);

            Console.WriteLine($"Selected heroes for all battles: {one.Name} with {one.Weapon.Name} and {two.Name} with {two.Weapon.Name}");

            for (int i = 0; i < rounds; i++)
            {
                one.Weapon = weapons[rand.Next(weapons.Length)];
                two.Weapon = weapons[rand.Next(weapons.Length)];

                Console.WriteLine($"Arena fight between: {one.Name} with {one.Weapon.Name} and {two.Name} with {two.Weapon.Name}");
                Arena arena = new Arena(one, two);
                Hero winner = arena.Battle();
                Console.WriteLine($"Winner is: {winner.Name}");
                if (winner == one) oneWins++; else twoWins++;
            }

            Console.WriteLine();
            Console.WriteLine($"{one.Name} has {oneWins} wins.");
            Console.WriteLine($"{two.Name} has {twoWins} wins.");

            Console.ReadLine();
        }

        static Hero GetRandomHero(string name, Weapon weapon)
        {
            switch (Random.Shared.Next(4))
            {
                case 0: return new Knight("Sir Lancelot", weapon);
                case 1: return new Rogue("Robin Hood", weapon);
                case 2: return new Fairy("Bloom", weapon);
                case 3: return new Elf("Kory", weapon);
                default: throw new Exception("Unknown hero type");
            }
        }
    }
}

namespace ArenaGame
{
    public class BattleEvent
    {
        public Hero Attacker { get; set; }
        public Hero Defender { get; set; }
        public int Damage { get; set; }
    }

    public interface IArenaBattleListener
    {
        void OnBattleTurn(BattleEvent e);
    }
    public class Arena
    {
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }
        public IArenaBattleListener BattleListener { get; set; }

        public Arena(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;
            if (Random.Shared.Next(2) == 0)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else
            {
                attacker = HeroB;
                defender = HeroA;
            }
            while (true)
            {
                int damage = attacker.Attack();
                defender.TakeDamage(damage);

                if (BattleListener != null)
                {
                    BattleEvent e = new()
                    {
                        Attacker = attacker,
                        Defender = defender,
                        Damage = damage,
                    };
                    BattleListener.OnBattleTurn(e);
                }

                if (defender.IsDead) return attacker;
                Hero tmp = attacker;
                attacker = defender;
                defender = tmp;
            }
        }
    }
}

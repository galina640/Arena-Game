using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Elf : Hero
    {
        public Elf(string name, Weapon weapon) : base(name, weapon) { }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(12)) 
            {
                attack *= 2;
            }
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            incomingDamage -= 10;
            base.TakeDamage(incomingDamage);
        }
    }
}

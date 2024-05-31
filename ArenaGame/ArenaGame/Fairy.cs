using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Fairy : Hero
    {
        public Fairy(string name, Weapon weapon) : base(name, weapon) { }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(20)) 
            {
                attack += 40;
            }
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            incomingDamage += 15;
            base.TakeDamage(incomingDamage);
        }
    }
}

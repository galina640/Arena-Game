using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Weapon
    {
        public string Name { get; private set; }
        public int DamageBonus { get; private set; }
        public int SpecialChance { get; private set; }

        public Weapon(string name, int damageBonus, int specialChance)
        {
            Name = name;
            DamageBonus = damageBonus;
            SpecialChance = specialChance;
        }

        public virtual int SpecialAttack(int baseDamage)
        {
            return baseDamage;
        }

        protected bool ThrowDice(int chance)
        {
            int dice = Random.Shared.Next(101);
            return dice <= chance;
        }
    }

    public class Sword : Weapon
    {
        public Sword() : base("Sword", 20, 10) { }

        public override int SpecialAttack(int baseDamage)
        {
            if (ThrowDice(SpecialChance))
            {
                baseDamage += 50;
            }
            return baseDamage;
        }
    }

    public class Bow : Weapon
    {
        public Bow() : base("Bow", 15, 15) { }

        public override int SpecialAttack(int baseDamage)
        {
            if (ThrowDice(SpecialChance))
            {
                baseDamage *= 2;
            }
            return baseDamage;
        }
    }

    public class MagicWand : Weapon
    {
        public MagicWand() : base("Magic wand", 10, 20) { }

        public override int SpecialAttack(int baseDamage)
        {
            if (ThrowDice(SpecialChance))
            {
                baseDamage = 0;
            }
            return baseDamage;
        }
    }
}

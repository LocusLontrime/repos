using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectsEngine
{
    public class Buff : EffectBlock
    {
        public double maxHealthPercentChange { get; set; }
        public double dmgPercentChange { get; set; }
        public double physArmourPercentChange { get; set; }
        public double chemArmourPercentBoost { get; set; }
        public double magArmourPercentChange { get; set; }
        public double evasionPercentChange { get; set; }
        public double critChanceChange { get; set; }
        public double critDmgChange { get; set; }

        public void print()
        {
            Console.WriteLine("Buff effect: ");

            if (duration != 0) Console.WriteLine("duration = " + duration);

            Console.WriteLine(canBeRemoved);

            Console.WriteLine(canBeRenewed);

            if (maxStacks != 0) Console.WriteLine("maxStacks = " + maxStacks);   

            if (maxHealthPercentChange != 0) Console.WriteLine("maxHealthPercentChange = " + maxHealthPercentChange);

            if (dmgPercentChange != 0) Console.WriteLine("dmgPercentChange = " + dmgPercentChange);

            if (evasionPercentChange != 0) Console.WriteLine("evasionPercentChange = " + evasionPercentChange);

            if (physArmourPercentChange != 0) Console.WriteLine("physArmourPercentChange = " + physArmourPercentChange);

            if (chemArmourPercentBoost != 0) Console.WriteLine("chemArmourPercentBoost = " + chemArmourPercentBoost);

            if (magArmourPercentChange != 0) Console.WriteLine("magArmourPercentChange = " + magArmourPercentChange);

            if (critChanceChange != 0) Console.WriteLine("critChanceChange = " + critChanceChange);

            if (critDmgChange != 0) Console.WriteLine("critDmgChange = " + critDmgChange);

            Console.WriteLine();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectsEngine
{
    public class HealingEff : EffectBlock
    {
        public double healingAmount { get; set; }

        public void print()
        {
            Console.WriteLine("Healing effect: ");

            if (healingAmount != 0) Console.WriteLine("healingAmount = " + healingAmount);

            if (duration != 0) Console.WriteLine("duration = " + duration);

            Console.WriteLine(canBeRemoved);

            Console.WriteLine(canBeRenewed);

            if (maxStacks != 0) Console.WriteLine("maxStacks = " + maxStacks);

            Console.WriteLine();
        }

    }
}

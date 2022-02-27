using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EffectsEngine.EnumLib;

namespace EffectsEngine
{
    internal class BuildingTest
    {
        static void Main(string[] args)
        {

            BuffBuilder buffBuilder = new BuffBuilder();
            Buff buff = (Buff) buffBuilder
                .SetMaxStacks(2)
                    .SetDmgPercentChange(15)
                        .SetCritChanceChange(10)
                            .SetCritDmgChange(100)
                                .SetCanBeRemoved(CanBeRemoved.CanBeRemoved)
                                    .SetCanBeRenewed(CanBeRenewed.CanBeRenewed)
                                        .SetDuration(2)
                                            .Build();

            buff.print();

            HealingEffBuilder healingEffBuilder = new HealingEffBuilder();

            HealingEff healingEff = (HealingEff)healingEffBuilder
                .SetMaxStacks(2)
                    .SetHealingAmount(1000)
                        .SetCanBeRemoved(CanBeRemoved.CanBeRemoved)
                            .SetCanBeRenewed(CanBeRenewed.CanBeRenewed)
                                .SetDuration(3)
                                    .Build();

            healingEff.print();

            EffectBuilder effectBuilder = new EffectBuilder();
            Effect effect = effectBuilder
                .SetBuff(buff)
                    .SetHealingEff(healingEff)
                        .SetEffectName("Rejuvenation")
                            .SetEffectSetter(new Creature())
                                .Build();
                
        }
    }
}

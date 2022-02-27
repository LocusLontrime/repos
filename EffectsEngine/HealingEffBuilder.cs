using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EffectsEngine.EnumLib;

namespace EffectsEngine
{
    internal class HealingEffBuilder : Builder
    {
        public HealingEffBuilder() => effectBlock = new HealingEff();

        public HealingEffBuilder SetHealingAmount(double healingAmount) 
        {
            ((HealingEff)effectBlock).healingAmount = healingAmount;
            return this;
        }

        public HealingEffBuilder SetCanBeRemoved(CanBeRemoved canBeRemoved)
        {
            ((HealingEff)effectBlock).canBeRemoved = canBeRemoved;
            return this;
        }

        public HealingEffBuilder SetCanBeRenewed(CanBeRenewed canBeRenewed)
        {
            ((HealingEff)effectBlock).canBeRenewed = canBeRenewed;
            return this;
        }

        public HealingEffBuilder SetMaxStacks(int maxStacks)
        {
            ((HealingEff)effectBlock).maxStacks = maxStacks;
            return this;
        }

        public HealingEffBuilder SetDuration(int duration)
        {
            ((HealingEff)effectBlock).duration = duration;
            return this;
        }

    }
}

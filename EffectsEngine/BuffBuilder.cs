using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EffectsEngine.EnumLib;

namespace EffectsEngine
{
    internal class BuffBuilder : Builder
    {
        public BuffBuilder() => effectBlock = new Buff();
        public BuffBuilder SetMaxHealthPercentChange(double maxHealthPercentChange)
        {
            ((Buff) effectBlock).maxHealthPercentChange = maxHealthPercentChange;
            return this;
        }

        public BuffBuilder SetDmgPercentChange(double dmgPercentChange) 
        {
            ((Buff)effectBlock).dmgPercentChange = dmgPercentChange;
            return this;
        }

        public BuffBuilder SetPhysArmourPercentChange(double physArmourPercentChange) 
        {
            ((Buff)effectBlock).physArmourPercentChange = physArmourPercentChange;
            return this;
        }

        public BuffBuilder SetChemArmourPercentChange(double chemArmourPercentChange)
        {
            ((Buff)effectBlock).physArmourPercentChange = chemArmourPercentChange;
            return this;
        }

        public BuffBuilder SetMageArmourPercentChange(double mageArmourPercentChange)
        {
            ((Buff)effectBlock).physArmourPercentChange = mageArmourPercentChange;
            return this;
        }

        public BuffBuilder SetEvasionPercentChange(double evasionPercentChange) 
        {
            ((Buff)effectBlock).evasionPercentChange = evasionPercentChange;
            return this;     
        }

        public BuffBuilder SetCritChanceChange(double critChanceChange) 
        {
            ((Buff)effectBlock).critChanceChange = critChanceChange;
            return this;
        }

        public BuffBuilder SetCritDmgChange(double critDmgChange)
        {
            ((Buff)effectBlock).critDmgChange = critDmgChange;
            return this;
        }

        public BuffBuilder SetCanBeRemoved(CanBeRemoved canBeRemoved) 
        {
            ((Buff)effectBlock).canBeRemoved = canBeRemoved;
            return this;
        }

        public BuffBuilder SetCanBeRenewed(CanBeRenewed canBeRenewed) 
        {
            ((Buff)effectBlock).canBeRenewed = canBeRenewed; 
            return this;
        }

        public BuffBuilder SetMaxStacks(int maxStacks) 
        {
            ((Buff)effectBlock).maxStacks = maxStacks;
            return this;
        }

        public BuffBuilder SetDuration(int duration) 
        {        
            ((Buff) effectBlock).duration = duration; 
            return this;    
        }
    }
}

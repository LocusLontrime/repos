using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectsEngine
{
    public class EffectBuilder
    {

        protected Effect effect;

        public Effect Build () => effect;

        public EffectBuilder () => effect = new Effect ();

        public EffectBuilder SetEffectName(string name) 
        { 
            effect.name = name;
            return this;
        }

        public EffectBuilder SetEffectSetter(LivingThing effectSetter) 
        {
            effect.effectSetter = effectSetter;
            return this;
        }

        public EffectBuilder SetBuff(Buff buff) 
        { 
            effect.buff = buff;
            return this;
        }

        public EffectBuilder SetControlEff(ControlEff controlEff) 
        { 
            effect.controlEff = controlEff;
            return this;
        }

        public EffectBuilder SetDot(Dot dot) 
        { 
            effect.dot = dot;
            return this;
        }

        public EffectBuilder SetDelayedEff(DelayedEff delayedEff) 
        {
            effect.delayedEff = delayedEff;
            return this;
        }

        public EffectBuilder SetHealingEff(HealingEff healingEff) 
        { 
            effect.healingEff = healingEff;
            return this;
        }

        public EffectBuilder SetShieldEff(ShieldEff shieldEff) 
        {
            effect.shieldEff = shieldEff;
            return this;
        }



    }
}

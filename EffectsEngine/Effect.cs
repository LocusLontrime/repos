using EffectsEngine;
using System;
using System.Collections;

public class Effect {

    public string name { get; set; }
    public LivingThing effectSetter { get; set; }

    public Effect() 
    {
      
    }

    public Buff buff { get; set; }

    public ControlEff controlEff { get; set; }

    public Dot dot { get; set; }

    public DelayedEff delayedEff { get; set; } 

    public HealingEff healingEff { get; set; }

    public ShieldEff shieldEff { get; set; }   
    

}


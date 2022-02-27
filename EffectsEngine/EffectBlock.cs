using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EffectsEngine.EnumLib;

namespace EffectsEngine
{
    public abstract class EffectBlock
    {
        public int duration { get; set; }
        public CanBeRemoved canBeRemoved { get; set; }
        public CanBeRenewed canBeRenewed { get; set; }
        public int maxStacks { get; set; }

    }
}

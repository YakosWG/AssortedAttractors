using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace AssortedAttractors
{
    class AssortedAttractorsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        //[Label("Range Multiplier")]
        [Description("Multiplies range by this value. Range is rounded down to closest whole number")]
        [Range(0f, 10f)]
        [Increment(0.1f)]
        [DefaultValue(1f)]
        //[ReloadRequired]
        public float rangeMult;

        //[Label("Speed Multiplier")]
        [Description("Multiplies speed and max speed by this value")]
        [Range(0f, 10f)]
        [Increment(0.1f)]
        [DefaultValue(1f)]
        //[ReloadRequired]
        public float speedMult;

        [OnDeserialized]
        internal void onDeserialize(StreamingContext context)
        {
            rangeMult = Utils.Clamp(rangeMult, 0f, 10f); //I like fun too but anything more than this will probably prevent the magnets from actually working
            speedMult = Utils.Clamp(speedMult, 0f, 10f);
        }

        public override void OnChanged()
        {
            Mod.Logger.InfoFormat("Assorted Attractors Config has changed. New values are: rangeMult: {0}, speedMult: {1}", rangeMult, speedMult);
        }
    }
}

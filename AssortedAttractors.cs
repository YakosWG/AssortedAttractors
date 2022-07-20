using System.Collections.Generic;
using Terraria.ModLoader;

namespace AssortedAttractors
{
	public class AssortedAttractors : Mod
	{

		public static Mod calamityMod;

        public override void Load()
        {
			calamityMod = ModLoader.GetMod("CalamityMod");			
		}

	}
}
using System.Collections.Generic;
using Terraria.ModLoader;

namespace AssortedAttractors
{
	public class AssortedAttractors : Mod
	{

		public static Mod calamityMod;

        public override void Load()
        {
			try
			{
				calamityMod = ModLoader.GetMod("CalamityMod");
			}
			catch {
				calamityMod = null;
            }

		}

	}
}
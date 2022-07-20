using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using AssortedAttractors.Items.Magnets;

namespace AssortedAttractors.Items
{
    class BossBags : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && arg == ItemID.FishronBossBag && (Main.rand.Next() % 100 < 5 || Main.raining))
            {
                player.QuickSpawnItem(ModContent.ItemType<FishronMagnet>());
            } else if (AssortedAttractors.calamityMod != null && context == "bossBag" && arg == AssortedAttractors.calamityMod.ItemType("DevourerofGodsBag") && Main.rand.Next() % 100 < 5)
            {
                player.QuickSpawnItem(ModContent.ItemType<DoGMagnet>());
            }
        }

    }
}

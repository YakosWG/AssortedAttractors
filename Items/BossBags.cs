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
            if (context == "bossBag" && arg == ItemID.FishronBossBag && (Main.rand.NextBool(20) || Main.raining))
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.FishronBossBag),ModContent.ItemType<FishronMagnet>());
            } 
            else if (AssortedAttractors.calamityMod != null && context == "bossBag" && arg == AssortedAttractors.calamityMod.Find<ModItem>("DevourerofGodsBag").Type && Main.rand.NextBool(10))
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(AssortedAttractors.calamityMod.Find<ModItem>("DevourerofGodsBag").Type), ModContent.ItemType<DoGMagnet>());
            }
        }

    }
}

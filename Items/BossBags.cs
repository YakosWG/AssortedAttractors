using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using AssortedAttractors.Items.Magnets;
using Terraria.GameContent.ItemDropRules;

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

        /*

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
        
            if (item.type == ItemID.FishronBossBag)
            {
                IItemDropRule entry = ItemDropRule.ByCondition(new NPCs.ConditionRain(true), ModContent.ItemType<FishronMagnet>(), 20, 0, 1);
                itemLoot.Add(entry);
                entry = ItemDropRule.ByCondition(new NPCs.ConditionRain(false), ModContent.ItemType<FishronMagnet>(), 1, 1, 1);
                itemLoot.Add(entry);
            }
            else if (AssortedAttractors.calamityMod != null && item.type == AssortedAttractors.calamityMod.Find<ModItem>("DevourerofGodsBag").Type)
            {
                IItemDropRule entry = ItemDropRule.Common(ModContent.ItemType<DoGMagnet>(), 10, 0, 1);
                itemLoot.Add(entry);
            }
        }

        */

    }
}

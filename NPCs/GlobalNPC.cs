using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using AssortedAttractors.Items.Magnets;

namespace AssortedAttractors.NPCs
{
    class GlobalNPC : Terraria.ModLoader.GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.DukeFishron && !Main.expertMode && (Main.rand.Next() % 100 < 5 || Main.raining))
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<FishronMagnet>());
            }
        }
    }
}

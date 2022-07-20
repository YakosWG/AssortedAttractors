using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using AssortedAttractors.Items.Magnets;
using Terraria.GameContent.ItemDropRules;

namespace AssortedAttractors.NPCs
{
    class GlobalNPC : Terraria.ModLoader.GlobalNPC
    {

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            IItemDropRule entry = ItemDropRule.ByCondition(new ConditionRain(), ModContent.ItemType<FishronMagnet>(), 20, 0, 1);
            npcLoot.Add(entry);
        }
    }

    //TODO: Garantuee drop in rain
    class ConditionRain : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return true;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "please fix";
        }
    }

}

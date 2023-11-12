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
using Terraria.Map;

namespace AssortedAttractors.NPCs
{
    class GlobalNPC : Terraria.ModLoader.GlobalNPC
    {

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.DukeFishron)
            {
                LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                //while not in rain
                IItemDropRule entry = ItemDropRule.ByCondition(new ConditionRain(true), ModContent.ItemType<FishronMagnet>(), 20, 0, 1);
                notExpertRule.OnSuccess(entry);

                //while in rain
                entry = ItemDropRule.ByCondition(new ConditionRain(false), ModContent.ItemType<FishronMagnet>(), 1, 1, 1);
                notExpertRule.OnSuccess(entry);

                npcLoot.Add(notExpertRule);
            }
        }

        public override void ModifyShop(NPCShop shop)
        {
            //Add Lucky Horseshoe to Merchant shop if he is on a sky island
            if (shop.NpcType == NPCID.Merchant)
            {
                shop.Add(new Item(ItemID.LuckyHorseshoe)
                {
                    shopCustomPrice = 50000
                }, Condition.InSkyHeight);
            }
            //Add Treasure Magnet to Gobling Tinkerer shop if he is in the underworld and Skeletron has been defeated
            else if ((shop.NpcType == NPCID.GoblinTinkerer))
            {
                shop.Add(new Item(ItemID.TreasureMagnet)
                {
                    shopCustomPrice = 150000
                }, Condition.InUnderworldHeight, Condition.DownedSkeletron);
            }
        }
    }
    class ConditionRain : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        bool invert = false;

        public ConditionRain(bool invert)
        {
            this.invert = invert;
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return Main.raining ? !invert : invert;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return invert ? "On a clear day" : "During Rain";
        }
    }
}


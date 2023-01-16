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

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            //Merchant sells Lucky Horseshoe if he is (technically if you are) on sky island height
            if (type == NPCID.Merchant && Main.LocalPlayer.ZoneSkyHeight)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LuckyHorseshoe);
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 0, 0);
                nextSlot++;

            }
            //Goblin Tinkerer sells treasure magnet after skeletron has been defeated if he is (technically if you are) in the underworld
            else if (type == NPCID.GoblinTinkerer && NPC.downedBoss3 && Main.LocalPlayer.ZoneUnderworldHeight)
            {
                shop.item[nextSlot].SetDefaults(ItemID.TreasureMagnet);
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 15, 0, 0);
                nextSlot++;
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


using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class TrueInvestmentMagnet : MagnetBase
    {
        public TrueInvestmentMagnet()
        {
            range = 120;
            speed = 1.8f;
            maxSpeed = 8f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Strongly attracts coins and hearts");
            DisplayName.SetDefault("Return on Investment");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.sellPrice(0, 15, 0, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<InvestmentMagnet>());
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.AddBuff(BuffID.Heartreach, 1);
            player.goldRing = true;

        }
    }
}

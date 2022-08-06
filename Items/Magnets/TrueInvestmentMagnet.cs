using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class TrueInvestmentMagnet : MagnetBase
    {
        public TrueInvestmentMagnet()
        {
            range = 18;
            speed = 1.6f;
            maxSpeed = 6.4f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Strongly attracts coins and hearts");
            DisplayName.SetDefault("Return on Investment");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(0, 15, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<InvestmentMagnet>());
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.AddBuff(BuffID.Heartreach, 1);
            player.goldRing = true;

        }
    }
}

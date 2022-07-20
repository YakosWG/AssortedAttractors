using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class InvestmentMagnet : MagnetBase
    {
        public InvestmentMagnet()
        {
            range = 120;
            speed = 1.3f;
            maxSpeed = 5f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Strongly attracts coins");
            DisplayName.SetDefault("The Investment");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(0, 3, 0, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldRing);
            recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.goldRing = true;

        }
    }
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class TerraMagnet : MagnetBase
    {
        public TerraMagnet()
        {
            range = 30;
            speed = 1.8f;
            maxSpeed = 6.9f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            // Tooltip.SetDefault("Strongly attracts souls, hearts, stars and coins");
            // DisplayName.SetDefault("Rare Earth");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 50, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TrueMidnightMagnet>());
            recipe.AddIngredient(ModContent.ItemType<TrueInvestmentMagnet>());
            recipe.AddTile(TileID.Autohammer);
            recipe.Register();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().ParseMagnet(this.range, this.speed, this.maxSpeed);
            player.manaMagnet = false; //Custom mana magnet is better than vanilla celestial at this point
            player.goldRing = true;
            player.AddBuff(BuffID.Heartreach, 1);
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true; 
            player.GetModPlayer<MagnetPlayer>().soulMagnet = true;

        }
    }
}

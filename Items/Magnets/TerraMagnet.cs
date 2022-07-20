using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class TerraMagnet : MagnetBase
    {
        public TerraMagnet()
        {
            range = 200;
            speed = 1.7f;
            maxSpeed = 6.9f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Strongly attracts souls, hearts, stars and coins");
            DisplayName.SetDefault("Rare Earth");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 50, 0, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TrueMidnightMagnet>());
            recipe.AddIngredient(ModContent.ItemType<TrueInvestmentMagnet>());
            recipe.AddTile(TileID.Autohammer);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.manaMagnet = false; //Custom mana magnet is better than vanilla celestial at this point
            player.goldRing = true;
            player.AddBuff(BuffID.Heartreach, 1);
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true; 
            player.GetModPlayer<MagnetPlayer>().soulMagnet = true;

        }
    }
}

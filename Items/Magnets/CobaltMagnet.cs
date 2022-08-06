using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class CobaltMagnet : MagnetBase
    {
        public CobaltMagnet()
        {
            range = 15;
            speed = 1.5f;
            maxSpeed = 6f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Stars are attracted at far greater range");           
            DisplayName.SetDefault("Jishaku");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 5, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CelestialMagnet);
            recipe.AddIngredient(ItemID.CobaltBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.manaMagnet = true;

        }
    }
}

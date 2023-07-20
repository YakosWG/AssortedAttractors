using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;

namespace AssortedAttractors.Items.Magnets
{
    class SuperheatedMagnet : MagnetBase
    {
        public SuperheatedMagnet()
        {
            range = 10;
            speed = 0.4f;
            maxSpeed = 1.5f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            // Tooltip.SetDefault(String.Empty);
            // DisplayName.SetDefault("Superheated Magnet");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 6, 96, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 16);
            recipe.AddIngredient(ItemID.MeteoriteBar, 4);
            recipe.AddIngredient(ItemID.TreasureMagnet);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }
    }
}

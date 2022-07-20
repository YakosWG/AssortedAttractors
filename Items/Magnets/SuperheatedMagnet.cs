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
            range = 96;
            speed = 0.4f;
            maxSpeed = 1.2f;
        }

        /* Cobalt magnet:
         * more speed and range
         * Palladium magnet:
         * more range, bonus range for hearts 
         */

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(String.Empty);
            DisplayName.SetDefault("Superheated Magnet");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 6, 96, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 16);
            recipe.AddIngredient(ItemID.MeteoriteBar, 4);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 16);
            recipe.AddIngredient(ItemID.MeteoriteBar, 4);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

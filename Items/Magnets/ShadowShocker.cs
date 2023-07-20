using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;

namespace AssortedAttractors.Items.Magnets
{
    class ShadowShocker : MagnetBase
    {
        public ShadowShocker()
        {
            range = 4;
            speed = 0.7f;
            maxSpeed = 2.8f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            // Tooltip.SetDefault(String.Empty);
            // DisplayName.SetDefault("Shadow Shocker");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 3, 29, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddIngredient(ItemID.ShadowScale, 4);
            recipe.AddIngredient(ModContent.ItemType<FerrousHorseShoe>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}

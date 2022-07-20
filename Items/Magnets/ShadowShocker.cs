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
            range = 38;
            speed = 0.7f;
            maxSpeed = 2.8f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(String.Empty);
            DisplayName.SetDefault("Shadow Shocker");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 3, 29, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddIngredient(ItemID.ShadowScale, 4);
            recipe.AddIngredient(ModContent.ItemType<FerrousHorseShoe>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

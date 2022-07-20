using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;

namespace AssortedAttractors.Items.Magnets
{
    class FerrousHorseShoe : MagnetBase
    {

        public FerrousHorseShoe()
        {
            range = 28;
            speed = 0.5f;
            maxSpeed = 2f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(String.Empty);
            DisplayName.SetDefault("Ferrous Horseshoe");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(0,0,69,0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddIngredient(ItemID.LuckyHorseshoe);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

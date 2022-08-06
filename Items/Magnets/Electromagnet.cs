using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;

namespace AssortedAttractors.Items.Magnets
{
    class Electromagnet : MagnetBase
    {
        public Electromagnet()
        {
            range = 3;
            speed = 1.0f;
            maxSpeed = 4.0f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault(String.Empty);
            DisplayName.SetDefault("Electromagnet");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 69, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wire, 50);
            recipe.AddIngredient(ItemID.Shackle);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}

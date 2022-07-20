using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AssortedAttractors.Items.Magnets
{
    class HemoglobinPulser : MagnetBase
    {
        public HemoglobinPulser()
        {
            range = 57;
            speed = 0.5f;
            maxSpeed = 2.0f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(String.Empty);
            DisplayName.SetDefault("Hemoglobin Pulser");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 3, 95, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddIngredient(ItemID.TissueSample, 4);
            recipe.AddIngredient(ModContent.ItemType<FerrousHorseShoe>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

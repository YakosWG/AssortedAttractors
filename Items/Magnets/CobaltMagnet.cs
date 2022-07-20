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
            range = 100;
            speed = 1.5f;
            maxSpeed = 6f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(String.Empty);
            Tooltip.SetDefault("Stars are attracted at far greater range");           
            DisplayName.SetDefault("Jishaku");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(0, 5, 0, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialMagnet);
            recipe.AddIngredient(ItemID.CobaltBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.manaMagnet = true;

        }
    }
}

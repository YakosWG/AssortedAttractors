using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AssortedAttractors.Items.Magnets
{
    class JungleMagnet : MagnetBase
    {
        public JungleMagnet()
        {
            range = 38;
            speed = 0.9f;
            maxSpeed = 2.7f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Will only attract stars. Stars are attracted at far greater range");
            DisplayName.SetDefault("Spore Catcher");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 0, 9, 20);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stinger, 2);
            recipe.AddIngredient(ItemID.Vine, 4);
            recipe.AddIngredient(ItemID.JungleSpores, 2);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.GetModPlayer<MagnetPlayer>().manaOnly = true;
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true;

        }
    }
}

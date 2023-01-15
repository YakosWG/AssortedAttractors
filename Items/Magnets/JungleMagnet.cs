using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AssortedAttractors.Items.Magnets
{
    class JungleMagnet : MagnetBase
    {
        public JungleMagnet()
        {
            range = 3;
            speed = 0.9f;
            maxSpeed = 2.7f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Will only attract stars. Stars are attracted at far greater range");
            DisplayName.SetDefault("Spore Catcher");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 9, 20);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Stinger, 2);
            recipe.AddIngredient(ItemID.Vine, 4);
            recipe.AddIngredient(ItemID.JungleSpores, 2);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().ParseMagnet(this.range, this.speed, this.maxSpeed);
            player.GetModPlayer<MagnetPlayer>().manaOnly = true;
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true;

        }
    }
}

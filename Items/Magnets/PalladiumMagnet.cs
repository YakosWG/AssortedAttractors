using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class PalladiumMagnet : MagnetBase
    {
        public PalladiumMagnet()
        {
            range = 15;
            speed = 1f;
            maxSpeed = 4f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Strongly attracts hearts \nStars are attracted at far greater range");            
            DisplayName.SetDefault("Valentine");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 5, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CelestialMagnet);
            recipe.AddIngredient(ItemID.PalladiumBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().ParseMagnet(this.range, this.speed, this.maxSpeed);
            player.manaMagnet = true;
            player.AddBuff(BuffID.Heartreach, 1);

        }
    }
}

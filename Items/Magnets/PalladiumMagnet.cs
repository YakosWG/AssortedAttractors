using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class PalladiumMagnet : MagnetBase
    {
        public PalladiumMagnet()
        {
            range = 100;
            speed = 1f;
            maxSpeed = 4f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Strongly attracts hearts \nStars are attracted at far greater range");            
            DisplayName.SetDefault("Valentine");
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
            recipe.AddIngredient(ItemID.PalladiumBar, 7);
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
            player.AddBuff(BuffID.Heartreach, 1);

        }
    }
}

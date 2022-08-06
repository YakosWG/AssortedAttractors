using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class MidnightMagnet : MagnetBase
    {
        public MidnightMagnet()
        {
            range = 10;
            speed = 1f;
            maxSpeed = 4f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Stars are attracted at far greater range");           
            DisplayName.SetDefault("Midnight's Invitation");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 15, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ShadowShocker>());
            recipe.AddIngredient(ModContent.ItemType<Electromagnet>());
            recipe.AddIngredient(ModContent.ItemType<JungleMagnet>());
            recipe.AddIngredient(ModContent.ItemType<SuperheatedMagnet>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HemoglobinPulser>());
            recipe.AddIngredient(ModContent.ItemType<Electromagnet>());
            recipe.AddIngredient(ModContent.ItemType<JungleMagnet>());
            recipe.AddIngredient(ModContent.ItemType<SuperheatedMagnet>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true;

        }
    }
}

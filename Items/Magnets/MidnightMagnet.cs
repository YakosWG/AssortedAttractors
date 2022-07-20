using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class MidnightMagnet : MagnetBase
    {
        public MidnightMagnet()
        {
            range = 96;
            speed = 1f;
            maxSpeed = 4f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Stars are attracted at far greater range");           
            DisplayName.SetDefault("Midnight's Invitation");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(0, 15, 0, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShadowShocker>());
            recipe.AddIngredient(ModContent.ItemType<Electromagnet>());
            recipe.AddIngredient(ModContent.ItemType<JungleMagnet>());
            recipe.AddIngredient(ModContent.ItemType<SuperheatedMagnet>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HemoglobinPulser>());
            recipe.AddIngredient(ModContent.ItemType<Electromagnet>());
            recipe.AddIngredient(ModContent.ItemType<JungleMagnet>());
            recipe.AddIngredient(ModContent.ItemType<SuperheatedMagnet>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true;

        }
    }
}

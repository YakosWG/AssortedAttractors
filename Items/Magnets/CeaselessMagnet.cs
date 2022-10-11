using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items;
using CalamityMod.Rarities;

namespace AssortedAttractors.Items.Magnets
{
    class CeaselessMagnet : MagnetBase
    {
        public CeaselessMagnet()
        {
            range = 60;
            speed = 3f;
            maxSpeed = 12f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Strongly attracts souls, hearts, stars, dolls and coins");
            DisplayName.SetDefault("Mobius Loop");

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 5));
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.sellPrice(0, 50, 0, 0);

            if (AssortedAttractors.calamityMod != null) calamityRarityIntegration();
        }

        [JITWhenModsEnabled("CalamityMod")]
        private void calamityRarityIntegration()
        {
            Item.rare = ModContent.RarityType<Turquoise>();
        }

        public override void AddRecipes()
        {
            if(AssortedAttractors.calamityMod != null && AssortedAttractors.calamityMod.Find<ModItem>("DarkPlasma").Type != 0 
                && AssortedAttractors.calamityMod.Find<ModItem>("GalacticaSingularity").Type != 0 && AssortedAttractors.calamityMod.Find<ModItem>("Phantoplasm").Type != 0)
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<MoonMagnet>());
                recipe.AddIngredient(AssortedAttractors.calamityMod.Find<ModItem>("DarkPlasma").Type, 5);
                recipe.AddIngredient(AssortedAttractors.calamityMod.Find<ModItem>("GalacticaSingularity").Type, 10);
                recipe.AddIngredient(AssortedAttractors.calamityMod.Find<ModItem>("Phantoplasm").Type, 5);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }
            
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.manaMagnet = false;
            player.goldRing = true;
            player.AddBuff(BuffID.Heartreach, 1);
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true;
            player.GetModPlayer<MagnetPlayer>().soulMagnet = true;
            player.GetModPlayer<MagnetPlayer>().voodooMagnet = true;

        }
    }
}

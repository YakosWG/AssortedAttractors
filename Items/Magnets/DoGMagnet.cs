using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items;

namespace AssortedAttractors.Items.Magnets
{
    class DoGMagnet : MagnetBase
    {
        public DoGMagnet()
        {
            range = 800;
            speed = 4f;
            maxSpeed = 16f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Strongly attracts souls, hearts, stars, dolls, coins, nightmare fuel, darksun fragments and endothermic energy");
            DisplayName.SetDefault("Devourer of Drops");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.sellPrice(1, 0, 0, 0);

            if (AssortedAttractors.calamityMod != null) calamityRarityIntegration();
        }

        private void calamityRarityIntegration()
        {
            Item.GetGlobalItem<CalamityGlobalItem>().customRarity = CalamityMod.CalamityRarity.DarkBlue;
        }

        public override void AddRecipes()
        {
            if (AssortedAttractors.calamityMod != null && AssortedAttractors.calamityMod.Find<ModItem>("CosmiliteBar").Type != 0
                && AssortedAttractors.calamityMod.Find<ModItem>("ArmoredShell").Type != 0 && AssortedAttractors.calamityMod.Find<ModItem>("RuinousSoul").Type != 0 
                && AssortedAttractors.calamityMod.Find<ModTile>("CosmicAnvil").Type != 0)
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<CeaselessMagnet>());
                recipe.AddIngredient(AssortedAttractors.calamityMod.Find<ModItem>("CosmiliteBar").Type, 8);
                recipe.AddIngredient(AssortedAttractors.calamityMod.Find<ModItem>("ArmoredShell").Type, 3);
                recipe.AddIngredient(AssortedAttractors.calamityMod.Find<ModItem>("RuinousSoul").Type, 5);
                recipe.AddTile(AssortedAttractors.calamityMod.Find<ModTile>("CosmicAnvil").Type);
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
            player.GetModPlayer<MagnetPlayer>().eventEssenceMagnet = true;

        }
    }
}

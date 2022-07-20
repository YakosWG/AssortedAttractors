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
            Tooltip.SetDefault("Strongly attracts souls, hearts, stars, dolls, coins, nightmare fuel, darksun fragments and endothermic energy");
            DisplayName.SetDefault("Devourer of Drops");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(1, 0, 0, 0);

            if (AssortedAttractors.calamityMod != null) calamityRarityIntegration();
        }

        private void calamityRarityIntegration()
        {
            item.GetGlobalItem<CalamityGlobalItem>().customRarity = CalamityMod.CalamityRarity.DarkBlue;
        }

        public override void AddRecipes()
        {
            if (AssortedAttractors.calamityMod != null && AssortedAttractors.calamityMod.ItemType("CosmiliteBar") != 0
                && AssortedAttractors.calamityMod.ItemType("ArmoredShell") != 0 && AssortedAttractors.calamityMod.ItemType("RuinousSoul") != 0 
                && AssortedAttractors.calamityMod.TileType("CosmicAnvil") != 0)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<CeaselessMagnet>());
                recipe.AddIngredient(AssortedAttractors.calamityMod.ItemType("CosmiliteBar"), 8);
                recipe.AddIngredient(AssortedAttractors.calamityMod.ItemType("ArmoredShell"), 3);
                recipe.AddIngredient(AssortedAttractors.calamityMod.ItemType("RuinousSoul"), 5);
                recipe.AddTile(AssortedAttractors.calamityMod.TileType("CosmicAnvil"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }

        }

        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
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

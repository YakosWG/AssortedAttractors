using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items;

namespace AssortedAttractors.Items.Magnets
{
    class CeaselessMagnet : MagnetBase
    {
        public CeaselessMagnet()
        {
            range = 500;
            speed = 3f;
            maxSpeed = 12f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Strongly attracts souls, hearts, stars, dolls and coins");
            DisplayName.SetDefault("Mobius Loop");

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 5));
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(0, 50, 0, 0);

            if (AssortedAttractors.calamityMod != null) calamityRarityIntegration();
        }

        private void calamityRarityIntegration()
        {
            item.GetGlobalItem<CalamityGlobalItem>().customRarity = CalamityMod.CalamityRarity.Turquoise;
        }

        public override void AddRecipes()
        {
            if(AssortedAttractors.calamityMod != null && AssortedAttractors.calamityMod.ItemType("DarkPlasma") != 0 
                && AssortedAttractors.calamityMod.ItemType("GalacticaSingularity") != 0 && AssortedAttractors.calamityMod.ItemType("Phantoplasm") != 0)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<MoonMagnet>());
                recipe.AddIngredient(AssortedAttractors.calamityMod.ItemType("DarkPlasma"), 5);
                recipe.AddIngredient(AssortedAttractors.calamityMod.ItemType("GalacticaSingularity"), 10);
                recipe.AddIngredient(AssortedAttractors.calamityMod.ItemType("Phantoplasm"), 5);
                recipe.AddTile(TileID.LunarCraftingStation);
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

        }
    }
}

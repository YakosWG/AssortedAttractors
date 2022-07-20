using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class VoodooMagnet : MagnetBase
    {
        public static int rangeModifier = 500;
        public static float speedModifier = 0.5f;
        public static float maxSpeedModifier = 10f;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Improves attraction of voodoo dolls. Needs another magnet to work!");
            DisplayName.SetDefault("Miniature Voodoo Demon");

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(30, 2));
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 6, 97, 0);
            Item.width = 82;
            Item.height = 94;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "MagnetInfo", 
                "Range: +" + rangeModifier
                + "\nSpeed: +" + speedModifier
                + "\nMax Speed: +"+ maxSpeedModifier
                + "\nFavorite this item to enable it!");
            tooltips.Insert(tooltips.Count - 1, line);
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<VoodooMagnet>());
            recipe.AddIngredient(ModContent.ItemType<SuperheatedMagnet>());
            recipe.AddIngredient(ItemID.TargetDummy);
            recipe.AddTile(TileID.BewitchingTable);
            recipe.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited) //This magnet stacks with others because of its unique effect
                return;

            player.GetModPlayer<MagnetPlayer>().voodooMagnet = true;

        }
    }
}

﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class TrueMidnightMagnet : MagnetBase
    {
        public TrueMidnightMagnet()
        {
            range = 150;
            speed = 1.5f;
            maxSpeed = 6f;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Strongly attracts souls and stars");
            DisplayName.SetDefault("Midnight's Reception");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.sellPrice(0, 20, 0, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MidnightMagnet>());
            recipe.AddIngredient(ItemID.SoulofFright, 3);
            recipe.AddIngredient(ItemID.SoulofMight, 3);
            recipe.AddIngredient(ItemID.SoulofSight, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
            player.manaMagnet = false; //Custom mana magnet is better than vanilla celestial at this point
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true; 
            player.GetModPlayer<MagnetPlayer>().soulMagnet = true;

        }
    }
}

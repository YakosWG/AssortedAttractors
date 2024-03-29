﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class FishronMagnet : MagnetBase
    {
        public FishronMagnet()
        {
            range = 22;
            speed = 1.8f;
            maxSpeed = 8f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            // Tooltip.SetDefault("Stronger underwater and during rain");
            // DisplayName.SetDefault("Tidal Force");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(0, 15, 0, 0);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "MagnetInfo",
                "Range: " + (int)Math.Floor(range * ModContent.GetInstance<AssortedAttractorsConfig>().rangeMult) + " Tiles"
                + "\nSpeed: " + speed * ModContent.GetInstance<AssortedAttractorsConfig>().speedMult
                + "\nMax Speed: " + maxSpeed * ModContent.GetInstance<AssortedAttractorsConfig>().speedMult
                + "\nFavorite this item to enable it!"); ;

            if (Main.player[Main.myPlayer].wet || Main.raining)
            {
                line = new TooltipLine(Mod, "MagnetInfo",
                "Range: " + (int)Math.Floor(2 * range * ModContent.GetInstance<AssortedAttractorsConfig>().rangeMult) + " Tiles"
                + "\nSpeed: " + ((speed * ModContent.GetInstance<AssortedAttractorsConfig>().speedMult) + 0.2f)
                + "\nMax Speed: " + ((maxSpeed * ModContent.GetInstance<AssortedAttractorsConfig>().speedMult) + 4f)
                + "\nFavorite this item to enable it!");
            }
            
            tooltips.Insert(tooltips.Count - 1, line);
        }

        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().ParseMagnet(this.range, this.speed, this.maxSpeed);
            player.GetModPlayer<MagnetPlayer>().waterBonus = true;

        }
    }
}

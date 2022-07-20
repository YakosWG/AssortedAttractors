using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using Terraria.Localization;

namespace AssortedAttractors.Items.Magnets
{
    class MagnetBase : ModItem
    {

        protected int range = 0; //Range that items start getting pulled from. range 19 ~ 3 tiles
        protected float speed = 0f; //Accelleration is 1 + speed
        protected float maxSpeed = 0f; //Maximum base velocity item is pulled at. X, Y speed capped individually, Max speed is relative to player velocity


        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(String.Empty);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(mod, "MagnetInfo",
                "Range: " + (int)Math.Floor(range * ModContent.GetInstance<AssortedAttractorsConfig>().rangeMult)
                + "\nSpeed: " + speed * ModContent.GetInstance<AssortedAttractorsConfig>().speedMult
                + "\nMax Speed: " + maxSpeed * ModContent.GetInstance<AssortedAttractorsConfig>().speedMult
                + "\nFavorite this item to enable it!");
            tooltips.Insert(tooltips.Count - 1, line);
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
        }

        public override void UpdateInventory(Player player)
        {
            if (!this.item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().parseMagnet(this.range, this.speed, this.maxSpeed);
        }
    }
}

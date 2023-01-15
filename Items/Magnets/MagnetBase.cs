using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using Terraria.Localization;
using Terraria.GameContent.Creative;

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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "MagnetInfo",
                "Range: " + (int)Math.Floor(range * ModContent.GetInstance<AssortedAttractorsConfig>().rangeMult) + " Tiles"
                + "\nSpeed: " + speed * ModContent.GetInstance<AssortedAttractorsConfig>().speedMult
                + "\nMax Speed: " + maxSpeed * ModContent.GetInstance<AssortedAttractorsConfig>().speedMult
                + "\nFavorite this item to enable it!");
            tooltips.Insert(tooltips.Count - 1, line);
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
        }

        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().ParseMagnet(this.range, this.speed, this.maxSpeed);
        }
    }
}

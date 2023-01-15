using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssortedAttractors.Items.Magnets
{
    class MoonMagnet : MagnetBase
    {
        private const int animTime = 300;

        private uint localTime
        {
            get { return Main.GameUpdateCount % (4*animTime); }
            set { }
        }

        public MoonMagnet()
        {
            range = 45;
            speed = 2f;
            maxSpeed = 8f;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Strongly attracts souls, hearts, stars, dolls and coins");
            DisplayName.SetDefault("Lunar Orbit");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 80, 0, 0);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
        }

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {

            Texture2D texture = Mod.Assets.Request<Texture2D>("Items/Magnets/MoonMagnetMask").Value;

            if (localTime < animTime)
            {
                texture = Mod.Assets.Request<Texture2D>("Items/Magnets/MoonMagnetMaskVortex").Value;
            }
            else if (localTime >= animTime && localTime < 2 * animTime)
            {
                texture = Mod.Assets.Request<Texture2D>("Items/Magnets/MoonMagnetMaskSolar").Value;
            }
            else if (localTime >= 2 * animTime && localTime < 3 * animTime)
            {
                texture = Mod.Assets.Request<Texture2D>("Items/Magnets/MoonMagnetMaskNebula").Value;
            }
            else
            {
                texture = Mod.Assets.Request<Texture2D>("Items/Magnets/MoonMagnetMaskStardust").Value;
            }

            float x = ((localTime % animTime) / (float)animTime);
            x = 2*x-1;
            x = -x*x*x*x + 1; //Fast fade in fade out using f(x) = -(2x-1)^4 + 1 

            spriteBatch.Draw(texture, position, frame, drawColor * x, 0f, origin, scale, SpriteEffects.None, 0f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TerraMagnet>());
            recipe.AddIngredient(ModContent.ItemType<VoodooMagnet>());
            recipe.AddIngredient(ItemID.LunarBar, 6);
            recipe.AddIngredient(ItemID.FragmentVortex, 4);
            recipe.AddIngredient(ItemID.FragmentNebula, 4);
            recipe.AddIngredient(ItemID.FragmentSolar, 4);
            recipe.AddIngredient(ItemID.FragmentStardust, 4);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public override void UpdateInventory(Player player)
        {
            if (!this.Item.favorited || player.GetModPlayer<MagnetPlayer>().magnetActive)
                return;

            player.GetModPlayer<MagnetPlayer>().ParseMagnet(this.range, this.speed, this.maxSpeed);
            player.manaMagnet = false; //Custom mana magnet is better than vanilla celestial at this point
            player.goldRing = true;
            player.AddBuff(BuffID.Heartreach, 1);
            player.GetModPlayer<MagnetPlayer>().manaMagnet = true; 
            player.GetModPlayer<MagnetPlayer>().soulMagnet = true;
            player.GetModPlayer<MagnetPlayer>().voodooMagnet = true;

        }
    }
}

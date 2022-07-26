﻿using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using AssortedAttractors.Items.Magnets;

namespace AssortedAttractors
{
    class MagnetPlayer : ModPlayer
    {

        public float magnetGrabSpeed;
        public float magnetGrabSpeedMax;
        public int magnetGrabRange;
        public bool magnetActive;
        public bool manaOnly;
        public bool manaMagnet;
        public bool soulMagnet;
        public bool voodooMagnet;
        public bool waterBonus;
        public bool eventEssenceMagnet;

        public override void ResetEffects()
        {
            magnetActive = false;
            magnetGrabRange = 0;
            magnetGrabSpeed = 0f;
            magnetGrabSpeedMax = 0f;
            manaOnly = false;
            manaMagnet = false;
            soulMagnet = false;
            voodooMagnet = false;
            waterBonus = false;
            eventEssenceMagnet = false;
        }

        public void parseMagnet(int range, float speed, float maxSpeed)
        {
            this.magnetActive = true;

            range = (int) Math.Floor(range* 16 * ModContent.GetInstance<AssortedAttractorsConfig>().rangeMult);
            speed *= ModContent.GetInstance<AssortedAttractorsConfig>().speedMult;
            maxSpeed *= ModContent.GetInstance<AssortedAttractorsConfig>().speedMult;

            this.magnetGrabRange = range;
            this.magnetGrabSpeed = 1 + speed;
            this.magnetGrabSpeedMax = maxSpeed;
        }

        private bool isSoul(int id)
        {
            if (id == ItemID.SoulofNight || id == ItemID.SoulofLight || id == ItemID.SoulofFlight || id == ItemID.SoulofFright 
                || id == ItemID.SoulofMight || id == ItemID.SoulofSight || (id <= 3459 && id >= 3456))
                return true;
            else if (AssortedAttractors.calamityMod != null && (id == AssortedAttractors.calamityMod.Find<ModItem>("EssenceofChaos").Type 
                || id == AssortedAttractors.calamityMod.Find<ModItem>("EssenceofCinder").Type || id == AssortedAttractors.calamityMod.Find<ModItem>("EssenceofEleum").Type
                || id == AssortedAttractors.calamityMod.Find<ModItem>("UnholyEssence").Type))
            {
                return true;
            }
            return false;
        }

        private bool isStar(int id)
        {
            if (id == ItemID.Star || id == ItemID.SugarPlum || id == ItemID.SoulCake)
                return true;
            return false;
        }

        private bool isEventEssence(int id)
        {
            if (AssortedAttractors.calamityMod != null && (id == AssortedAttractors.calamityMod.Find<ModItem>("NightmareFuel").Type
                || id == AssortedAttractors.calamityMod.Find<ModItem>("EndothermicEnergy").Type || id == AssortedAttractors.calamityMod.Find<ModItem>("DarksunFragment").Type))
                return true;
            return false;
        }

        public override void PostUpdate()
        {

            if (!magnetActive)
                return;

            for (int j = 0; j < 400; j++)
            {
                if (!Main.item[j].active || Main.item[j].noGrabDelay != 0 || Main.player[Main.item[j].playerIndexTheItemIsReservedFor] != this.Player 
                    || !ItemLoader.CanPickup(Main.item[j], this.Player))
                {
                    continue;
                }

                int grabRange = Player.defaultItemGrabRange + magnetGrabRange;
                float speed = magnetGrabSpeed;
                float maxSpeed = magnetGrabSpeedMax;

                //Increase range for mana stars and disable bonuses for mana only magnets
                if (isStar(Main.item[j].type)) {
                    if (manaMagnet)
                    {
                        grabRange = Player.defaultItemGrabRange + 4 * magnetGrabRange;
                        speed += speed - 1;
                        maxSpeed *= 1.5f;
                    }
                } else if (manaOnly)
                {
                    continue;
                }

                if (soulMagnet && isSoul(Main.item[j].type))
                { 
                    grabRange = Player.defaultItemGrabRange + 4 * magnetGrabRange;
                    speed += speed - 1;
                    maxSpeed *= 1.5f;
                }

                if (voodooMagnet && Main.item[j].type == ItemID.GuideVoodooDoll)
                {
                    grabRange += VoodooMagnet.rangeModifier*16;
                    speed += VoodooMagnet.speedModifier;
                    maxSpeed += VoodooMagnet.maxSpeedModifier;
                }

                if (waterBonus && (this.Player.wet || Main.raining))
                {
                    grabRange = Player.defaultItemGrabRange + 2 * magnetGrabRange;
                    speed += 0.2f;
                    maxSpeed += 4f;
                }

                if (eventEssenceMagnet && AssortedAttractors.calamityMod != null && isEventEssence(Main.item[j].type))
                {
                    grabRange = Player.defaultItemGrabRange + 4 * magnetGrabRange;
                    speed += speed - 1;
                    maxSpeed *= 1.5f;
                }

                ItemLoader.GrabRange(Main.item[j], this.Player, ref grabRange);

                if (!new Rectangle((int)this.Player.position.X - grabRange, (int)this.Player.position.Y - grabRange, this.Player.width + grabRange * 2, this.Player.height + grabRange * 2).Intersects(new Rectangle((int)Main.item[j].position.X,
                    (int)Main.item[j].position.Y, Main.item[j].width, Main.item[j].height)) || !this.Player.ItemSpace(Main.item[j]).CanTakeItem)
                {
                    continue;
                }
                Main.item[j].beingGrabbed = true;

                //Item grab code
                {
                    float distX = this.Player.Center.X - Main.item[j].Center.X;
                    float distY = this.Player.Center.Y - Main.item[j].Center.Y;
                    float dist = (float)Math.Sqrt(distX * distX + distY * distY);

                    //v_new = v * (1 - 1/speed) + relative_dist * maxSpeed

                    Main.item[j].velocity.X = Utils.Clamp((Main.item[j].velocity.X * (speed - 1) + distX * maxSpeed / dist) / speed, -(maxSpeed + 4f), (maxSpeed + 4f));
                    Main.item[j].velocity.Y = Utils.Clamp((Main.item[j].velocity.Y * (speed - 1) + distY * maxSpeed / dist) / speed, -(maxSpeed + 4f), (maxSpeed + 4f));
                    continue;
                }
                
            }
        }

    }
}

using System;
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

        public void ParseMagnet(int range, float speed, float maxSpeed)
        {
            this.magnetActive = true;

            range = (int) Math.Floor(range* 16 * ModContent.GetInstance<AssortedAttractorsConfig>().rangeMult);
            speed *= ModContent.GetInstance<AssortedAttractorsConfig>().speedMult;
            maxSpeed *= ModContent.GetInstance<AssortedAttractorsConfig>().speedMult;

            this.magnetGrabRange = range;
            this.magnetGrabSpeed = speed;
            this.magnetGrabSpeedMax = maxSpeed;
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
                if (IsStar(Main.item[j].type))
                {
                    if (manaMagnet)
                    {
                        grabRange = Player.defaultItemGrabRange + 4 * magnetGrabRange;
                        speed += speed;
                        maxSpeed *= 1.5f;
                    }
                }
                else if (manaOnly)
                {
                    continue;
                }

                if (soulMagnet && IsSoul(Main.item[j].type))
                {
                    grabRange = Player.defaultItemGrabRange + 4 * magnetGrabRange;
                    speed += speed;
                    maxSpeed *= 1.5f;
                }

                if (voodooMagnet && Main.item[j].type == ItemID.GuideVoodooDoll)
                {
                    grabRange += VoodooMagnet.rangeModifier * 16;
                    speed += VoodooMagnet.speedModifier;
                    maxSpeed += VoodooMagnet.maxSpeedModifier;
                }

                if (waterBonus && (this.Player.wet || Main.raining))
                {
                    grabRange = Player.defaultItemGrabRange + 2 * magnetGrabRange;
                    speed *= 1.5f;
                    maxSpeed *= 1.5f;
                }

                if (eventEssenceMagnet && AssortedAttractors.calamityMod != null && IsEventEssence(Main.item[j].type))
                {
                    grabRange = Player.defaultItemGrabRange + 4 * magnetGrabRange;
                    speed += speed;
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
                    float distance = (float)Math.Sqrt(distX * distX + distY * distY);
                    float playerVelocityX = this.Player.velocity.X;
                    float playerVelocityY = this.Player.velocity.Y;
                    float orbitModifier = 0.9f;

                    //Slow the item to destabilze any orbits
                    Main.item[j].velocity = Main.item[j].velocity * orbitModifier;

                    //Move the item toward the player
                    Main.item[j].velocity.X = Utils.Clamp((Main.item[j].velocity.X + distX / distance * speed), -(maxSpeed + 4f) + playerVelocityX, maxSpeed + 4f + playerVelocityX);
                    Main.item[j].velocity.Y = Utils.Clamp((Main.item[j].velocity.Y + distY / distance * speed), -(maxSpeed + 4f) + playerVelocityY, maxSpeed + 4f + playerVelocityY);

                    continue;
                }

            }
        }

        private static bool IsSoul(int id)
        {
            if (id == ItemID.SoulofNight || id == ItemID.SoulofLight || id == ItemID.SoulofFlight || id == ItemID.SoulofFright
                || id == ItemID.SoulofMight || id == ItemID.SoulofSight || (id <= 3459 && id >= 3456))
            {

                return true;
            }
            else if (AssortedAttractors.calamityMod != null && 
                (
                   id == AssortedAttractors.calamityMod.Find<ModItem>("EssenceofChaos").Type
                || id == AssortedAttractors.calamityMod.Find<ModItem>("EssenceofCinder").Type 
                || id == AssortedAttractors.calamityMod.Find<ModItem>("EssenceofEleum").Type
                || id == AssortedAttractors.calamityMod.Find<ModItem>("UnholyEssence").Type 
                || id == AssortedAttractors.calamityMod.Find<ModItem>("MeldBlob").Type
                ))
            {
                return true;
            }
            return false;
        }

        private static bool IsStar(int id)
        {
            if (id == ItemID.Star || id == ItemID.SugarPlum || id == ItemID.SoulCake)
                return true;
            return false;
        }

        private static bool IsEventEssence(int id)
        {
            if (AssortedAttractors.calamityMod != null && 
                (
                   id == AssortedAttractors.calamityMod.Find<ModItem>("NightmareFuel").Type
                || id == AssortedAttractors.calamityMod.Find<ModItem>("EndothermicEnergy").Type 
                || id == AssortedAttractors.calamityMod.Find<ModItem>("DarksunFragment").Type
                ))
                return true;
            return false;
        }

       

    }
}

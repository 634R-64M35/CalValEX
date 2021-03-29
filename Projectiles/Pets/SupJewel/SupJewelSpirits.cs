﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class SpookShark : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantoshark");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 38;
            projectile.height = 19;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 3400f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 12f;
            inertia = 60f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f;
            offSetX = 48f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -50f; //how much higher from the center the pet should float
        }
        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "Projectiles/Pets/LightPets/SupJewel/SpookShark_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(207, 117, 56);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        private float extraScale;
        private float rotation;
        private bool yep = false;

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;
            if (modPlayer.darksunSpirits)
                projectile.timeLeft = 2;

            rotation += 0.1f;
            if (extraScale > 0.25f && !yep)
                yep = true;
            if (extraScale < -0.10f && yep)
                yep = false;

            if (!yep)
                extraScale += 0.01f;
            if (yep)
                extraScale -= 0.01f;
        }

        public override void SafePreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player player = Main.player[projectile.owner];
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura");
            Texture2D texture2 = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/EndoAura_Glow");
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width, texture.Height);
            Lighting.AddLight(player.position, new Vector3(1.01470588f, 0.573529411f, 0.274509804f));
            spriteBatch.Draw(texture, player.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            spriteBatch.Draw(texture2, player.Center - Main.screenPosition, sourceRectangle, Color.White, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
        }
    }

    public class SpookSmall : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantofish");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 26;
            projectile.height = 20;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 3400f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 20f;
            inertia = 80f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f;
            offSetX = 16f * Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = 0f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "Projectiles/Pets/LightPets/SupJewel/SpookSmall_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(207, 117, 56);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;
            if (modPlayer.darksunSpirits)
                projectile.timeLeft = 2;
        }
    }

    public class Bishop : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Sun Elemental");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 14;
            projectile.height = 10;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 3400f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 18f;
            inertia = 70f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f;
            offSetX = 16f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = 0f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "Projectiles/Pets/LightPets/SupJewel/Bishop_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(207, 117, 56);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;
            if (modPlayer.darksunSpirits)
                projectile.timeLeft = 2;
        }
    }

    public class EndoRune : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endo Runes");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 14;
            projectile.height = 10;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 3400f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 18f;
            inertia = 70f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f;
            offSetX = 16f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = 0f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "Projectiles/Pets/LightPets/SupJewel/EndoRune_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(207, 117, 56);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;
            if (modPlayer.darksunSpirits)
                projectile.timeLeft = 2;
        }
    }

    public class NWings : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arctic Shield");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.damage = 0;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.hostile = false;
            projectile.width = 98;
            projectile.height = 98;
            projectile.aiStyle = -1;
            projectile.netImportant = true;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Lighting.AddLight(projectile.Center, new Vector3(0.541176471f, 1f, 1f));
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, projectile.GetAlpha(lightColor), projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.None, 0f);
            return false;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Lightshield = false;
            if (modPlayer.Lightshield)
                projectile.timeLeft = 2;

            Vector2 idlePosition = player.Center;
            idlePosition.Y -= projectile.height / 2;
            idlePosition.X -= projectile.width / 2;
            projectile.position = idlePosition;
            projectile.spriteDirection = 1;

            projectile.rotation += -0.75f;
            if (projectile.rotation > MathHelper.TwoPi)
            {
                projectile.rotation -= MathHelper.TwoPi;
            }
            else if (projectile.rotation < 0)
            {
                projectile.rotation += MathHelper.TwoPi;
            }

            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                calamityMod.Call("AddAbyssLightStrength", projectile.owner, 2);
            }
        }
    }
}
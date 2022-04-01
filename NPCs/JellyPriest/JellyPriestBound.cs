using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.JellyPriest
{
    public class JellyPriestBound : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bound Jelly Priestess");
            Main.npcFrameCount[NPC.type] = 1;
        }

        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.npcSlots = 5f;
            NPC.width = 18;
            NPC.height = 34;
            NPC.aiStyle = 0;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            NPC.rarity = 1;
            NPC.dontTakeDamageFromHostiles = true;
        }

        public override bool CanChat()
        {
            return true;
        }

        public override void AI()
        {
            NPC.breath += 2;
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active && Main.player[i].talkNPC == NPC.whoAmI)
                {
                    CalValEXWorld.rescuedjelly = true;
                    CalValEXWorld.UpdateWorldBool();
                    NPC.Transform(ModContent.NPCType<JellyPriestNPC>());
                    NPC.netUpdate = true;
                    if (!NPC.AnyNPCs(ModContent.NPCType<JellyPriestNPC>()))
                    {
                        NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<JellyPriestNPC>());
                        NPC.active = false;
                    }
                    return;
                }
            }
        }

        public override string GetChat()
        {
            return "Greetings, land creature! I rise from this old sea in hopes of traveling and finding a certain deity from the old times, from when the sea was a beautiful reign for many. Do you have any hint about where I could find them?";         
        }

        /*void Awaken()
        {
            for (int blah = 0; blah <= 20; blah++)
            {
                NPC.ai[3]++;
            }
            if (NPC.ai[3] >= 4)
            {
                NPC.Transform(ModContent.NPCType<JellyPriestNPC>());
            }
        }*/

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedBoss1 && !CalValEXConfig.Instance.TownNPC && !CalValEXWorld.rescuedjelly && spawnInfo.player.ZoneBeach && !NPC.AnyNPCs(ModContent.NPCType<JellyPriestBound>()) && !NPC.AnyNPCs(ModContent.NPCType<JellyPriestNPC>()))
            {
                return 0.5f;
            }
            else
            {
                return 0f;
            }
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            if (projectile.friendly)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            damage = 1;
            crit = false;
            knockback = 0;
            NPC.Transform(ModContent.NPCType<JellyPriestNPC>());
            return false;
        }

        /*public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/JellyPriest"), 1f);
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/JellyPriest2"), 1f);
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/JellyPriest3"), 1f);
            }
        }*/
    }
}
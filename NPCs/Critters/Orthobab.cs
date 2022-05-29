using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    public class Orthobab : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Orthocera Hatchling");
            Main.npcFrameCount[NPC.type] = 6;
            Main.npcCatchable[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 20;
            NPC.height = 24;
            NPC.aiStyle = 16;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit38;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.npcSlots = 0.25f;
            NPC.catchItem = (short)ItemType<OrthobabItem>();
            NPC.lavaImmune = false;
            //NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.Goldfish;
            AnimationType = NPCID.Goldfish;
            NPC.lifeMax = 5;
            for (int i = 0; i < NPC.buffImmune.Length; i++)
            {
                NPC.buffImmune[ModContent.BuffType<CalamityMod.Buffs.DamageOverTime.SulphuricPoisoning>()] = false;
            }
            SpawnModBiomes = new int[1] { ModContent.GetInstance<CalamityMod.BiomeManagers.SulphurousSeaBiome>().Type };
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("Newer offspring of The Shelled. Despite their bumbling appearance, any one of these may very well grow into something horrific."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            //if (clamMod != null)
            {
                if (spawnInfo.Player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>().ZoneSulphur && !CalValEXConfig.Instance.CritterSpawns)
                {
                    return 0.35f;
                }
            }
            return 0f;
        }

        public override void OnCaughtBy(Player player, Item item, bool failed)
        {
            Item.NewItem(new EntitySource_CatchEntity(player, NPC), new Vector2(player.position.X, player.position.Y), ItemType<OrthobabItem>());
        }

        // TODO: Hooks for Collision_MoveSnailOnSlopes and NPC.aiStyle = 67 problem
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;
using CalValEX.Items.Hooks;

namespace CalValEX.Items.Equips
{
	[AutoloadEquip(EquipType.Head)]
	public class BanditHat : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bandit's Hat");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 12;
			item.rare = 3;
			item.vanity = true;
			item.value = Item.sellPrice(0, 3, 0, 0);
		}

		public virtual void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
		drawHair = true;
		drawAltHair = true;
		}
	}
}
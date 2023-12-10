﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DragonballPichu.Content.Buffs
{
    internal class PUBuff : TransformationBuff
    {
        public static new readonly int DefenseBonus = 13;
        public static new readonly float KiDrain = 10;
        public static new readonly float SpeedBonus = 1.25f;
        public static new readonly float DamageBonus = 1.15f;
        public static new readonly string name = "PU";
        public static new readonly Boolean isStackable = true;

        public override LocalizedText Description => base.Description;

        public override void Update(Player player, ref int buffIndex)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();

            

            
            float formDefenseMastery = modPlayer.getStat(name + "FormMultDefense").getValue();
            float formDamageMastery = modPlayer.getStat(name + "FormMultDamage").getValue();

            int defenseToAdd = (int)(DefenseBonus * formDefenseMastery);
            player.statDefense += defenseToAdd;

            player.GetDamage(DamageClass.Generic) *= (1 + ((DamageBonus-1) * formDamageMastery));
        }
    }
}

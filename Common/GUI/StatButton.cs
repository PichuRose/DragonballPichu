﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonballPichu.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace DragonballPichu.Common.GUI
{
    internal class StatButton : UIPanel
    {
        public string text;
        public string statName;
        public float statIncreasePerClick;
        UIText sideText = new UIText("",textScale: .8f);
        public StatButton(string text, string statName, float statIncreasePerClick)
        {
            this.text = text;
            this.statName = statName;
            this.statIncreasePerClick = statIncreasePerClick;
        }

        public override void OnInitialize()
        {
            OnLeftClick += this.OnButtonClick;
            Width.Set(35, 0);
            Height.Set(35, 0);
            //HAlign = 0.5f;
            Top.Set(0, 0);
            Left.Set(0, 0);
            sideText.SetText(text);
            sideText.Left.Set(25,0);
            Append(sideText);
        }

        public override void Update(GameTime gameTime)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();
            
            base.Update(gameTime);
            Stat stat = modPlayer.getStat(statName);
            if(stat ==  null)
            {
                sideText.SetText(text + " " + statName);
            }
            else
            {
                //"MultKi" "DivideDrain" "MultDamage" "MultSpeed" "MultDefense" "Special"
                string toText = "";
                switch (stat.name)
                {
                    case "MultKi":
                        toText = text + " " + statName;
                        sideText.SetText(toText);
                        return;
                    case "DivideDrain":
                        toText = text + " " + statName;
                        sideText.SetText(toText);
                        return;
                    case "MultDamage":
                        toText = text + " " + statName;
                        sideText.SetText(toText);
                        return;
                    case "MultSpeed":
                        toText = text + " " + statName;
                        sideText.SetText(toText);
                        return;
                    case "MultDefense":
                        toText = text + " " + statName;
                        sideText.SetText(toText);
                        return;
                    case "Special":
                        toText = text + " " + statName;
                        sideText.SetText(toText);
                        return;
                    default:
                        toText = text + " " + statName + ": " + statIncreasePerClick + "/" + stat.getValue();
                        sideText.SetText(toText);
                        return;

                }

                
                

            }
            /*
             else
            {
                if(statName != null && statName.Contains("Form"))
                {
                    String[] parsed = statName.Split("Form");
                    if (parsed.Length == 2)
                    {
                        string toText = text;
                        toText += " ";
                        toText += parsed[1];
                        sideText.SetText(toText);
                    }
                }

                
                
                //toText += ": +";
                //toText += statIncreasePerClick;
                //toText += "/";
                //toText += stat.getValue();
                
                

            }*/
        }

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();
            Stat stat = modPlayer.getStat(statName);
            if(stat != null)
            {
                if (statName.Contains("Form"))
                {
                    String[] info = statName.Split("Form");
                    FormStats stats = modPlayer.nameToStats[info[0]];
                    if (stats.usePoint())
                    {
                        stat.increaseValue(statIncreasePerClick);
                    }
                }
                else
                {
                    if (modPlayer.usePoint())
                    {
                        stat.increaseValue(statIncreasePerClick);
                    }
                }
            }
            
            //var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();
            //modPlayer.setSelectedForm(this.name);
        }
    }
}

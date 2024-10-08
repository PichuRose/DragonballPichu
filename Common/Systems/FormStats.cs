﻿using DragonballPichu.Common.Configs;
using DragonballPichu.Common.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;


namespace DragonballPichu.Common.Systems
{
    public class FormStats
    {
        public Stat MultKi = new Stat("MultKi", 1);
        public Stat DivideDrain = new Stat("DivideDrain", 1);
        public Stat MultDamage = new Stat("MultDamage", 1);
        public Stat MultSpeed = new Stat("MultSpeed", 1);
        public Stat MultDefense = new Stat("MultDefense", 1);
        public Stat Special = new Stat("Special", 1);
        public List<string> specialEffectValue; 

        float experience = 0;
        int level = 0;
        int points = 0;
        int levelInAll = 0;
        string form;

        public FormStats(string form)
        {
            this.form = form;
            specialEffectValue = new List<string>();
            specialEffectValue.Add(getRandomSpecial());
            specialEffectValue.Add(getRandomSpecialEffect(specialEffectValue[0]));
        }


        /*
Dodge(Type 1: UI, Type 2: TUI) [ Ki Cost Reduction ]
HP Power(0.5 - 1.5, 0.75 - 1.25, 0.8 - 1.2)
Regen [Life Regen Multiplier]
Ki Power(0.5 - 1.5, 0.75 - 1.25, 0.8 - 1.2)
Kaio-Efficient(Reduces Kaioken drain when stacking)
DR [Multiplier]
Ki Attack Master [ Charge Time Reduction ]
Aura Defense [Defense Gain Multiplier]
Special Compatibility [ Form Stacking Cost Reduction ]
Second Wind [ level of second wind, invulnerable, damage boost, hp threshold ]
Frantic Ki Regen [ multiplier ]
         */

        public string getRandomSpecialEffect(string special)
        {
            if (form.Equals("UI") || form.Equals("UILB"))
            {
                return "1";
            }
            else if (form.Equals("TUI"))
            {
                return "2";
            }
            Random r = new Random();
            switch (special)
            {
                case "HP Power":
                    switch (r.Next(3))
                    {
                        case 0: return "0.5-1.5";
                        case 1: return "0.75-1.25";
                        case 2: return "0.8-1.2";
                        default: return "1-1";
                    }
                case "Regen":
                    return "1";
                case "Ki Power":
                    switch (r.Next(3))
                    {
                        case 0: return "0.5-1.5";
                        case 1: return "0.75-1.25";
                        case 2: return "0.8-1.2";
                        default: return "1-1";
                    }
                case "Kaio-Efficient":
                    return "1";
                case "DR":
                    return "0.5";
                case "Ki Attack Master":
                    return "1";
                case "Aura Defense":
                    return "10";
                case "Special Compatibility":
                    return "1";
                case "Second Wind":
                    return "1";
                case "Frantic Ki Regen":
                    return "1";
                default:
                    return "";
            }
        }


        public string getRandomSpecial()
        {
            if(form.Equals("UI") || form.Equals("TUI") || form.Equals("UILB"))
            {
                return "Dodge";
            }
            Random r = new Random();
            int random = r.Next(11);
            switch (random)
            {
                case 1:
                    return "HP Power";
                case 2:
                    return "Regen";
                case 3:
                    return "Ki Power";
                case 4:
                    return "Kaio-Efficient";
                case 5:
                    return "DR";
                case 6:
                    return "Ki Attack Master";
                case 7:
                    return "Aura Defense";
                case 8:
                    return "Special Compatibility";
                case 9:
                    return "Second Wind";
                case 10:
                    return "Frantic Ki Regen";
                default:
                    return "";
            }

            
        }

        public float expNeededToAdvanceLevel()
        {
            float expNeeded;
            //x^e, default, 1.1^x, 1.1^e
            switch (ModContent.GetInstance<ServerConfig>().levelScaling)
            {
                case "x^e":
                    expNeeded = ((float)Math.Pow(level + 1, Math.E) + 100);
                    break;
                case "1.1^x":
                    expNeeded = ((float)Math.Pow(1.1, level+1) * 100)+1000;
                    break;
                case "1.1^e":
                    expNeeded = ((float)(Math.Pow(1.1, Math.E)*500*level+1));
                    break;
                default:
                    expNeeded = ((float)Math.Pow(level + 1, 1.5)) * 100;
                    break;
            }

            //level^1.5 * 100
            
            //level^e + 100
            

            return expNeeded;
        }

        public void levelUp()
        {

            float expNeeded = expNeededToAdvanceLevel();
            while (experience > expNeeded)
            {
                experience -= expNeeded;
                increaseLevel();
                expNeeded = expNeededToAdvanceLevel();
            }


        }

        public void gainExperience(float experience)
        {
            this.experience += experience;
            levelUp();
        }

        public void unlockIfLevel(int level, int needed, string form)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();
            DragonballPichuUISystem modSystem = ModContent.GetInstance<DragonballPichuUISystem>();
            if (level >= needed && !modPlayer.unlockedForms.Contains(form))
            {
                if (FormTree.isFormAvailable(form))
                {
                    modSystem.MyFormsStatsUI.unlockForm(form);
                }
                else
                {
                    Main.NewText("Can't access " + form + "! You are not on the right character path");
                }
            }
        }

        public void setUnlockConditionIfLevel(int level, int needed, string form)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();
            DragonballPichuUISystem modSystem = ModContent.GetInstance<DragonballPichuUISystem>();
            if (level >= needed && !modPlayer.unlockedForms.Contains(form))
            {
                modPlayer.setUnlockCondition("form", true);
            }
        }

        public static void unlockAndTransform(string form)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();
            DragonballPichuUISystem modSystem = ModContent.GetInstance<DragonballPichuUISystem>();
            if (modPlayer.unlockedForms.Contains(form)) return;
            if (FormTree.isFormAvailable(form))
            {
                modSystem.MyFormsStatsUI.unlockForm(form);
                modPlayer.currentBuff = form;
                modPlayer.currentBuffID = FormTree.formNameToID(modPlayer.currentBuff);
                modPlayer.isTransformed = true;
            }
            else
            {
                Main.NewText("Can't access " + form + "! You are not on the right character path");
            }
            
            
        }

        public void increaseLevel()
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();
            DragonballPichuUISystem modSystem = ModContent.GetInstance<DragonballPichuUISystem>();
            level += 1;
            points++;
            if(level % 5 == 0)
            {
                levelInAll++;
                increaseAll(1);
            }

            switch (form)
            {
                case "SSJ1":
                    unlockIfLevel(level, 5, "SSJ1G2");
                    unlockIfLevel(level, 10, "SSJ1G4");
                    break;
                case "SSJ1G2":
                    unlockIfLevel(level, 5, "SSJ1G3");
                    break;
                case "SSJR1":
                    unlockIfLevel(level, 5, "SSJR1G2");
                    unlockIfLevel(level, 10, "SSJR1G4");
                    break;
                case "SSJR1G2":
                    unlockIfLevel(level, 5, "SSJR1G3");
                    break;
                case "SSJR1G4":
                    unlockIfLevel(level, 10, "Divine");
                    break;
                case "SSJ5":
                    unlockIfLevel(level, 5, "SSJ5G2");
                    unlockIfLevel(level, 10, "SSJ5G4");
                    break;
                case "SSJ5G2":
                    unlockIfLevel(level, 5, "SSJ5G3");
                    break;
                case "SSJB1":
                    unlockIfLevel(level, 5, "SSJB1G2");
                    unlockIfLevel(level, 10, "SSJB1G4");
                    break;
                case "SSJB1G2":
                    unlockIfLevel(level, 5, "SSJB1G3");
                    break;


            }

            
        }
        public void setLevel(int level)
        {
            this.level = level;
            this.points = level;
            levelInAll = (level / 5);
            //respec();
        }

        public Stat getStat(string statName)
        {
            switch(statName)
            {
                case "MultKi":
                    return MultKi;
                case "DivideDrain":
                    return DivideDrain;
                case "MultDamage":
                    return MultDamage;
                case "MultSpeed":
                    return MultSpeed;
                case "MultDefense":
                    return MultDefense;
                case "Special":
                    return Special;
                default:
                    return null;
            }
        }

        public float getExperience() 
        {
            return experience;
        }

        public int getLevel()
        {
            return level;
        }

        public int getPoints()
        {
            return points;
        }

        public void setPoints(int setPoints)
        {
            points = setPoints;
        }

        public Boolean usePoint()
        {
            if(points >= 1)
            {
                points--;
                return true;
            }
            return false;
        }

        public void respec()
        {
            points = level;
            MultKi.setValue(1f);
            DivideDrain.setValue(1f);
            MultDamage.setValue(1f);
            MultSpeed.setValue(1f);
            MultDefense.setValue(1f);
            Special.setValue(1f);

            increaseAll(levelInAll);
        }

        public void increaseAll(int num)
        {
            MultKi.increaseValue(0.1f * num);
            DivideDrain.increaseValue(0.1f * num);
            MultDamage.increaseValue(0.1f* num);
            MultSpeed.increaseValue(0.1f* num);
            MultDefense.increaseValue(0.1f* num);
            Special.increaseValue(0.1f * num);
        }
    }
}

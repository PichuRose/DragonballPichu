﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SteelSeries.GameSense;
using Terraria.GameContent;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace DragonballPichu.Common.GUI
{

    internal class GUIArrow : UIElement
    {
        //float vAlign;
        //float hAlign;
        Boolean isVertical;
        Color color;
        Boolean deactivated;
        string destinationForm;
        string originForm;

        public GUIArrow(Boolean isVertical, Color color, Boolean deactivated, string originForm, string destinationForm)
        {
            this.isVertical = isVertical;
            this.color = color;
            this.deactivated = deactivated;
            this.destinationForm = destinationForm;
            this.originForm = originForm;
        }


        public override void OnInitialize()
        {
            base.OnInitialize();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // This prevents drawing unless the ki is below 95%
            //var modPlayer = Main.LocalPlayer.GetModPlayer<DragonballPichuPlayer>();
            //if (modPlayer.getKiPercentage() >= .95)
            //return;

            base.Draw(spriteBatch);
        }

        public override void OnDeactivate()
        {
            deactivated = true;
        }

        public override void OnActivate()
        {
            deactivated = false;
        }

        private void DrawArrowFromLeft(SpriteBatch spriteBatch)
        {
            DragonballPichuUISystem modSystem = ModContent.GetInstance<DragonballPichuUISystem>();
            if (modSystem == null) { return; }
            //if (!modSystem.MyFormsStatsUI.nameToFormUnlockButton.ContainsKey(originForm)) { return; }
            if (!modSystem.MyFormsStatsUI.nameToFormUnlockButton.ContainsKey(destinationForm)) { return; }
            //FormButton originFormUnlockButton = modSystem.MyFormsStatsUI.nameToFormUnlockButton[originForm];
            FormButton destinationUnlockFormButton = modSystem.MyFormsStatsUI.nameToFormUnlockButton[destinationForm];
            CalculatedStyle formUnlockDimensions = modSystem.MyFormsStatsUI.formsPanel.GetDimensions();
            CalculatedStyle dimensions = GetDimensions();
            CalculatedStyle destination = destinationUnlockFormButton.icon.GetDimensions();
            int centerLine = (int)(dimensions.Y + destinationUnlockFormButton.icon.Height.Pixels / 3);
            Point point = new Point((int)(formUnlockDimensions.X+3), centerLine - 2);
            Point point2 = new Point((int)destination.X - 2, centerLine + 2);
            //Point point2 = new Point(point.X + 100, point.Y + 20);
            int width = point2.X - point.X;
            int height = point2.Y - point.Y;
            //spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(0, 100, 100, 4), this.color);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(point.X, point.Y, width, height), this.color);
        }

        private void DrawVerticalArrowDown(SpriteBatch spriteBatch)
        {
            DragonballPichuUISystem modSystem = ModContent.GetInstance<DragonballPichuUISystem>();
            if (modSystem == null) { return; }
            if (!modSystem.MyFormsStatsUI.nameToFormUnlockButton.ContainsKey(originForm)) { return; }
            if (!modSystem.MyFormsStatsUI.nameToFormUnlockButton.ContainsKey(destinationForm)) { return; }
            FormButton originFormUnlockButton = modSystem.MyFormsStatsUI.nameToFormUnlockButton[originForm];
            FormButton destinationUnlockFormButton = modSystem.MyFormsStatsUI.nameToFormUnlockButton[destinationForm];
            CalculatedStyle dimensions = GetDimensions();
            CalculatedStyle destination = destinationUnlockFormButton.icon.GetDimensions();
            Point point = new Point((int)(dimensions.X + originFormUnlockButton.icon.Width.Pixels / 3 - 2), (int)(dimensions.Y + originFormUnlockButton.icon.Height.Pixels / 1.5));
            Point point2 = new Point((int)(destination.X + destinationUnlockFormButton.icon.Width.Pixels / 3 + 2), (int)(destination.Y));
            //Point point2 = new Point(point.X + 100, point.Y + 20);
            int width = Math.Abs(point2.X - point.X);
            int height = Math.Abs(point2.Y - point.Y);

            //spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(point.X, point.Y, 500, 500), this.color);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(point.X, point.Y, width, height), this.color);
        }

        private void DrawArrow(SpriteBatch spriteBatch)
        {
            DragonballPichuUISystem modSystem = ModContent.GetInstance<DragonballPichuUISystem>();
            if (modSystem == null) { return; }
            if (!modSystem.MyFormsStatsUI.nameToFormUnlockButton.ContainsKey(originForm)) { return; }
            if (!modSystem.MyFormsStatsUI.nameToFormUnlockButton.ContainsKey(destinationForm)) { return; }
            FormButton originFormUnlockButton = modSystem.MyFormsStatsUI.nameToFormUnlockButton[originForm];
            FormButton destinationUnlockFormButton = modSystem.MyFormsStatsUI.nameToFormUnlockButton[destinationForm];
            CalculatedStyle dimensions = GetDimensions();
            CalculatedStyle destination = destinationUnlockFormButton.icon.GetDimensions();
            Point point = new Point((int)(dimensions.X + originFormUnlockButton.icon.Width.Pixels / 1.5), (int)(dimensions.Y + originFormUnlockButton.icon.Height.Pixels / 3 - 2));
            Point point2 = new Point((int)destination.X - 2, (int)(dimensions.Y + destinationUnlockFormButton.icon.Height.Pixels / 3 + 2));
            //Point point2 = new Point(point.X + 100, point.Y + 20);
            int width = point2.X - point.X;
            int height = point2.Y - point.Y;

            spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(point.X, point.Y, width, height), this.color);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (deactivated || destinationForm == null)
            {
                return;
            }
            base.DrawSelf(spriteBatch);
            if(isVertical)
            {
                DrawVerticalArrowDown(spriteBatch);
            }
            else if(originForm == null || originForm == "baseForm")
            {
                DrawArrowFromLeft(spriteBatch);
            }
            else
            {
                DrawArrow(spriteBatch);
            }
            //new Rectangle(x,y,width,height)
        }

        protected override void DrawChildren(SpriteBatch spriteBatch)
        {
            if (deactivated)
            {
                return;
            }
            base.DrawChildren(spriteBatch);
        }

        // Here we draw our UI
    }
}

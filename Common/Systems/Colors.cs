﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Humanizer.In;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace DragonballPichu.Common.Systems
{
    internal class Colors
    {
        Color Transparent = Color.Transparent;
        Color AliceBlue = Color.AliceBlue;
        Color AntiqueWhite = Color.AntiqueWhite;
        Color Aqua = Color.Aqua;
        Color Aquamarine = Color.Aquamarine;
        Color Azure = Color.Azure;
        Color Beige = Color.Beige;
        Color Bisque = Color.Bisque;
        Color Black = Color.Black;
        Color BlanchedAlmond = Color.BlanchedAlmond;
        Color Blue = Color.Blue;
        Color BlueViolet = Color.BlueViolet;
        Color Brown = Color.Brown;
        Color BurlyWood = Color.BurlyWood;
        Color CadetBlue = Color.CadetBlue;
        Color Chartreuse = Color.Chartreuse;
        Color Chocolate = Color.Chocolate;
        Color Coral = Color.Coral;
        Color CornflowerBlue = Color.CornflowerBlue;
        Color Cornsilk = Color.Cornsilk;
        Color Crimson = Color.Crimson;
        Color Cyan = Color.Cyan;
        Color DarkBlue = Color.DarkBlue;
        Color DarkCyan = Color.DarkCyan;
        Color DarkGoldenrod = Color.DarkGoldenrod;
        Color DarkGray = Color.DarkGray;
        Color DarkGreen = Color.DarkGreen;
        Color DarkKhaki = Color.DarkKhaki;
        Color DarkMagenta = Color.DarkMagenta;
        Color DarkOliveGreen = Color.DarkOliveGreen;
        Color DarkOrange = Color.DarkOrange;
        Color DarkOrchid = Color.DarkOrchid;
        Color DarkRed = Color.DarkRed;
        Color DarkSalmon = Color.DarkSalmon;
        Color DarkSeaGreen = Color.DarkSeaGreen;
        Color DarkSlateBlue = Color.DarkSlateBlue;
        Color DarkSlateGray = Color.DarkSlateGray;
        Color DarkTurquoise = Color.DarkTurquoise;
        Color DarkViolet = Color.DarkViolet;
        Color DeepPink = Color.DeepPink;
        Color DeepSkyBlue = Color.DeepSkyBlue;
        Color DimGray = Color.DimGray;
        Color DodgerBlue = Color.DodgerBlue;
        Color Firebrick = Color.Firebrick;
        Color FloralWhite = Color.FloralWhite;
        Color ForestGreen = Color.ForestGreen;
        Color Fuchsia = Color.Fuchsia;
        Color Gainsboro = Color.Gainsboro;
        Color GhostWhite = Color.GhostWhite;
        Color Gold = Color.Gold;
        Color Goldenrod = Color.Goldenrod;
        Color Gray = Color.Gray;
        Color Green = Color.Green;
        Color GreenYellow = Color.GreenYellow;
        Color Honeydew = Color.Honeydew;
        Color HotPink = Color.HotPink;
        Color IndianRed = Color.IndianRed;
        Color Indigo = Color.Indigo;
        Color Ivory = Color.Ivory;
        Color Khaki = Color.Khaki;
        Color Lavender = Color.Lavender;
        Color LavenderBlush = Color.LavenderBlush;
        Color LawnGreen = Color.LawnGreen;
        Color LemonChiffon = Color.LemonChiffon;
        Color LightBlue = Color.LightBlue;
        Color LightCoral = Color.LightCoral;
        Color LightCyan = Color.LightCyan;
        Color LightGoldenrodYellow = Color.LightGoldenrodYellow;
        Color LightGray = Color.LightGray;
        Color LightGreen = Color.LightGreen;
        Color LightPink = Color.LightPink;
        Color LightSalmon = Color.LightSalmon;
        Color LightSeaGreen = Color.LightSeaGreen;
        Color LightSkyBlue = Color.LightSkyBlue;
        Color LightSlateGray = Color.LightSlateGray;
        Color LightSteelBlue = Color.LightSteelBlue;
        Color LightYellow = Color.LightYellow;
        Color Lime = Color.Lime;
        Color LimeGreen = Color.LimeGreen;
        Color Linen = Color.Linen;
        Color Magenta = Color.Magenta;
        Color Maroon = Color.Maroon;
        Color MediumAquamarine = Color.MediumAquamarine;
        Color MediumBlue = Color.MediumBlue;
        Color MediumOrchid = Color.MediumOrchid;
        Color MediumPurple = Color.MediumPurple;
        Color MediumSeaGreen = Color.MediumSeaGreen;
        Color MediumSlateBlue = Color.MediumSlateBlue;
        Color MediumSpringGreen = Color.MediumSpringGreen;
        Color MediumTurquoise = Color.MediumTurquoise;
        Color MediumVioletRed = Color.MediumVioletRed;
        Color MidnightBlue = Color.MidnightBlue;
        Color MintCream = Color.MintCream;
        Color MistyRose = Color.MistyRose;
        Color Moccasin = Color.Moccasin;
        Color NavajoWhite = Color.NavajoWhite;
        Color Navy = Color.Navy;
        Color OldLace = Color.OldLace;
        Color Olive = Color.Olive;
        Color OliveDrab = Color.OliveDrab;
        Color Orange = Color.Orange;
        Color OrangeRed = Color.OrangeRed;
        Color Orchid = Color.Orchid;
        Color PaleGoldenrod = Color.PaleGoldenrod;
        Color PaleGreen = Color.PaleGreen;
        Color PaleTurquoise = Color.PaleTurquoise;
        Color PaleVioletRed = Color.PaleVioletRed;
        Color PapayaWhip = Color.PapayaWhip;
        Color PeachPuff = Color.PeachPuff;
        Color Peru = Color.Peru;
        Color Pink = Color.Pink;
        Color Plum = Color.Plum;
        Color PowderBlue = Color.PowderBlue;
        Color Purple = Color.Purple;
        Color Red = Color.Red;
        Color RosyBrown = Color.RosyBrown;
        Color RoyalBlue = Color.RoyalBlue;
        Color SaddleBrown = Color.SaddleBrown;
        Color Salmon = Color.Salmon;
        Color SandyBrown = Color.SandyBrown;
        Color SeaGreen = Color.SeaGreen;
        Color SeaShell = Color.SeaShell;
        Color Sienna = Color.Sienna;
        Color Silver = Color.Silver;
        Color SkyBlue = Color.SkyBlue;
        Color SlateBlue = Color.SlateBlue;
        Color SlateGray = Color.SlateGray;
        Color Snow = Color.Snow;
        Color SpringGreen = Color.SpringGreen;
        Color SteelBlue = Color.SteelBlue;
        Color Tan = Color.Tan;
        Color Teal = Color.Teal;
        Color Thistle = Color.Thistle;
        Color Tomato = Color.Tomato;
        Color Turquoise = Color.Turquoise;
        Color Violet = Color.Violet;
        Color Wheat = Color.Wheat;
        Color White = Color.White;
        Color WhiteSmoke = Color.WhiteSmoke;
        Color Yellow = Color.Yellow;
        Color YellowGreen = Color.YellowGreen;

    }
}
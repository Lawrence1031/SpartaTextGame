namespace TextGame.Scene.Scene
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using ConsoleTables;
    using TextGame.Scene;
    using static Console;


    public class TextDG
    {
        public static void Main(string[] args)
        {
            Data.GameDataSetting();
            TextScene.Rungame();
            TextScene.MainPage();
        }
    }
}
using System;
using Raylib_cs;
using System.Collections.Generic;

Raylib.InitWindow(800,600,"Black Jack");
Raylib.SetTargetFPS(60);

Color pokergreen = new Color(53,101,77,255);




while(!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();

    Raylib.ClearBackground(pokergreen);





    Raylib.EndDrawing();




}
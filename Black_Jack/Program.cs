using System;
using Raylib_cs;
using System.Collections.Generic;

Raylib.InitWindow(800,600,"Black Jack");
Raylib.SetTargetFPS(60);

Color pokergreen = new Color(53,101,77,255);

int playerMoney = 1000;
int playerCardValue = 0;
int dealerCardValue = 0;



string currentMenu = "start";


while(!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();

    if(currentMenu == "start"){

        Raylib.ClearBackground(pokergreen);
        
        Raylib.DrawText("BLACKJACK",200,125,75,Color.GOLD);

    }





    Raylib.EndDrawing();




}
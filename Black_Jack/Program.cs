using System;
using Raylib_cs;
using System.Collections.Generic;

Raylib.InitWindow(800, 600, "Black Jack");
Raylib.SetTargetFPS(60);

Color pokergreen = new Color(53, 101, 77, 255);

int playerMoney = 1000;
int playerCardTotal = 0;
int houseCardTotal = 0;
int betAmount = 100;

Random generator = new Random();

string currentMenu = "start";

List<Card> deck = new List<Card>();

deck.Add(new Card() { name = "Ace", value = 11 });
deck.Add(new Card() { name = "King", value = 10 });
deck.Add(new Card() { name = "Queen", value = 10 });
deck.Add(new Card() { name = "Jack", value = 10 });
deck.Add(new Card() { name = "Ten", value = 10 });
deck.Add(new Card() { name = "Nine", value = 9 });
deck.Add(new Card() { name = "Eight", value = 8 });
deck.Add(new Card() { name = "Seven", value = 7 });
deck.Add(new Card() { name = "Six", value = 6 });
deck.Add(new Card() { name = "Five", value = 5 });
deck.Add(new Card() { name = "Four", value = 4 });
deck.Add(new Card() { name = "Three", value = 3 });
deck.Add(new Card() { name = "Two", value = 2 });


int selected_card = generator.Next(deck.Count);

playerCardTotal = playerCardTotal + deck[selected_card].value;

int selected_card2 = generator.Next(deck.Count);

houseCardTotal = houseCardTotal + deck[selected_card2].value;



void hitCard()
{
    int cardHit = generator.Next(deck.Count);

    playerCardTotal = playerCardTotal + deck[cardHit].value;

}

void houseHitCard()
{
    int houseHit = generator.Next(deck.Count);

    houseCardTotal = houseCardTotal + deck[houseHit].value;

}

while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();

    if (currentMenu == "start")
    {

        Raylib.ClearBackground(pokergreen);

        Raylib.DrawText("BLACKJACK", 175, 125, 75, Color.GOLD);
        Raylib.DrawText("PRESS SPACE TO START", Raylib.GetScreenWidth() / 3 - 25, 250, 25, Color.WHITE);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            currentMenu = "betting";
        }

    }

    if (currentMenu == "betting")
    {
        Raylib.ClearBackground(pokergreen);

        Raylib.DrawText("Place your bets:", Raylib.GetScreenWidth() / 3 - 75, 125, 50, Color.WHITE);
        Raylib.DrawText($"{betAmount}", Raylib.GetScreenWidth() / 2 - 25, 250, 50, Color.LIGHTGRAY);
        Raylib.DrawText("USE < > TO CHANGE BET AMOUNT", Raylib.GetScreenWidth() / 3 - 75, 350, 25, Color.WHITE);
        Raylib.DrawText("PRESS ENTER TO CONFRIM BET", Raylib.GetScreenWidth() / 3 - 75, 400, 25, Color.WHITE);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && betAmount < playerMoney)
        {
            betAmount = betAmount + 100;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && betAmount > 100)
        {
            betAmount = betAmount - 100;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentMenu = "playing";
        }


    }

    if (currentMenu == "playing")
    {
        string totalpot = betAmount.ToString();

        Raylib.ClearBackground(pokergreen);

        Raylib.DrawText("Dealer", Raylib.GetScreenWidth() / 2 - 35, 25, 25, Color.WHITE);
        Raylib.DrawText("You", Raylib.GetScreenWidth() / 2 - 20, 550, 25, Color.WHITE);
        Raylib.DrawText($"Your bet = {totalpot}", Raylib.GetScreenWidth() / 2 - 100, Raylib.GetScreenHeight() / 2, 25, Color.WHITE);

        Raylib.DrawText($"{playerCardTotal}", Raylib.GetScreenWidth() / 2, 500, 25, Color.WHITE);
        Raylib.DrawText($"{houseCardTotal}", Raylib.GetScreenWidth() / 2, 75, 25, Color.WHITE);

        Raylib.DrawText("Press H to hit   S to stand", Raylib.GetScreenWidth() / 3 - 10, 425, 20, Color.WHITE);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_H) && playerCardTotal < 21)
        {
            hitCard();
        }
        else if (playerCardTotal > 21)
        {
            currentMenu = "houseWins";
            playerMoney = playerMoney - betAmount;
        }
        else if (playerCardTotal == 21)
        {
            currentMenu = "housePlaying";
        }
    }

    if (currentMenu == "housePlaying")
    {
        string totalpot = betAmount.ToString();

        Raylib.ClearBackground(pokergreen);

        Raylib.DrawText("Dealer", Raylib.GetScreenWidth() / 2 - 35, 25, 25, Color.WHITE);
        Raylib.DrawText("You", Raylib.GetScreenWidth() / 2 - 20, 550, 25, Color.WHITE);
        Raylib.DrawText($"Your bet = {totalpot}", Raylib.GetScreenWidth() / 2 - 100, Raylib.GetScreenHeight() / 2, 25, Color.WHITE);

        Raylib.DrawText($"{playerCardTotal}", Raylib.GetScreenWidth() / 2, 500, 25, Color.WHITE);
        Raylib.DrawText($"{houseCardTotal}", Raylib.GetScreenWidth() / 2, 75, 25, Color.WHITE);

        Raylib.DrawText("Press H to hit  S to stand", Raylib.GetScreenWidth() / 3 - 10, 425, 20, Color.WHITE);


    }






    if (currentMenu == "houseWins")
    {
        Raylib.ClearBackground(pokergreen);
        Raylib.DrawText("HOUSE WINS!", Raylib.GetScreenWidth() / 4 - 10, Raylib.GetScreenHeight() / 2 - 100, 75, Color.RED);
        Raylib.DrawText("Press ENTER to continue", Raylib.GetScreenWidth() / 3 + 25, Raylib.GetScreenHeight() / 2 + 50, 20, Color.WHITE);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) { currentMenu = "betting"; }



    }

    Raylib.EndDrawing();
}

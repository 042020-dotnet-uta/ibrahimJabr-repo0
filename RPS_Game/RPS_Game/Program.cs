using System;
using System.Collections;
namespace RPS_Game
{
    // public class Player
    // { // creating a player class to store player information.
    //     public string name; //string to store player name.
    //     public string curntRound; // string to store what player got from RPSGenerator(r/p/s)
    //     public int score = 0; // int to store player wint count.
    //     public Player(string name)
    //     { // constructor to assign player name to the string.
    //         this.name = name;
    //     }

    // }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Player one name"); // prompting user to enter the player name on console.
            Player player1 = new Player(Console.ReadLine()); // storing the entered player name into player obj.
            Console.WriteLine("Enter Player two name");
            Player player2 = new Player(Console.ReadLine());
            Game game =new Game();
            game.playAGame(player1,player2);
            if (player1.Wins == 2)
            { // display whichever player that has 2 wins and display the winner on console.
                Console.WriteLine($"{player1.Name} wins 2-{player2.Wins} with {player1.Ties} ties.");
            }
            else
            {
                Console.WriteLine($"{player2.Name} wins 2-{player1.Wins} with {player1.Ties} ties.");
            }
        }
    }
}

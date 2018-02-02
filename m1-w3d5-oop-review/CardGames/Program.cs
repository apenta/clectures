using CardGames.Cards;
using CardGames.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            WarGame game = new WarGame("JOHN", "BILL");
            game.PlayGame();
        }
    }
}

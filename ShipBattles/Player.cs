using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattles
{
    internal class Player
    {
        Battlefield _battlefield = new Battlefield();
        public Battlefield Battlefield => _battlefield;

        public string Name { get; }

        public Player(string name)
            {
            Name = name;
            }

        public virtual void SetShips(Ship[] ships)
        {

        }

        public virtual (int, int) GetHitCoords()
        {
            return (0, 0);
        }
    }
    internal class ConsolePlayer : Player
    {
        public ConsolePlayer(string name) : base(name) { }

        public override void SetShips(Ship[] ships)
        {
            base.SetShips(ships);
        }

        public bool TryParsePlace(string input, out int x, out int y, out bool isHorizontal)
        {
            isHorizontal = false;
            if (input.Length != 3)
            {
                x = y = 0;
                return false;
            }
            
            if (!Battlefield.TryParse(input[0..1], out x, out y))
            {
                return false;
            }
            char horChar = input[2];

            if (horChar == 'H')
            {
                isHorizontal = true;
            }
            else if (horChar == 'V')
            {
                isHorizontal = false;
            }
            else
            {
                return false;
            }

            return true;
        }

        public override (int, int) GetHitCoords()
        {
            int x = 0;
            int y = 0;
            while (!Battlefield.TryParse(Console.ReadLine().ToUpper(), out x, out y))
            {
                Console.WriteLine("Error 404: Wrong coords input!");
                continue;
            }
            return (x, y);
        }
    }
    internal class AiPlayer : Player
    {
        public AiPlayer(string name) : base(name) { }
    }
}

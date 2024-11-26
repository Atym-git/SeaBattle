using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShipBattles
{
    internal class Battlefield
    {
        FieldState[,] field = new FieldState[9,9];



        public bool AddShip(Ship ship, bool isHorizontal, int x, int y)
        {
            if (isHorizontal && !(y < 9 && x <= 9 - ship.Length))
            {
                return false;
            }
            if (!isHorizontal && !(y < 9 && y <= 9 - ship.Length))
            {
                return false;
            }
                for (int i = 0; i < ship.Length; i++)
            {
                if (isHorizontal)
                {
                    field[y, x+i] = FieldState.Ship;
                }
                else
                {
                    field[y+i, x] = FieldState.Ship;
                }
            }
                return true;
        }


        public void PrintField()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(GetStateChar(field[i, j]));
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public static char GetStateChar(FieldState state)
        {
            switch (state)
            {
                case FieldState.None:
                    return '.';
                case FieldState.Ship:
                    return '#';
                case FieldState.Hit:
                    return 'X';
                case FieldState.Miss:
                    return 'O';
                default:
                    return '\0';
            }
        }



        public enum FieldState
        {
            None,
            Ship,
            Hit,
            Miss
        }
    }
}
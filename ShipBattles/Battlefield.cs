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
            if (!CanPlaceShip(ship, isHorizontal, x, y))
            {
            return false;
            }
            for (int i = 0; i < ship.Length; i++)
            {
                if (isHorizontal)
                {
                    field[y, x + i] = FieldState.Ship;
                }
                else
                {
                    field[y + i, x] = FieldState.Ship;
                }
            }
            return true;
        }

        public bool AddShip (Ship ship, bool isHorizontal, CharCoard x, int y)
        {
            return AddShip(ship, isHorizontal, (int)x, y);
        }


        public bool CanPlaceShip(Ship ship, bool isHorizontal, int x, int y)
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
                    if (!IsFieldArountEmpty(x + i, y))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!IsFieldArountEmpty(x, y + i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool Hit(int x, int y)
        {
        if (field[y, x] == FieldState.Ship)
            {
                field[y, x] = FieldState.Hit;
            return true;
            }
        else if (field[y, x] == FieldState.None)
            {
                field[y, x] = FieldState.Miss;
                return false;
            }
        return false;
        }

        public bool Hit(CharCoard x, int y)
        {
            return Hit((int)x, y);
        }

        public static bool TryParse(string input, out int x, out int y)
        {
            x = y = 0;

            if (input.Length != 2)
            {
                return false;
            }

            char xChar = input[0];
            char yChar = input[1];

            if (!char.IsLetter(xChar) && !char.IsDigit(yChar))
            {
                return false;
            }
            x = xChar - 'A';
            y = yChar - '1';
            
            if (x < 0 || x >= 9 || y < 0 || y >= 9)
            {
                x = y = 0;
                return false;
            }

            return true;
        }

        private bool IsFieldArountEmpty(int x, int y)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int row = y + i - 1;
                    int col = x + j - 1;

                    if (row < 0 || row >= 9 ||
                        col < 0 || col >= 9)
                    {
                        continue;
                    }

                    if (field[row, col] != FieldState.None)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void PrintField(bool isSecret = false)
        {
            Console.Write("  ");
            for (int i = 0; i < 9; i++)
            {
                char c = (char)('A' + i);
                Console.Write($"{c} ");
            }
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                Console.Write($"{i+1} ");
                for (int j = 0; j < 9; j++)
                {
                    char stateChar = isSecret ? GetSecretStateChar(field[i, j])
                        : GetStateChar(field[i, j]);
                    Console.Write(stateChar);
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
        public static char GetSecretStateChar(FieldState state)
        {
            switch (state)
            {
                case FieldState.None:
                case FieldState.Ship:
                    return '.';
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
    public enum CharCoard
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I
    }
}
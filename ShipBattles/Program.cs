namespace ShipBattles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battlefield battlefield = new Battlefield();

            Ship ship = new Ship(3);
            Ship ship2 = new Ship(2);

            battlefield.AddShip(ship, true, CharCoard.A, 1);
            battlefield.AddShip(ship2, false, CharCoard.G, 6);
            battlefield.AddShip(ship, true, CharCoard.A, 8);

            battlefield.AddShip(ship, false, CharCoard.D, 0);

            battlefield.PrintField();

            string input = Console.ReadLine();

            if (Battlefield.TryParse(input.ToUpper(), out int x, out int y))
            {
                battlefield.Hit(x, y);
            }

            //battlefield.Hit(CharCoard.A, 1);

            battlefield.PrintField();
        }
    }
}

namespace ShipBattles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battlefield battlefield = new Battlefield();

            Ship ship = new Ship(3);
            Ship ship2 = new Ship(2);

            battlefield.AddShip(ship, true, 1, 1);
            battlefield.AddShip(ship2, false, 4, 6);
            battlefield.AddShip(ship, true, 6, 8);

            battlefield.PrintField();
        }
    }
}

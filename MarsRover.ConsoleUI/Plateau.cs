namespace MarsRover.ConsoleUI
{
    public class Plateau
    {

        /// <summary>
        /// Platonun genişlik bilgisi
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Platonun yükseklik bilgisi
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gezicinin belirtilen boyutların içinde olup olmadığını belirler
        /// </summary>
        /// <param name="rover"></param>
        /// <returns>True,False</returns>
        public bool IsOnTheFloor(Rover rover) => !(rover.X > Width || rover.X < 0 || rover.Y > Height || rover.X < 0);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ConsoleUI
{
    public class Rover
    {
        private readonly Plateau _plateua;
        public Rover(Plateau plateau,int id, int x = 0, int y = 0, char nav = '-')
        {

            _plateua = plateau;
            Id = id;
            X = x;
            Y = y;
            Navigation = nav;
        }
        /// <summary>
        /// Gezicinin benzersiz kimliği
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gezicinin Plato üzerinde ki yatay düzlem konumu 
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Gezicinin Plato üzerinde ki dikey düzlem konumu (Y)
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Gezicinin Plato üzerinde ki yönü
        /// </summary>
        public char Navigation { get; set; }
       

        /// <summary>
        /// Gezicinin hareketini sağlayan methoddur.
        /// </summary>
        /// <param name="directions"></param>
        /// <returns>Gezicinin nihai koordinatları ve yönü</returns>
        public string Move(string directions)
        {
            Navigation = Convert.ToChar(Navigation.ToString().ToUpper());
            char[] navigations = directions.ToUpper().ToCharArray();
            foreach (var nav in navigations)
            {
                if (char.IsLetter(Convert.ToChar(nav)))
                {
                    switch (nav)
                    {
                        case 'L':
                            if (Navigation == 'N') Navigation = 'W';
                            else if (Navigation == 'W') Navigation = 'S';
                            else if (Navigation == 'S') Navigation = 'E';
                            else if (Navigation == 'E') Navigation = 'N';
                            break;

                        case 'R':
                            if (Navigation == 'N') Navigation = 'E';
                            else if (Navigation == 'E') Navigation = 'S';
                            else if (Navigation == 'S') Navigation = 'W';
                            else if (Navigation == 'W') Navigation = 'N';
                            break;

                        case 'M':
                            if (Navigation == 'N') Y++;
                            else if (Navigation == 'E') X++;
                            else if (Navigation == 'S') Y--;
                            else if (Navigation == 'W') X--;
                            break;

                    }

                }
                if (!_plateua.IsOnTheFloor(this))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"WARNING: Rover{Id} cannot be outside of the plateue");
                    Console.ResetColor();
                    return $"Rover{Id} cannot be outside of the plateue";
                }

            }
            string lastPosition= $"Position of Rover{Id} is '{X} {Y} {Navigation}'";
            Console.WriteLine(lastPosition);
            return lastPosition;

        }
    }
}

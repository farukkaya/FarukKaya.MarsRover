using System;
using System.Collections.Generic;

namespace MarsRover.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> roverParams = new();
            List<string> directionParams = new();

            Console.WriteLine("Navigation is starting");

            Console.Write("Enter the upper-right coordinates of the plateau :");
            string param1 = Console.ReadLine();

            var plateau = new Plateau()
            {
                Height = Convert.ToInt32(param1.Split(' ')[0]),
                Width = Convert.ToInt32(param1.Split(' ')[1])
            };

            Console.Write("Enter  Positon of Rover 1 - ");
            roverParams.Add(Console.ReadLine());


            Console.Write("Enter  Navigation of Rover 1 - ");
            directionParams.Add(Console.ReadLine());

            Console.Write("Enter  Positon of Rover 2 - ");
            roverParams.Add(Console.ReadLine());


            Console.Write("Enter  Navigation of Rover 2 - ");
            directionParams.Add(Console.ReadLine());


            Console.WriteLine("-------OUTPUT-------");
            List<Rover> rovers = GetRovers(roverParams, plateau);
            foreach (var rover in rovers)
            {
                int indexRover = rover.Id - 1;
                rover.Move(directionParams[indexRover]);
            }

        }

        public static List<Rover> GetRovers(List<string> parameters, Plateau plateau)
        {
            List<Rover> rovers = new();

            for (int i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                int id = i + 1;

                if (param.IndexOf(' ') != -1)
                {

                    var orientation = param.Split(' ');

                    if (orientation.Length == 3)
                    {
                        try
                        {
                            int x = Convert.ToInt32(orientation[0]);
                            int y = Convert.ToInt32(orientation[1]);
                            char nav = Convert.ToChar(orientation[2]);
                            if (char.IsLetter(nav))
                            {
                                if (nav != '-') rovers.Add(new Rover(plateau, id, x, y, nav));
                                else WriteError($"(Rover-{id}) Navigation is not correct format");

                            }
                            else WriteError($"(Rover-{id}) Positon is not correct format");


                        }
                        catch (Exception ex)
                        {
                            WriteError($"(Rover-{id}) {ex.Message}");
                        }

                    }
                    else WriteError($"(Rover-{id}) Enter two number for coordinat and enter the one orientation for navigation");
                }
                else WriteError($"(Rover-{id}) Enter the positon with space");

            }
          
            return rovers;
        }

        public static void WriteError(string error)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {error}");
            Console.ResetColor();
        }
    }
}

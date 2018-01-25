using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 1. Add a using statement
using ShapeExercise.Shapes;

namespace ShapeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wall w1 = new Wall(10, 15);

            ////w1.Height = 10;
            ////w1.Width = 15;
            //w1.Name = "Back wall";

            //Console.WriteLine($"{w1.Name} area is {w1.GetArea()}");            
            //Wall w2 = new Wall(100, 1);

            //w2.Name = "Tower";

            //Console.WriteLine($"{w2.Name} area is {w2.GetArea()}");


            List<Wall> wallsToPaint = new List<Wall>();

            while (true)
            {
                Console.WriteLine("[1] Add a wall");
                Console.WriteLine("[2] Calculate paint required (and Exit)");
                Console.Write("Please choose >>> ");
                string userChoice = Console.ReadLine();

                Console.WriteLine();

                if(userChoice == "1")
                {
                    Console.Write("Enter wall height >>> ");
                    int height = int.Parse(Console.ReadLine());
                    Console.Write("Enter wall width >>> ");
                    int width = int.Parse(Console.ReadLine());
                    Console.Write("Enter wall name >>> ");
                    string name = Console.ReadLine();

                    Wall wall = new Wall(height, width);
                    wall.Name = name;

                    wallsToPaint.Add(wall);

                    double area = wall.GetArea();

                    Console.WriteLine($"Added {name} - {height}x{width} wall - {area} square feet");
                }
                else if (userChoice == "2")
                {
                    // Here we need to sum up the areas of all walls that have been entered
                    //Console.WriteLine("Wall 1: 10x15 - 150 square feet"); // PROTOTYPE ONLY!!!
                    //Console.WriteLine("Wall 2: 10x15 - 150 square feet"); // PROTOTYPE ONLY!!!
                    //Console.WriteLine("Wall 3: 10x15 - 150 square feet"); // PROTOTYPE ONLY!!!
                    //Console.WriteLine("Wall 4: 10x15 - 150 square feet"); // PROTOTYPE ONLY!!!
                    double totalArea = 0;
                    foreach(Wall wall in wallsToPaint)
                    {
                        Console.WriteLine($"Wall {wall.Name}: {wall.Height}x{wall.Width} - {wall.GetArea()} square feet.");
                        totalArea += wall.GetArea(); //add up each wall area to the total area
                    }
                    
                    Console.WriteLine("===============================");
                    Console.WriteLine($"Total Area: {totalArea} square feet");

                    // 1 gallon of paint covers 400 square feet
                    double gallonsRequired = (double)totalArea / 400;
                    Console.WriteLine($"Paint Required: {gallonsRequired} gallons");

                    return;
                }
            }

        }
    }
}

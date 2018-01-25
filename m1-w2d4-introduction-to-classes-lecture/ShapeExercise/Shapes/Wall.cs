using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeExercise.Shapes
{
    /// <summary>
    /// Represents a wall in your house.
    /// </summary>
    public class Wall
    {
        /// <summary>
        /// Represents the wall's height.
        /// </summary>
        public double Height { get; set; } = 1;

        /// <summary>
        /// Represents the wall's width.
        /// </summary>
        public double Width { get; set; } = 1;

        /// <summary>
        /// Represents the wall's name.
        /// </summary>
        public string Name { get; set; } = "Wall";
                
        // Constructor
        public Wall(double height, double width)
        {
            Height = height;
            Width = width;
        }

        //public Wall(double length)
        //{
        //    Height = length;
        //    Width = length;
        //}

        //public Wall()
        //{
        //    Height = 1;
        //    Width = 1;
        //    Name = "Wall";
        //}


        /// <summary>
        /// Returns the area of the wall.
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return Height * Width;
        }
     

    }
}

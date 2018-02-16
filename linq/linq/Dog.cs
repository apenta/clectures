using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    public class Dog
    {
        public string License { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public bool IsMale { get; set; }
        public bool SpayedOrNeutered { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            string gender = (IsMale) ? "M" : "F";
            string spay = (SpayedOrNeutered) ? "Neutered" : "";

            return $"{Name.ToUpper()}, {Breed} ({gender}) - {Color}\nBorn on {DateOfBirth.ToShortDateString()}\n{Weight}lbs {spay}\n";
        }

        public static IList<Dog> GetAllDogs()
        {
            return new List<Dog>()
        {
            new Dog () { Breed = "Golden Retriever", Color = "Blonde", DateOfBirth = DateTime.Today.AddMonths(-13), IsMale = false, License = "ABC-123", Name = "Beckett", SpayedOrNeutered = true, Weight = 35.2},
            new Dog () { Breed = "Irish Setter", Color = "Amber", DateOfBirth = DateTime.Today.AddYears(-6), IsMale = false, License = "DEF-567", Name = "Molly", SpayedOrNeutered = true, Weight = 31.0},
            new Dog () { Breed = "Cocker Spaniel", Color = "Black", DateOfBirth = DateTime.Today.AddYears(-1), IsMale = true, License = "GHI-890", Name = "Shadow", SpayedOrNeutered = true, Weight = 23.6},
            new Dog () { Breed = "Lab", Color = "Chocolate", DateOfBirth = DateTime.Today.AddMonths(-4), IsMale = true, License = "JKL-234", Name = "Charlie", SpayedOrNeutered = false, Weight = 17.9},
            new Dog () { Breed = "German Shepherd", Color = "Black", DateOfBirth = DateTime.Today.AddYears(-3), IsMale = false, License = "MNO-567", Name = "Poppy", SpayedOrNeutered = false, Weight = 55.2},
            new Dog () { Breed = "Golden Retriever", Color = "Amber", DateOfBirth = DateTime.Today.AddYears(-17), IsMale = false, License = "MNO-489", Name = "Amber", SpayedOrNeutered = true, Weight = 34.2},
        };
        }
    }


}

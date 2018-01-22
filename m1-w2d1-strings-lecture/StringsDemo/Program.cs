using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";


            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            char firstCharacter = name[0]; // first character
            char lastCharacter = name[name.Length - 1]; // last character

            Console.WriteLine(firstCharacter + lastCharacter); // <-- does not concatenate value together
                                                                                     // instead it adds the ASCII values

            char capitalA = (char)101; //we can cast decimal into a character


            Console.WriteLine("First Character: " + firstCharacter);
            Console.WriteLine("Last Character: " + lastCharacter);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            string firstThreeCharacters = name.Substring(0, 3);

            Console.WriteLine("First 3 characters: " + firstThreeCharacters);

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            string lastThreeCharacters = name.Substring(name.Length - 3);       // start 3 characters from the end

            Console.WriteLine("Last 3 characters: " + firstThreeCharacters + lastThreeCharacters);

            // 4. What about the last word?
            // Output: Lovelace

            string[] words = name.Split(' '); // split name at each space
            //string[] words = name.Split(' ', '?', '.', '!') // splits on all forms of punctuation and spaces

            Console.WriteLine("Last Word: " + words[words.Length - 1]);


            // 5. Does the string contain inside of it "Love"?
            // Output: true

            bool containsLove = name.Contains("Love");

            Console.WriteLine("Contains \"Love\": " + containsLove);

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            int indexOfLace = name.IndexOf("lace");

            Console.WriteLine("Index of \"lace\": " + indexOfLace);

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            int sum = 0;
            for(int i = 0; i < name.Length; i++)
            {
                if (name[i] == 'a' || name[i] == 'A')
                {
                    sum += 1;
                }
            }

            Console.WriteLine("Number of \"a's\": " + sum);

            // 8. Replace "Ada Lovelace" with "Ada, Countess of Lovelace"
            name = name.Replace("Ada Lovelace", "Ada, Countess of Lovelace");
            Console.WriteLine(name);


            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (name == null || name.Length == 0)
            {
                Console.WriteLine("All done");
            }
            // These two are the same way of writing "if name is null or empty string"
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("All done");
            }

            
        }
    }
}

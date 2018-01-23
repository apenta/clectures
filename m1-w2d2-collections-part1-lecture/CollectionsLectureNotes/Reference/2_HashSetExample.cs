using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLectureNotes.Reference
{
    public class HashSetExample
    {
        public static void ShowHashSetCode()
        {

            // HASHSET<T>
            //
            // Sets are a type of list that can only hold unique values.
            // Their items are in no particular order but we are guaranteed not to have duplicate values.

            HashSet<string> languages = new HashSet<string>();

            ///////////////////////////
            // ADDING ITEMS TO A HASH SET
            ///////////////////////////
            languages.Add("C#");
            languages.Add("Java");
            languages.Add("Objective-C");
            languages.Add("Ruby");


            ///////////////////////////
            // ITERATING THROUGH A HASH SET
            ///////////////////////////
            foreach (var language in languages)
            {
                Console.WriteLine(language);
            }


            ///////////////////////////
            // ADDING TWO SETS TOGETHER
            ///////////////////////////
            HashSet<string> webLanguages = new HashSet<string>() { "HTML", "CSS", "C#", "Java" };

            languages.UnionWith(webLanguages);

            Console.WriteLine();
            foreach (var language in languages)
            {
                Console.WriteLine(language);
            }
            Console.WriteLine();
        }
    }
}

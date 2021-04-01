using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //Case 1  Return a copy of given input string with uppercase characters converted to lowercase and viceversa.
            Console.WriteLine("String with uppercase characters converted to lowercase : " + input.AddLowerCase());

            //Case 2 Return a copy of given input string with lowercase characters converted to Uppercase.
            Console.WriteLine("String with lowercase characters converted to uppercase : " + input.AddUpperCase());

            //Case 3  Converts the specified string to title case .
            Console.WriteLine("String with title case : " + input.TitleCase());

            //Case 4  All the characters from given input string are in lower case or not 
            Console.WriteLine("To check string is in lower case or not : " + input.CheckLowerCase());

            //Case 5 To convert the  first character into  upper case and the rest lower case.
            Console.WriteLine("To convert the first charcter into upper case : " + input.FirstUpperLetter());

            //Case 6 all the characters from given input string are in upper case or not
            Console.WriteLine("To check all the characters are in upper case or not : " + input.CheckUpperCase());

            //Case 7    Function to identify whether given input string can be converted to a valid numeric value or not. 
            Console.WriteLine("To check whether string can be converted to a numreic value : " + input.NumberValidation());

            //Case 8 Function to remove the last character from given the string
            Console.WriteLine("To remove the last character form the string : " + input.LastCharacterRemove());

            //Case 9 Get the word count from an input string.
            Console.WriteLine("To count the word : " + input.WordCount());

            //Case 10     Convert an input string to integer.   
            Console.WriteLine("To convert string to int : " + input.StringToInt());

        }
    }
}

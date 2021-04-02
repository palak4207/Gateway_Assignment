using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public static class ExtensionMethod
    {

        public static string AddLowerCase(this string input)
        {
            StringBuilder str = new StringBuilder(input);
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    str[i] = (char)(str[i] + 32);
            }
            return str.ToString();
        }

        public static string AddUpperCase(this string input)
        {
            StringBuilder str = new StringBuilder(input);
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                    str[i] = (char)(str[i] - 32);
            }
            return str.ToString();
        }



        public static string TitleCase(this string input)
        {
            TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
            return textInfo.ToTitleCase(input);
        }

        public static bool CheckLowerCase(this String str)
        {
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    return false;
                }
            }
            return true;
        }

        public static string FirstUpperLetter(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static bool CheckUpperCase(this String str)
        {
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool NumberValidation(this string input)
        {
            int n;
            bool isNumeric = int.TryParse(input, out n);
            return isNumeric;
        }
        public static string LastCharacterRemove(this string str)
        {
            if (str == null)
                return null;
            else
                return str.Substring(0, str.Length - 1);
        }

        public static int WordCount(this string input)
        {
            // int length = input.Length;
            string[] words = input.Split(' ');

            return words.Length;
        }

        public static int StringToInt(this string input)
        {
            int x = 0;

            Int32.TryParse(input, out x);
            return x;
        }
    }
  }

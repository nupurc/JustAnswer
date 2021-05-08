using System;
using System.Text.RegularExpressions;

namespace EmailAddress
{
    class Program
    {
       
        static void Main(string[] args)
        {           
            //Console.WriteLine(RemovePersonalInfo(Console.ReadLine()));
            Console.WriteLine(identifyEmailAddress(Console.ReadLine()));
        }
        static string identifyEmailAddress(string txt)
        {
            
            const string MatchEmailPattern = @"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}";
            Regex reg = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(txt);
            if (matches.Count > 0)
            {
                for (int i=0; i < matches.Count; i++)
                {                    
                    var result = ReplaceString(txt, matches[i].Value, "<<some email>>");
                    txt = result;
                }
            }

            return txt;
        }
        static string ReplaceString(string original, string pattern, string replaceWith)
        {           
            int i = original.IndexOf(pattern);
            original = original.Substring(0, i) + replaceWith + original.Substring(i + replaceWith.Length);
            return original;
        }

        static  string RemovePersonalInfo(string input)
        {
            string[] tokens = input.Split(new char[] { ' ', '\t',
                                                   '\r', '\n' });
            string output = string.Empty;
            foreach (string token in tokens)
            {
                if (token.Contains("@gmail.com"))
                {
                    output += " <<some email>>";
                }
                else
                {
                    output += " " + token;
                }
            }
            tokens = output.Split(new char[] { ' ', '\t', '\r', '\n' });
            output = string.Empty;
            foreach (string token in tokens)
            {
                if (token.Contains("@yahoo.com"))
                {
                    output += " <<some email>>";
                }
                else
                {
                    output += " " + token;
                }
            }
            return output;
        }
    }
}

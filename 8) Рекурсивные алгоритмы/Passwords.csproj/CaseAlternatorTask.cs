using System.Collections.Generic;

namespace Passwords
{
    public class CaseAlternatorTask
    {
        //Тесты будут вызывать этот метод
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            return result;
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            // TODO
            if (startIndex == word.Length)
            {
                result.Add(new string(word));
                return;
            }

            if (char.IsLetter(word[startIndex]) && word[startIndex] != char.ToUpper(word[startIndex]))
            {
                AlternateCharCases(word, startIndex + 1, result);
                word[startIndex] = char.ToUpper(word[startIndex]);
            }

            AlternateCharCases(word, startIndex + 1, result);
            word[startIndex] = char.ToLower(word[startIndex]);
        }
    }
}
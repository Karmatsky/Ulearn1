using System.Collections.Generic;
using System.Text;
using System;

namespace TextAnalysis
{
    internal static class SentencesParserTask
    {
        public static readonly char[] sentenceSeparator = { '.', '!', '?', ';', ':', '(', ')' };

        public static List<List<string>> ParseSentences(string text)
        {
            var list = new List<List<string>>();
            var sentencesList = text.ToLower().Split(sentenceSeparator);
            foreach (var sentences in sentencesList)
            {
                var wordList = new List<string>();
                var wordBuilder = new StringBuilder();
                Build(sentences, wordBuilder, wordList);
                if (wordBuilder.Length > 0)
                {
                    wordList.Add(wordBuilder.ToString());
                    wordBuilder.Clear();
                }
                if (wordList.Count > 0)
                    list.Add(wordList);
            }
            return list;
        }

        private static void Build(string sentence, StringBuilder builder, List<string> list)
        {
            foreach (var word in sentence)
            {
                if (char.IsLetter(word) || word == '\'')
                    builder.Append(word);
                else
                {
                    if (builder.Length == 0) continue;
                    list.Add(builder.ToString());
                    builder.Clear();
                }
            }
        }
    }
}
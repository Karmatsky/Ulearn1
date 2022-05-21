using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            
            return null;
        }

        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var countByPrefix = Math.Min(count, GetCountByPrefix(phrases, prefix));
            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            var topByPrefix = new string[countByPrefix];
            var c = 0;
            while (c < countByPrefix)
            {
                topByPrefix[c] = phrases[left + c + 1];
                c++;
            }
            return topByPrefix;
        }

        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var phrasesNumber = phrases.Count;
            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrasesNumber);
            var right = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrasesNumber);
            return right - left - 1;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases()
        {
            var phrases = new string[] { "aa", "ab", "bc", "bd", "be", "ca", "cb" };
            var prefix = "aaa";
            var expectedCount = 0;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedCount, actualCount);
        }

        // ...

        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
        {
            var phrases = new string[] { "aa", "ab", "bc", "bd", "be", "ca", "cb" };
            var prefix = "aaa";
            var expectedCount = 0;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedCount, actualCount);
        }

        // ...
    }
}

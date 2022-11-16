using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareFinder
{
    internal static class ElementsComparer
    {
        /*
         Cпосіб порівняння дозволяє користувачу робити помилки у словах чи писати їх неповністю. Програма
            самостійно прийме рішення про те, чи задані слова достатньо схожі щоб вважатися однаковими.
            В основі цього способу лежить алгоритм обчислення «відстані Левенштейна», котра
            рівна кількості змін, які потрібно зробити для перетворення одного виразу в інший. Далі
            відбувається ймовірнісна оцінка отриманого результату. Якщо слова з ймовірністю ≥50%
            є одним і тим же словом, то повідомляємо про їхню рівність.
         */
        public static bool IsEqual(string source, string target)
        {
            const double probableRate = 0.5;

            double similarityRate = CalculateProbableSimilarity(source, target);
            return similarityRate >= probableRate;
        }

        private static double CalculateProbableSimilarity(string source, string target)
        {
            if (source == null || target == null) return 0;

            source = source.ToLower().Trim();
            target = target.ToLower().Trim();

            if (source.Length == 0 || target.Length == 0) return 0;
            if (source == target) return 1;

            var stepsToSame = ComputeLevenshteinDistance(source, target);
            var probability = 1 - (stepsToSame / (double)Math.Max(source.Length, target.Length));
            return probability;
        }

        // Returns the number of steps required to transform the source string
        // into the target string.
        private static int ComputeLevenshteinDistance(string source, string target)
        {
            // Preparations
            var sourceWordCount = source.Length;
            var targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
            {
                return targetWordCount;
            }

            if (targetWordCount == 0)
            {
                return sourceWordCount;
            }

            // Creating measurement table
            var distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (var i = 0; i <= sourceWordCount;)
            {
                distance[i, 0] = i++;
            }

            for (var j = 0; j <= targetWordCount;)
            {
                distance[0, j] = j++;
            }

            for (var i = 1; i <= sourceWordCount; i++)
            {
                for (var j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                                              distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
    }
}

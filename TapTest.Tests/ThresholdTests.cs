using TapTest.Domain.Filters;
using TapTest.Models;
using TapTest.Options.SelectionRule;

namespace TapTest.Tests
{
    internal class ThresholdTests
    {
        [TestCase(new[]{"Math", "Science", "English", "Japanese", "Geography/History" },40 , true)]
        [TestCase(new[] { "Math", "Science", "English", "Japanese", "Geography/History" }, 150, true)]
        [TestCase(new[] { "Math", "Science", "English", "Japanese", "Geography/History" }, 151, false)]
        [TestCase(new[] { "Math", "Science" }, 30, true)]
        [TestCase(new[] { "Math", "Science" }, 31, false)]
        public void ThresholdCalculationTest(string[] bindings, int threshold, bool passed)
        {
            var application = new Application()
            {
                Scores = new Dictionary<string, int>()
                {
                    { "Math", 10 },
                    { "Science", 20 },
                    { "English", 30 },
                    { "Japanese", 40 },
                    { "Geography/History", 50 },
                }
            };

            var rule = new ThresholdFilter(new ThresholdFilterOption() { Bindings = bindings, Threshold = threshold});

            Assert.That(rule.Filter(application), Is.EqualTo(passed));
        }

        [TestCase(2, new[] { 10, 5, 1}, new[] { 10, 5 })]
        [TestCase(1, new[] { 5, 10, 1 }, new[] { 10})]
        [TestCase(2, new[] { 1, 5, 10 }, new[] { 10, 5 })]
        public void TopNTest(int N, int[] scores, int[] result)
        {
            var bnd = "Test";
            var applications = scores.Select(c => new Application() { Scores = new Dictionary<string, int> { { bnd, c} } }).ToList();
            var option = new TopNFilterOption() { N = N, OrderBy = bnd };
            var filter = new TopNFilter(option);
            CollectionAssert.AreEquivalent(result, filter.Filter(applications).Select(c => c.Scores[bnd]).ToArray());
        }
    }
}
using Moq;
using TapTest.Interfaces;
using TapTest.Managers;
using TapTest.Models;
using TapTest.Options;
using TapTest.Options.SelectionRule;

namespace TapTest.Tests
{
    internal class ApplicationManagerTest
    {
        private const string bnd = "Test1";
        private const string bnd2 = "Test2";

        private List<Application> testData => new()
        {
            new(){ Scores = new Dictionary<string, int>{{bnd, 10}, {bnd2, 5}}},
            new(){ Scores = new Dictionary<string, int>{{bnd, 20}, {bnd2, 0}}},
            new(){ Scores = new Dictionary<string, int>{{bnd, 5}, {bnd2, 20}}}

        };

        [TestCase(@$"{{""Bindings"":[""{bnd}"",""{bnd2}""],""Threshold"":15}}",3)]
        [TestCase(@$"{{""Bindings"":[""{bnd}""],""Threshold"":15}}", 1)]
        [TestCase(@$"{{""Bindings"":[""{bnd2}""],""Threshold"":15}}", 1)]
        [TestCase(@$"{{""Bindings"":[""{bnd2}""],""Threshold"":100}}", 0)]
        public void FilterTest(string thresholdOption, int expectedResult)
        {
            var repository = new Mock<IApplicationRepository>();
            repository.Setup(r => r.GetApplication(It.IsAny<char>())).Returns(testData);
            var manager = new ApplicationManager(repository.Object);

            var applications = manager.GetPassedApplications('0',
                new List<SelectionOptions>()
                {
                    new SelectionOptions()
                    {
                        Options = thresholdOption,
                        Type = FilterType.Threshold
                    }
                });

            Assert.That(applications.Count, Is.EqualTo(expectedResult));
        }
    }
}

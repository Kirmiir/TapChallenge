
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using TapTest.Domain;
using TapTest.Domain.Repositories;
using TapTest.Loader;
using TapTest.Managers;
using TapTest.Models;
using TapTest.Options;
using TapTest.Services;

namespace TapTest.Tests
{
    internal class FullCycleTests
    {
        private const string parserConfig = @"[
  {
    ""Binding"": ""English"",
    ""ColumnIndex"": 0
  },
  {
    ""Binding"": ""Math"",
    ""ColumnIndex"": 1
  },
  {
    ""Binding"": ""Science"",
    ""ColumnIndex"": 2
  },
  {
    ""Binding"": ""Japanese"",
    ""ColumnIndex"": 3
  },
  {
    ""Binding"": ""Geography/History"",
    ""ColumnIndex"": 4
  }
]
";

        private const string instituteConfig = @"{
  ""Departments"": [
    {
      ""DepartmentKey"": ""s"",
      ""SelectionOptions"": [
        {
          ""Type"": ""Threshold"",
          ""Options"": ""{\""Bindings\"":[\""English\"",\""Math\"",\""Science\"",\""Japanese\"",\""Geography/History\""],\""Threshold\"":350}""
        },
        {
          ""Type"": ""Threshold"",
          ""Options"": ""{\""Bindings\"":[\""Math\"",\""Science\""],\""Threshold\"":160}""
        }
      ]
    },
    {
      ""DepartmentKey"": ""l"",
      ""SelectionOptions"": [
        {
          ""Type"": ""Threshold"",
          ""Options"": ""{\""Bindings\"":[\""English\"",\""Math\"",\""Science\"",\""Japanese\"",\""Geography/History\""],\""Threshold\"":350}""
        },
        {
          ""Type"": ""Threshold"",
          ""Options"": ""{\""Bindings\"":[\""Japanese\"",\""Geography/History\""],\""Threshold\"":160}""
        }
      ]
    }
  ]
}
";

        [TestCase("dataSet1.txt", 2)]
        [TestCase("dataSet2.txt", 3)]
        public void FullCycleTest(string dataSetFileName, int expectedPassed)
        {
            var parserOptions = JsonConvert.DeserializeObject<SubjectOption[]>(parserConfig);
            var instituteOptions = JsonConvert.DeserializeObject<InstituteOptions>(instituteConfig);
            var loader = new TextReaderLoader(new ApplicationParser(parserOptions), new StringReader(File.ReadAllText(Path.Combine("TestData", dataSetFileName))));
            var logger = new Mock<ILogger>().Object;
            var instituteService =
                new InstituteService(new DepartmentService(new ApplicationManager(new ApplicationRepository(logger)), new DepartmentRepository(logger)),
                    new InstituteRepository(logger), logger);
            var institute = instituteService.Create(instituteOptions);

            foreach (var application in loader.Load())
            {
                instituteService.Apply(institute.Id, application);
            }

            Assert.That(instituteService.GetSuccessApplicants(institute.Id).Count, Is.EqualTo(expectedPassed));

        }
    }
}

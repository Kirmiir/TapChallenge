using NUnit.Framework.Internal;
using TapTest.Loader;
using TapTest.Options;

namespace TapTest.Tests.Loaders
{
    internal class TextReaderLoaderTest
    {
        private readonly List<SubjectOption> options = new List<SubjectOption>
        {
            new() { Binding = "English", ColumnIndex = 0 },
            new() { Binding = "Math", ColumnIndex = 1 },
            new() { Binding = "Science", ColumnIndex = 2 },
            new() { Binding = "Japanese", ColumnIndex = 3 },
            new() { Binding = "Geography/History", ColumnIndex = 4 },
        };

        [Test]
        public void Simple()
        {
            var str = @"2
s 70 78 82 57 74
l 68 81 81 60 78";
            var loader = new TextReaderLoader(new ApplicationParser(options), new StringReader(str));
            var applicants = loader.Load();
            Assert.That(applicants.Count, Is.EqualTo(2));
            var firstApplicant = applicants.First();
            Assert.That(firstApplicant.Subject, Is.EqualTo('s'));
            Assert.That(firstApplicant.Scores["English"], Is.EqualTo(70));
            Assert.That(firstApplicant.Scores["Math"], Is.EqualTo(78));
            Assert.That(firstApplicant.Scores["Science"], Is.EqualTo(82));
            Assert.That(firstApplicant.Scores["Japanese"], Is.EqualTo(57));
            Assert.That(firstApplicant.Scores["Geography/History"], Is.EqualTo(74));
            var secondApplicant = applicants.Last();
            Assert.That(secondApplicant.Subject, Is.EqualTo('l'));
            Assert.That(secondApplicant.Scores["English"], Is.EqualTo(68));
            Assert.That(secondApplicant.Scores["Math"], Is.EqualTo(81));
            Assert.That(secondApplicant.Scores["Science"], Is.EqualTo(81));
            Assert.That(secondApplicant.Scores["Japanese"], Is.EqualTo(60));
            Assert.That(secondApplicant.Scores["Geography/History"], Is.EqualTo(78));
        }
    }
}

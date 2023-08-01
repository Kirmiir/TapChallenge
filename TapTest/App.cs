using CommandLine;
using Microsoft.Extensions.Logging;
using TapTest.Domain.Repositories.Options;
using TapTest.Interfaces;
using TapTest.Loader;
using TapTest.Models;

namespace TapTest
{
    internal class App : IApplicationService
    {
        private readonly ILogger _logger;
        private readonly IInstituteOptionRepository _instituteRepository;
        private readonly ISubjectOptionRepository _subjectOptionRepository;
        private readonly IInstituteService _instituteService;

        public App(ILogger logger, IInstituteOptionRepository instituteRepository, ISubjectOptionRepository subjectOptionRepository, IInstituteService instituteService)
        {
            _logger = logger;
            _instituteRepository = instituteRepository;
            _subjectOptionRepository = subjectOptionRepository;
            _instituteService = instituteService;
        }

        private List<Application> LoadApplications(string parsingConfig)
        {
            var parser = new ApplicationParser(_subjectOptionRepository.GetSubjectOptions(parsingConfig));
            var loader = new TextReaderLoader(parser, Console.In);

            return loader.Load();
        }

        public void Run(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(opt =>
            {
                try
                {
                    var application = LoadApplications(opt.ParsingOption);

                    var institute = _instituteService.Create(_instituteRepository.Load(opt.Institute));

                    foreach (var applicant in application)
                    {
                        _instituteService.Apply(institute.Id, applicant);
                    }

                    Console.WriteLine(_instituteService.GetSuccessApplicants(institute.Id).Count);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Internal Error.");
                }
            });
        }

        private class Options
        {
            [Option('p', "parseOption", Required = false, HelpText = "fileName with parsing configuration.")]
            public string ParsingOption { get; set; }

            [Option('i', "institute", Required = false, HelpText = "fileName with institute structure.")]
            public string Institute { get; set; }
        }
    }
}

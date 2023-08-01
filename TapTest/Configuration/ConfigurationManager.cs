using Newtonsoft.Json;
using TapTest.Options;

namespace TapTest.Configuration
{
    public class ConfigurationManager
    {
        private const string DefaultParserConfig = "parser_config.json";

        private const string DefaultInstituteConfig = "institute_config.json";

        public SubjectOption[] GetParserSubjectOptions(string? filename)
        {
            return LoadSettingsFromFile<SubjectOption[]>(filename ?? DefaultParserConfig, null);
        }

        public InstituteOptions GetInstituteOptions(string? filename)
        {
            return LoadSettingsFromFile<InstituteOptions>(filename ?? DefaultInstituteConfig, null);
        }

        private T LoadSettingsFromFile<T>(string fileName, T defaultValue)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName)) ?? defaultValue;
        }
    }
}

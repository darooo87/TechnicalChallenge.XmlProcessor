using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TechnicalChallenge.Serializers.GenerationOutput;
using TechnicalChallenge.Serializers.GenerationOutput.Interfaces;
using TechnicalChallenge.Serializers.GenerationReport;
using TechnicalChallenge.Serializers.GenerationReport.Interfaces;
using TechnicalChallenge.Serializers.ReferenceData;
using TechnicalChallenge.Serializers.ReferenceData.Interfaces;
using TechnicalChallenge.XmlProcessor.Interfaces;
using TechnicalChallenge.XmlProcessor.Utils;

using IHost host = Host
    .CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(app =>
    {
        app.AddJsonFile("appsettings.json");
    })
    .ConfigureServices((_, services) =>
    {
        services.AddLogging(configure => configure.AddEventLog());
        services.AddTransient<IGenerationReportSerializer, GenerationReportSerializer>();
        services.AddTransient<IGenerationOutputSerializer, GenerationOutputSerializer>();
        services.AddTransient<IReferenceDataSerializer, ReferenceDataSerializer>();
        services.AddTransient<IDataProcessor, DataProcessor>();
        services.AddTransient<Application>();
    })
    .Build();

host.Services.GetRequiredService<Application>().StartProgram();

class Application
{
    private readonly IGenerationReportSerializer _generationReportSerializer;

    private readonly IGenerationOutputSerializer _generationOutputSerializer;

    private readonly IReferenceDataSerializer _referenceDataSerializer;

    private readonly IDataProcessor _dataProcessor;

    private readonly IConfiguration _configuration;

    private readonly ILogger<Application> _logger;

    public Application(
        IGenerationReportSerializer generationReportSerializer,
        IGenerationOutputSerializer generationOutputSerializer,
        IReferenceDataSerializer referenceDataSerializer,
        IDataProcessor dataProcessor,
        IConfiguration configuration,
        ILogger<Application> logger)
    {
        _generationReportSerializer = generationReportSerializer;
        _generationOutputSerializer = generationOutputSerializer;
        _referenceDataSerializer = referenceDataSerializer;
        _dataProcessor = dataProcessor;
        _configuration = configuration;
        _logger = logger;
    }

    public void StartProgram()
    {
        var referenceData = _referenceDataSerializer.Deserialize("ReferenceData.xml");

        while (true)
        {
            var files = Directory.GetFiles(_configuration["AppSettings:InputFolder"], "*.xml");

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                try
                {
                    var generationReport = _generationReportSerializer.Deserialize(fileInfo.FullName);

                    var totals = _dataProcessor.GetReportTotals(generationReport, referenceData);
                    var maxEmissions = _dataProcessor.GetMaxDayEmissions(generationReport, referenceData);
                    var actualHeat = _dataProcessor.GetGeneratorHeatRates(generationReport);

                    var outputFileName = Path.GetFileNameWithoutExtension(fileInfo.FullName) + "-Result" + fileInfo.Extension;
                    var outputPath = Path.Combine(_configuration["AppSettings:OutputFolder"], outputFileName);

                    _generationOutputSerializer.Serialize(outputPath, totals, maxEmissions, actualHeat);

                    _logger.LogDebug($"File processed {fileInfo.Name}");
                    
                    File.Move(fileInfo.FullName, fileInfo.FullName + ".processed");
                }
                catch(Exception e)
                {
                    _logger.LogError($"Couldn't process file {fileInfo.Name} reason {e.Message}");

                    File.Move(fileInfo.FullName, fileInfo.FullName + ".unprocessable");
                }
            }

            Thread.Sleep(1000);
        }
    }
}
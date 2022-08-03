using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TechnicalChallenge.Serializers.GenerationReport.Interfaces;
using TechnicalChallenge.Serializers.GenerationReport.Model;
using TechnicalChallenge.Serializers.ReferenceData.Interfaces;
using TechnicalChallenge.XmlProcessor.Interfaces;
using TechnicalChallenge.XmlProcessor.Utils;

namespace TechnicalChallenge.XmlProcessor.Tests
{
    [TestClass]
    public class DataProcessorTests
    {
        IDataProcessor _dataProcessor;

        private Mock<IGenerationReportSerializer> _reportSerializer;

        private Mock<IReferenceData> _referenceData;

        public DataProcessorTests()
        {
            var services = new ServiceCollection();

            services.AddTransient<IDataProcessor, DataProcessor>();

            var serviceProvider = services.BuildServiceProvider();

            var dataProcessor = serviceProvider.GetService<IDataProcessor>();

            if (dataProcessor == null)
                throw new Exception("Error when configuring DataProcessor");

            _dataProcessor = dataProcessor;
            _reportSerializer = new Mock<IGenerationReportSerializer>();
            _referenceData = new Mock<IReferenceData>();
        }

        private IGenerationReportSerializer GetGenerationReportSerializer()
        {
            _reportSerializer
                .Setup(s => s.Deserialize(It.IsAny<string>()))
                .Returns(new GenerationReport
                {
                    Coal = new ICoalGenerator[] {
                        new CoalGenerator
                        {
                             Name = "Coal[1]",
                             Generation = new IDailyGeneratorSummary[]
                             {
                                 new DailyGeneratorSummary
                                 {
                                      Date = DateTime.Now,
                                      Energy = 348M,
                                      Price = 121
                                 }
                             }
                        }
                    },

                });

            return _reportSerializer.Object;
        }

        private IReferenceData GetReferenceData()
        {
            _referenceData
                .Setup(s => s.ValueFactors)
                .Returns(new Dictionary<string, decimal>
                {
                    { "Low", 0.946M },
                    { "Medium", 0.696M },
                    { "High", 0.265M },
                });

            _referenceData
                .Setup(s => s.EmissionsFactors)
                .Returns(new Dictionary<string, decimal>
                {
                    { "Low", 0.812M },
                    { "Medium", 0.562M },
                    { "High", 0.312M },
                });

            return _referenceData.Object;
        }

        [TestMethod]
        public void ProcessReport_GetReportTotals()
        {
            var report = GetGenerationReportSerializer().Deserialize("");
            var referenceData = GetReferenceData();

            var data = _dataProcessor.GetReportTotals(report, referenceData);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length > 0);
            Assert.AreEqual(data[0].Total, 39834.168M);
        }

        [TestMethod]
        public void ProcessReport_GetReportTotals_UseInvalidData()
        {
            //TODO
        }

        [TestMethod]
        public void ProcessReport_GetMaxDayEmissions()
        {
            //TODO
        }

        [TestMethod]
        public void ProcessReport_GetMaxDayEmissions_UseInvalidData()
        {
            //TODO
        }

        [TestMethod]
        public void ProcessReport_GetHeatRates()
        {
            //TODO
        }

        [TestMethod]
        public void ProcessReport_GetHeatRates_UseInvalidData()
        {
            //TODO
        }
    }
}
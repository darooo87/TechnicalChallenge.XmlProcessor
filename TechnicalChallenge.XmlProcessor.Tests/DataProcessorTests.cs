using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnicalChallenge.XmlProcessor.Interfaces;
using TechnicalChallenge.XmlProcessor.Utils;

namespace TechnicalChallenge.XmlProcessor.Tests
{
    [TestClass]
    public class DataProcessorTests
    {
        IDataProcessor _dataProcessor;

        public DataProcessorTests()
        {
            var services = new ServiceCollection();
            
            services.AddTransient<IDataProcessor, DataProcessor>();

            var serviceProvider = services.BuildServiceProvider();

            var dataProcessor = serviceProvider.GetService<IDataProcessor>();

            if (dataProcessor == null)
                throw new Exception("Error when configuring DataProcessor");

            _dataProcessor = dataProcessor;
        }

        [TestMethod]
        public void ProcessReport_GetReportTotals()
        {
            //TODO
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
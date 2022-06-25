using DDD.Domain.Entity;
using DDD.Domain.Repositories;
using DDDPractice.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var viewModel = new WeatherLatestViewModel(new WeatherMock());
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            viewModel.AreaIdText = "1";
            viewModel.search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2022/06/23 13:15:44", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30℃", viewModel.TemperatureText);
        }
    }

    internal class WeatherMock : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            return new WeatherEntity(1, Convert.ToDateTime("2022/06/23 13:15:44"), 2, 12.3f);
        }


    }
}

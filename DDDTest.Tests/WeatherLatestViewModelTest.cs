using DDD.Domain.Entities;
using DDD.Domain.Entity;
using DDD.Domain.Repositories;
using DDDPractice.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            weatherMock.Setup(x => x.GetLatest(1))
                .Returns(new WeatherEntity(1, Convert.ToDateTime("2022/06/23 13:15:44"), 2, 12.3f));
           
            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "神戸"));
            var areasMock = new Mock<IAreasRepository>();
            areasMock.Setup(x => x.GetData())
                .Returns(areas);

            var viewModel = new WeatherLatestViewModel(weatherMock.Object, areasMock.Object);

            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);
            viewModel.Areas.Count.Is(2);
            viewModel.Areas[0].AreaId.Is(1);
            viewModel.Areas[0].AreaName.Is("東京");

            viewModel.AreaIdText = "1";
            viewModel.search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2022/06/23 13:15:44", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30℃", viewModel.TemperatureText);

            //weatherMock.Setup(x => x.GetLatest(2)).
            //    Returns(new WeatherEntity(2, Convert.ToDateTime("2022/06/23 13:15:44"), 2, 12.3f));

            //viewModel.AreaIdText = "2";
            //viewModel.search();
            //viewModel.AreaIdText.Is("2");
            //viewModel.DataDateText.Is("2022/06/23 13:15:44");
            //viewModel.ConditionText.Is("曇り");
            //viewModel.TemperatureText.Is("12.30℃");
        }
    }

    //internal class WeatherMock : IWeatherRepository
    //{
    //    public WeatherEntity GetLatest(int areaId)
    //    {
    //        return new WeatherEntity(1, Convert.ToDateTime("2022/06/23 13:15:44"), 2, 12.3f);
    //    }
    //}
    //internal class areasMock : IAreasRepository
    //{
    //    public IReadOnlyList<AreaEntity> GetData()
    //    {
    //        var areas = new List<AreaEntity>();
    //        areas.Add(new AreaEntity(1, "東京"));
    //        areas.Add(new AreaEntity(2, "神戸"));
    //        return areas;
    //    }
    //}
}

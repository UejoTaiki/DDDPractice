﻿using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDPractice.ViewModels
{
    public class WeatherLatestViewModel : INotifyPropertyChanged
    {
        private IWeatherRepository _weather;

        public WeatherLatestViewModel()
            : this(new WeatherSQLite())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        public string AreaIdText { get; set; } = string.Empty;
        public string DataDateText { get; set; } = string.Empty;
        public string ConditionText { get; set; } = string.Empty;
        public string TemperatureText { get; set; } = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public void search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));
            if(entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnit;
            }

            OnPropertyChanged("");
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}

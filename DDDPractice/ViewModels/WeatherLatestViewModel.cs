using DDD.Domain.Entities;
using DDD.Domain.Repositories;
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
        private IAreasRepository _areas;

        public WeatherLatestViewModel()
            : this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather, IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;

            foreach(var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        public object SelectedAreaId { get; set; }
        public string DataDateText { get; set; } = string.Empty;
        public string ConditionText { get; set; } = string.Empty;
        public string TemperatureText { get; set; } = string.Empty;
        public BindingList<AreaEntity> Areas { get; set; } = new BindingList<AreaEntity>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(SelectedAreaId));
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

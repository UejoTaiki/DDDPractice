﻿using DDD.Domain.Entity;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            string sql = @"
select DataDate
Condition
Temperature
from Weather
where AreaId = @AreaId
order by DataDate desc
LIMIT 1
";
            using(var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using(var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                    }
                }
            }

            return null;

        }
    }
}

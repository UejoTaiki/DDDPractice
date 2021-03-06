using DDD.Domain.Entity;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            string sql = @"select DataDate, Condition, Temperature from Weather where AreaId = @AreaId order by DataDate desc LIMIT 1";
            return SQLiteHelper.QuerySingle(
                sql,
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("aAreaId", areaId)
                }.ToArray(),
                reader =>
                {
                    return new WeatherEntity(
                                areaId,
                                Convert.ToDateTime(reader["DataDate"]),
                                Convert.ToInt32(reader["Condition"]),
                                Convert.ToSingle(reader["Temperature"]));
                },
                null);

            //using(var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            //using(var command = new SQLiteCommand(sql, connection))
            //{
            //    connection.Open();

            //    command.Parameters.AddWithValue("@AreaId", areaId);
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            return new WeatherEntity(
            //                areaId,
            //                Convert.ToDateTime(reader["DataDate"]),
            //                Convert.ToInt32(reader["Condition"]),
            //                Convert.ToSingle(reader["Temperature"]));
            //        }
            //    }
            //}
            //return null;
        }
    }
}

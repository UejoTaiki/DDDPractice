using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDPractice
{
    public partial class WeatherLatestView : Form
    {
        private readonly string ConnectionString = @"Data Source=C:\Users\b21a0145\Desktop\DDD.db;Version=3";

        public WeatherLatestView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            string sql = @"select DataDate
                                  Condition
                                  Temperature
                                  from Weather
                                  where AreaId = @AreaId
                                  order by DataDate desc
                                  LIMIT 1
                          ";
        }
    }
}

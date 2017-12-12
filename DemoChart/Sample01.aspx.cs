using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace DemoChart
{
    public partial class Sample01 : System.Web.UI.Page
    {
        DataClassesDataContext _db = new DataClassesDataContext(ConfigurationManager.ConnectionStrings["chartConnectionString1"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChartType();

                LoadChart1();

                LoadChart2();
            }
        }

        private void LoadChartType()
        {
            string[] chartType = Enum.GetNames(typeof(SeriesChartType));
            drTypeChart.DataSource = chartType;
            drTypeChart.DataBind();
            drTypeChart.Items.Insert(0, new ListItem("--Lựa chọn--", "Column"));
            DropDownList1.DataSource = chartType;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Lựa chọn--", "Column"));
        }

        private void LoadChart1()
        {
            try
            {
                //get data from SQL
                var tb = from data in _db.tblCategories
                         select new
                         {
                             col1 = data.Category,
                             col2 = data.NumberArticle
                         };

                //Set chart data source
                Chart1.DataSource = tb;

                //Set series members names for the X and Y values
                Chart1.Series["Category"].XValueMember = "col1";
                Chart1.Series["Category"].YValueMembers = "col2";

                //Data bind to the selected data source
                Chart1.DataBind();

                //name x,y
                Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Số bài viết";
                Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Chuyên mục";
            }
            catch (Exception ms)
            {
                Response.Write(ms.Message);
            }
        }

        private void LoadChart2()
        {
            try
            {
                //get data from SQL
                var tb = from data in _db.tblJobs
                         select new
                         {
                             col1 = data.Month,
                             col2 = data.AspNet,
                             col3 = data.PHP
                         };

                //Set chart data source
                Chart2.DataSource = tb;

                //Set series members names for the X and Y values
                Chart2.Series["aspnet"].XValueMember = "col1";
                Chart2.Series["aspnet"].YValueMembers = "col2";
                Chart2.Series["php"].XValueMember = "col1";
                Chart2.Series["php"].YValueMembers = "col3";

                //Data bind to the selected data source
                Chart2.DataBind();

                //name x,y
                Chart2.ChartAreas["ChartArea2"].AxisX.Title = "Tháng";
                Chart2.ChartAreas["ChartArea2"].AxisY.Title = "Số lượng tuyển dụng";
            }
            catch (Exception ms)
            {
                Response.Write(ms.Message);
            }
        }

        protected void drTypeChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart1.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), drTypeChart.SelectedValue);
            Chart2.Series["aspnet"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
            Chart2.Series["php"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
            LoadChart1();
            LoadChart2();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart1.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), drTypeChart.SelectedValue);
            Chart2.Series["php"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
            Chart2.Series["aspnet"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
            LoadChart2();
            LoadChart1();
        }
    }
}
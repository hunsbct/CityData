using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CityData.CityDataServiceReference;
// TODO comments and class summaries
// TODO add something to default
namespace CityData
{
    public partial class Default : System.Web.UI.Page
    {
        CityDataService cds = new CityDataService();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            cds.PopulateCityTable();
        }
    }
}
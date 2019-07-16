using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CityData.CityDataServiceReference;
using System.Diagnostics;
using Utilities;
using CityObjects;
using System.Collections;

namespace CityData
{
    public partial class Search : System.Web.UI.Page
    {
        CityDataService cds = new CityDataService();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string attribute = ddlSearchType.SelectedValue, comparison = ddlComparison.SelectedValue, value = txtSearchValue.Text;
            int valueInt;

            try
            {
                valueInt = int.Parse(value);
                ArrayList results = ExecuteSearch(attribute, comparison, valueInt);
                // TOO vertical gridlines in viewcity table
                if (results.Count > 0)
                {
                    DisplayResults(results);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadealertnoresults", "FadeAlertNoResults();", true);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadealertsearch", "FadeAlert();", true);
            }
        }

        public ArrayList ExecuteSearch(string attribute, string comparison, int value)
        {
            object[] result = null;
            switch (attribute)
            {
                case "Population":
                    switch (comparison)
                    {
                        case "<":
                            result = cds.Search_PopulationLessThan(value);
                            break;
                        case "=":
                            result = cds.Search_PopulationEquals(value);
                            break;
                        case ">":
                            result = cds.Search_PopulationGreaterThan(value);
                            break;
                        default:
                            break;
                    }
                    break;
                case "MedianHouseholdIncome":
                    switch (comparison)
                    {
                        case "<":
                            result = cds.Search_MedianHouseholdIncomeLessThan(value);
                            break;
                        case "=":
                            result = cds.Search_MedianHouseholdIncomeEquals(value);
                            break;
                        case ">":
                            result = cds.Search_MedianHouseholdIncomeGreaterThan(value);
                            break;
                        default:
                            break;
                    }
                    break;
                case "MedianHomeValue":
                    switch (comparison)
                    {
                        case "<":
                            result = cds.Search_MedianHomeValueLessThan(value);
                            break;
                        case "=":
                            result = cds.Search_MedianHomeValueEquals(value);
                            break;
                        case ">":
                            result = cds.Search_MedianHomeValueGreaterThan(value);
                            break;
                        default:
                            break;
                    }
                    break;
                case "MedianMaleAge":
                    switch (comparison)
                    {
                        case "<":
                            result = cds.Search_MedianMaleAgeLessThan(value);
                            break;
                        case "=":
                            result = cds.Search_MedianMaleAgeEquals(value);
                            break;
                        case ">":
                            result = cds.Search_MedianMaleAgeGreaterThan(value);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            
            return new ArrayList(result);
        }

        public void DisplayResults(ArrayList results)
        {
            rptSearchResults.DataSource = results;
            rptSearchResults.DataBind();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CityData.CityDataServiceReference;
namespace CityData
{
    public partial class ViewCity : System.Web.UI.Page
    {
        CityDataService cds = new CityDataService();
        City result;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate states DDL on first load
            if (!IsPostBack)
            {
                PopulateStates();               
            }

            // If no city data is loaded into the page, don't show the table
            if (lblViewCityName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hidetable", "HideTable();", true);
            }
        }

        // Populate City ddl
        public void PopulateCities(string state)
        {
            // In case the user selects a city then the "Select a City..." option
            if (ddlState.SelectedIndex == 0)
            {
                ddlCity.DataSource = null;
                ddlCity.DataBind();
                ddlCity.Visible = false;
                btnSubmitCity.Visible = false;
            }
            else
            {
                // Get list of cities for a state, fill list with data elements, bind with cities DDL, and update control visibility
                List<string> cities = new List<string>();
                DataSet citiesDS = cds.GetCities(state);
                for (int x = 0; x < citiesDS.Tables[0].Rows.Count; x++)
                {
                    cities.Add(citiesDS.Tables[0].Rows[x]["City"].ToString());
                }
                ddlCity.DataSource = cities;
                ddlCity.DataBind();
                ddlCity.Visible = true;
                btnSubmitCity.Visible = true;
            }
        }

        // Populate State ddl
        public void PopulateStates()
        {
            // Populate States ddl
            DataSet statesDS = cds.GetStates();
            // Convert table column to list without a loop
            List<string> states = statesDS.Tables[0].Rows.OfType<DataRow>().Select(dr => dr.Field<string>("State")).ToList();
            states.Insert(0, "Select a state...");
            ddlState.DataSource = states;
            ddlState.DataBind();
        }

        // Load cities into ddl based on the selected state
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCities(ddlState.SelectedItem.ToString());
        }

        // Click event for pulling up city data
        protected void btnSubmitCity_Click(object sender, EventArgs e)
        {
            // Would have liked to have found a way to make the table fade before the new data loads, but time is running short and it's purely cosmetic.
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadeouttable", "FadeOutTable();", true);
            string state = ddlState.SelectedItem.ToString(), city = ddlCity.SelectedItem.ToString();
            result = cds.GetDataForCity(city, state);
            if (result != null)
            {
                lblViewCityName.Text = result.CityName + ", " + result.State;

                cellPop.InnerText = result.Population.ToString();
                cellMHI.InnerText = result.MedianHouseholdIncome.ToString("C0");
                cellMHV.InnerText = result.MedianHomeValue.ToString("C0");
                cellMMA.InnerText = result.MedianMaleAge.ToString();
                cellMFA.InnerText = result.MedianFemaleAge.ToString();
                cellPH.InnerText = result.PercentOwners.ToString() + "%";
                cellPR.InnerText = result.PercentRenters.ToString() + "%";
                cellCI.InnerText = result.CrimeIndex.ToString();
                cellUE.InnerText = result.UnemploymentRate.ToString() + "%";
                
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadeintable", "FadeInTable();", true);
            }
            // Not bothering with an else, since there's no reason a city should be selected from the DDLs that doesn't exist
        }
    }
}
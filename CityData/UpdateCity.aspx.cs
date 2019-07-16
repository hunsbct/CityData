using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CityData.CityDataServiceReference;
using System.Diagnostics;
/// <summary>
/// Author: Cody Hunsberger
/// 
/// Code-behind for update city page
/// </summary>
namespace CityData
{
    public partial class UpdateCity: System.Web.UI.Page
    {
        CityDataService cds = new CityDataService();
        City result;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStates();
                DisableTextFields();
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
            btnSubmitCity.Enabled = true;
            btnUpdateCity.Enabled = false;
        }

        // Click handler for pulling up existing city data
        protected void btnSubmitCity_Click(object sender, EventArgs e)
        {
            string state = ddlState.SelectedItem.ToString(), city = ddlCity.SelectedItem.ToString();
            result = cds.GetDataForCity(city, state);

            if(result != null)
            {
                EnableTextFields();
                PopulateTextFields(result);
                btnSubmitCity.Enabled = false;
                btnUpdateCity.Enabled = true;
            }
        }

        // Update city click event
        protected void btnUpdateCity_Click(object sender, EventArgs e)
        {
            bool cityUpdated = false;

            try
            {
                // Collect values from form
                int population = int.Parse(txtPopulation.Text);
                int medianHouseholdIncome = int.Parse(txtMedianHouseholdIncome.Text);
                decimal percentOwners = decimal.Parse(txtPercentOwners.Text);
                decimal percentRenters = decimal.Parse(txtPercentRenters.Text);
                int medianHomeValue = int.Parse(txtMedianHomeValue.Text);
                int medianMaleAge = int.Parse(txtMedianMaleAge.Text);
                int medianFemaleAge = int.Parse(txtMedianFemaleAge.Text);
                decimal unemploymentRate = decimal.Parse(txtUnemploymentRate.Text);
                decimal crimeIndex = decimal.Parse(txtCrimeIndex.Text);

                // Using an object initializer to create new City object
                CityDataServiceReference.City newCity = new CityDataServiceReference.City
                {
                    CityName = txtCity.Text,
                    State = txtState.Text,
                    Population = population,
                    MedianHouseholdIncome = medianHouseholdIncome,
                    PercentOwners = percentOwners,
                    PercentRenters = percentRenters,
                    MedianHomeValue = medianHomeValue,
                    MedianMaleAge = medianMaleAge,
                    MedianFemaleAge = medianFemaleAge,
                    UnemploymentRate = unemploymentRate,
                    CrimeIndex = crimeIndex
                };

                // Instantiate web service and add city
                CityDataService cds = new CityDataService();
                cityUpdated = cds.UpdateCity(newCity);

                if (cityUpdated)
                {
                    IEnumerable<Control> allTextBoxes = GetAllControlsOfType(this, typeof(TextBox));
                    // Fade out text fields during clear. Really wanted the clear to take place while they were not visible, but I can't get the timing right
                    foreach (TextBox textbox in allTextBoxes)
                    {
                        textbox.Text = "";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadeconfirm", "FadeConfirm();", true);

                    btnSubmitCity.Enabled = true;
                    btnUpdateCity.Enabled = false;
                }
                else
                {
                    ShowUnknownError();
                }

            }
            catch (FormatException fe)
            {
                Debug.WriteLine(fe.ToString());
                string fieldName = FindInvalidField();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "invalidvalue", "$('.alert-message').text('The value in the " + fieldName + " field is invalid. Please enter a value that matches the data type indicated');", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadealert", "FadeAlert();", true);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                ShowUnknownError();
            }
        }

        // This one is used in several places so it got its own method
        public void ShowUnknownError()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "unknownerror", "$('.alert-message').text('Something went wrong. Please try again.');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadealert2", "FadeAlert();", true);
        }

        // Determine which field has invalid data
        public string FindInvalidField()
        {
            string fieldName = "";
            int resultInt;
            decimal resultDecimal;

            if (!int.TryParse(txtMedianHouseholdIncome.Text, out resultInt))
            {
                fieldName = "median household income";
                txtMedianHouseholdIncome.Text = "";
            }
            else if (!decimal.TryParse(txtPercentOwners.Text, out resultDecimal))
            {
                fieldName = "percent owners";
                txtPercentOwners.Text = "";
            }
            else if (!decimal.TryParse(txtPercentRenters.Text, out resultDecimal))
            {
                fieldName = "percent renters";
                txtPercentRenters.Text = "";
            }
            else if (!int.TryParse(txtMedianHomeValue.Text, out resultInt))
            {
                fieldName = "median home value";
                txtMedianHomeValue.Text = "";
            }
            else if (!int.TryParse(txtMedianMaleAge.Text, out resultInt))
            {
                fieldName = "median male age";
                txtMedianMaleAge.Text = "";
            }
            else if (!int.TryParse(txtMedianFemaleAge.Text, out resultInt))
            {
                fieldName = "median female age";
                txtMedianFemaleAge.Text = "";
            }
            else if (!decimal.TryParse(txtUnemploymentRate.Text, out resultDecimal))
            {
                fieldName = "unemployment rate";
                txtUnemploymentRate.Text = "";
            }
            else if (!decimal.TryParse(txtCrimeIndex.Text, out resultDecimal))
            {
                fieldName = "crime index";
                txtCrimeIndex.Text = "";
            }

            return fieldName;
        }

        // Fill text fields with city properties
        public void PopulateTextFields(City city)
        {
            txtCity.Text = city.CityName;
            txtState.Text = city.State;
            txtPopulation.Text = city.Population.ToString();
            txtMedianHouseholdIncome.Text = city.MedianHouseholdIncome.ToString();
            txtMedianHomeValue.Text = city.MedianHomeValue.ToString();
            txtMedianMaleAge.Text = city.MedianMaleAge.ToString();
            txtMedianFemaleAge.Text = city.MedianFemaleAge.ToString();
            txtPercentOwners.Text = city.PercentOwners.ToString();
            txtPercentRenters.Text = city.PercentRenters.ToString();
            txtUnemploymentRate.Text = city.UnemploymentRate.ToString();
            txtCrimeIndex.Text = city.CrimeIndex.ToString();
        }

        // Enable all text fields other than city and state
        public void EnableTextFields()
        {
            IEnumerable<Control> allTextBoxes = GetAllControlsOfType(this, typeof(TextBox));
            foreach (TextBox textbox in allTextBoxes)
            {
                if(textbox.ID != "txtCity" && textbox.ID != "txtState")
                {
                    textbox.Enabled = true;
                }
            }
        }

        // Disable all text fields
        public void DisableTextFields()
        {
            IEnumerable<Control> allTextBoxes = GetAllControlsOfType(this, typeof(TextBox));
            foreach (TextBox textbox in allTextBoxes)
            {
                textbox.Enabled = false;
            }
        }

        // Borrowed snipped to gather references to all text fields in the page
        public IEnumerable<Control> GetAllControlsOfType(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControlsOfType(ctrl, type))
                .Concat(controls)
                .Where(c => c.GetType() == type);
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSubmitCity.Enabled = true;
            btnUpdateCity.Enabled = false;
        }
    }
}
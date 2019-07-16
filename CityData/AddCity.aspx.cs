using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CityData.CityDataServiceReference;
using CityObjects;
using System.Diagnostics;
using System.Data;
using System.Threading;
/// <summary>
/// Author: Cody Hunsberger
/// 
/// Code-behind for add new city page
/// </summary>
namespace CityData
{
    public partial class AddCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Add City click event
        protected void BtnAddCity_Click(object sender, EventArgs e)
        {
            bool cityAdded = false;

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
                cityAdded = cds.AddCity(newCity);

                if(cityAdded)
                {
                    IEnumerable<Control> allTextBoxes = GetAllControlsOfType(this, typeof(TextBox));
                    // Fade out text fields during clear. Really wanted the clear to take place while they were not visible, but I can't get the timing right
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadeout", "FadeOutTxts();", true);
                    foreach (TextBox textbox in allTextBoxes)
                    {
                        textbox.Text = "";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadein", "FadeInTxts();", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadeconfirm", "FadeConfirm();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadeduplicate", "FadeDuplicate();", true);
                }
                
            }
            // Catch invalid value exceptions and specify which field was wrong
            catch(FormatException fe)
            {
                Debug.WriteLine(fe.ToString());
                string fieldName = FindInvalidField();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "invalidvalue", "$('.alert-message').text('The value in the " + fieldName + " field is invalid. Please enter a value that matches the data type indicated');", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "fadealert", "FadeAlert();", true);

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
            }
        }

        // Determine which field has invalid data and clear it
        public string FindInvalidField()
        {
            string fieldName = "";
            int resultInt;
            decimal resultDecimal;

            if(!int.TryParse(txtMedianHouseholdIncome.Text, out resultInt))
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

        // Borrowed snippet for creating an iterable list of all textboxes for clearing on successful add
        public IEnumerable<Control> GetAllControlsOfType(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControlsOfType(ctrl, type))
                .Concat(controls)
                .Where(c => c.GetType() == type);
        }
    }
}
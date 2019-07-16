using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Diagnostics;
using Utilities;
using CityObjects;
using System.Collections;
/// <summary>
/// Author: Cody Hunsberger
/// 
/// Web service class with web methods
/// </summary>
namespace CityDataWebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class CityDataService : System.Web.Services.WebService
    {
        SPFunctions tools = new SPFunctions();

        // Get all data for all cities
        [WebMethod]
        public ArrayList GetAllCityData()
        {
            DataSet ds = tools.GetAllCityData();
            return CityFunctions.CreateListFromDataSet(ds);
        }

        // Get all data for one city
        [WebMethod]
        public City GetDataForCity(string city, string state)
        {
            DataRow dr = tools.GetDataForCity(city, state).Tables[0].Rows[0];
            return CityFunctions.CreateCityFromDataRow(dr);
        }

        // Get list of states with cities in the DB
        [WebMethod]
        public DataSet GetStates()
        {
            return tools.GetStates();
        }

        // Get list of cities in DB
        [WebMethod]
        public DataSet GetCities(string state)
        {
            return tools.GetCitiesByState(state);
        }

        // Add new city
        [WebMethod]
        public bool AddCity (City city)
        {
            bool result, cityExists = false;
            DataSet cityStatePairs = tools.GetCityStatePairs();
            
            // Check if city exists in DB
            foreach(DataRow dr in cityStatePairs.Tables[0].Rows)
            {
                if( dr["City"].ToString().ToLower() == city.CityName.ToLower() &&
                    dr["State"].ToString().ToLower() == city.State.ToLower())
                {
                    cityExists = true;
                    break;
                }
            }

            // If city does not exist, try to create it
            if(!cityExists)
            {
                // If the city does not exist and it is successfully added, result = true
                try
                {
                    tools.AddCity(city.CityName, city.State, city.Population, city.MedianHouseholdIncome, city.PercentOwners, city.PercentRenters, city.MedianHomeValue, city.MedianMaleAge, city.MedianFemaleAge, city.UnemploymentRate, city.CrimeIndex);
                    result = true;
                }
                // If there is an exception, result = false
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    result = false;
                }
            }
            // If city does exist, return false
            else
            {
                result = false;
            }

            return result;
        }

        // Get a two-column dataset of city/state pairs for DDL population and duplicate checking
        [WebMethod]
        public DataSet GetCityStatePairs()
        {
            return tools.GetCityStatePairs();
        }

        ///////////////////
        // Search methods//
        ///////////////////

        [WebMethod]
        public ArrayList Search_PopulationLessThan(int value)
        {
            DataSet data = tools.Search_PopulationLessThan(value);
            return CityFunctions.CreateListFromDataSet(data);
        }

        [WebMethod]
        public ArrayList Search_PopulationEquals(int value)
        {
            DataSet ds = tools.Search_PopulationEquals(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_PopulationGreaterThan(int value)
        {
            DataSet ds = tools.Search_PopulationGreaterThan(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianHouseholdIncomeLessThan(int value)
        {
            DataSet ds = tools.Search_MedianHouseholdIncomeLessThan(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianHouseholdIncomeEquals(int value)
        {
            DataSet ds = tools.Search_MedianHouseholdIncomeEquals(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianHouseholdIncomeGreaterThan(int value)
        {
            DataSet ds = tools.Search_MedianHouseholdIncomeGreaterThan(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianHomeValueLessThan(int value)
        {
            DataSet ds = tools.Search_MedianHomeValueLessThan(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianHomeValueEquals(int value)
        {
            DataSet ds = tools.Search_MedianHomeValueEquals(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianHomeValueGreaterThan(int value)
        {
            DataSet ds = tools.Search_MedianHomeValueGreaterThan(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianMaleAgeLessThan(int value)
        {
            DataSet ds = tools.Search_MedianMaleAgeLessThan(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianMaleAgeEquals(int value)
        {
            DataSet ds = tools.Search_MedianMaleAgeEquals(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public ArrayList Search_MedianMaleAgeGreaterThan(int value)
        {
            DataSet ds = tools.Search_MedianMaleAgeGreaterThan(value);
            return CityFunctions.CreateListFromDataSet(ds);
        }

        [WebMethod]
        public bool UpdateCity(City city)
        {
            bool status = false;

            try
            {
                tools.UpdateCity(city.CityName, city.State, city.Population, city.MedianHouseholdIncome, city.PercentOwners, city.PercentRenters, city.MedianHomeValue, city.MedianMaleAge, city.MedianFemaleAge, city.UnemploymentRate, city.CrimeIndex);
                status = true;
            }
            // If there is an exception, result = false
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                status = false;
            }

            return status;
        }

        // Add cities to empty table for a good volume of starting data
        [WebMethod]
        public void PopulateCityTable()
        {
            // 1
            tools.AddCity("Philadelphia", "Pennsylvania", 1567872, 41233, 65.4m, 35.6m, 154000, 32, 35, 7.7m, 469.6m);
            // 2
            tools.AddCity("New York", "New York", 8538000, 55752, 41m, 51m, 432600, 36, 39, 3.9m, 222.2m);
            // 3
            tools.AddCity("Pittsburgh", "Pennsylvania", 303264, 44707, 47.7m, 52.3m, 132400, 31, 35, 4.3m, 402.7m);
            // 4
            tools.AddCity("Los Angeles", "California", 3976324, 55909, 47.8m, 52.2m, 671000, 33, 35, 4.4m, 347.1m);
            // 5
            tools.AddCity("San Francisco", "California", 870887, 78378, 36.5m, 63.5m, 1289300, 38, 38, 2.3m, 473.6m);
            // 6
            tools.AddCity("Washington", "District of Columbia", 681170, 75628, 39.2m, 60.8m, 576100, 33, 34, 6m, 568.9m);
            // 7
            tools.AddCity("Detroit", "Michigan", 672829, 26249, 47m, 52m, 44600, 33, 37, 7.8m, 868m);
            // 8
            tools.AddCity("Houston", "Texas", 2304388, 61708, 41.3m, 58.7m, 188000, 31, 32, 4.2m, 520.7m);
            // 9
            tools.AddCity("Austin", "Texas", 947897, 55216, 42.47m, 57.53m, 337600, 30, 31, 2.6m, 312.7m);
            // 10
            tools.AddCity("Allentown", "Pennsylvania", 120440, 32016, 45m, 55m, 126100, 31, 33, 6.7m, 293.2m);
            // 11
            tools.AddCity("Kansas City", "Missouri", 470800, 45376, 54m, 46m, 128300, 33, 35, 3.6m, 707.5m);
            // 12
            tools.AddCity("Oklahoma City", "Oklahoma", 620602, 47004, 59m, 41m, 131900, 33, 35, 3.4m, 435.8m);
            // 13
            tools.AddCity("Boston", "Massachusetts", 672840, 82380, 35m, 65m, 569500, 30, 31, 3m, 303.5m);
            // 14
            tools.AddCity("Columbus", "Ohio", 862643, 49602, 45m, 55m, 140400, 30, 32, 3.6m, 414.8m);
            // 15
            tools.AddCity("Denver", "Colorado", 693060, 61105, 49.4m, 50.6m, 407100, 33, 33, 2.8m, 402.4m);
            // 16
            tools.AddCity("Anchorage", "Alaska", 301010, 85634, 63.7m, 36.3m, 300200, 32, 33, 5.8m, 621m);
        }
    }
}

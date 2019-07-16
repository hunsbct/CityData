using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
/// <summary>
/// Author: Cody Hunsberger
/// 
/// Group of methods to handle actions performed on City and CityList objects
/// </summary>
namespace CityObjects
{
    public static class CityFunctions
    {
        public static City CreateCityFromDataRow(DataRow dr)
        {
            return new City(dr["City"].ToString(),
                            dr["State"].ToString(),
                            int.Parse(dr["Population"].ToString()),
                            int.Parse(dr["MedianHouseholdIncome"].ToString()),
                            decimal.Parse(dr["PercentOwners"].ToString()),
                            decimal.Parse(dr["PercentRenters"].ToString()),
                            int.Parse(dr["MedianHomeValue"].ToString()),
                            int.Parse(dr["MedianMaleAge"].ToString()),
                            int.Parse(dr["MedianFemaleAge"].ToString()),
                            decimal.Parse(dr["UnemploymentRate"].ToString()),
                            decimal.Parse(dr["CrimeIndex"].ToString()));
        }

        public static ArrayList CreateListFromDataSet(DataSet ds)
        {
            ArrayList cities = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cities.Add(new City(dr["City"].ToString(),
                            dr["State"].ToString(),
                            int.Parse(dr["Population"].ToString()),
                            int.Parse(dr["MedianHouseholdIncome"].ToString()),
                            decimal.Parse(dr["PercentOwners"].ToString()),
                            decimal.Parse(dr["PercentRenters"].ToString()),
                            int.Parse(dr["MedianHomeValue"].ToString()),
                            int.Parse(dr["MedianMaleAge"].ToString()),
                            int.Parse(dr["MedianFemaleAge"].ToString()),
                            decimal.Parse(dr["UnemploymentRate"].ToString()),
                            decimal.Parse(dr["CrimeIndex"].ToString())));
            }

            return cities;
        }

        // Convert CityList object to DataTable
        public static DataTable GetCityDataTable(ArrayList cities)
        {
            DataTable dt = new DataTable();
            DataRow dr;

            // Create columns
            dt.Columns.Add("City");
            dt.Columns.Add("State");
            dt.Columns.Add("Population");
            dt.Columns.Add("MedianHouseholdIncome");
            dt.Columns.Add("PercentOwners");
            dt.Columns.Add("PercentRenters");
            dt.Columns.Add("MedianHomeValue");
            dt.Columns.Add("MedianMaleAge");
            dt.Columns.Add("MedianFemaleAge");
            dt.Columns.Add("UnemploymentRate");
            dt.Columns.Add("CrimeIndex");

            // Add cities
            foreach (City c in cities)
            {
                dr = dt.NewRow();
                dr[0] = c.CityName;
                dr[1] = c.State;
                dr[2] = c.Population;
                dr[3] = c.MedianHouseholdIncome;
                dr[4] = c.PercentOwners;
                dr[5] = c.PercentRenters;
                dr[6] = c.MedianHomeValue;
                dr[7] = c.MedianMaleAge;
                dr[8] = c.MedianFemaleAge;
                dr[9] = c.UnemploymentRate;
                dr[10] = c.CrimeIndex;

                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
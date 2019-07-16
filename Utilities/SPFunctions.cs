using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using System.Diagnostics;
/// <summary>
/// Author: Cody Hunsberger
/// 
/// Sets up and calls stored procedures for the most part
/// </summary>
namespace Utilities
{
    public class SPFunctions
    {
        SqlCommand cmd = new SqlCommand();

        private StoredProcedure sp;
        public SPFunctions()
        { sp = new StoredProcedure(); }

        public void AddCity(string city, string state, int population, int medianHouseholdIncome, decimal percentOwners, decimal percentRenters, int medianHomeValue, int medianMaleAge, int medianFemaleAge, decimal unemploymentRate, decimal crimeIndex)
        {
            sp.setUpCommand("InsertCity");
            sp.setUpParameters(new SqlParameter[]
            {
                sp.param("@City", city, SqlDbType.VarChar, 50),
                sp.param("@State", state, SqlDbType.VarChar, 50),
                sp.param("@Population", population, SqlDbType.Int),
                sp.param("@MedianHouseholdIncome", medianHouseholdIncome, SqlDbType.Int),
                sp.param("@PercentOwners", percentOwners, SqlDbType.Decimal, 9),
                sp.param("@PercentRenters", percentRenters, SqlDbType.Decimal, 9),
                sp.param("@MedianHomeValue", medianHomeValue, SqlDbType.Int),
                sp.param("@MedianMaleAge", medianMaleAge, SqlDbType.Int),
                sp.param("@MedianFemaleAge",medianFemaleAge, SqlDbType.Int),
                sp.param("@UnemploymentRate", unemploymentRate, SqlDbType.Decimal, 9),
                sp.param("@CrimeIndex", crimeIndex, SqlDbType.Decimal, 9)
            });
            sp.doUpdate();
        }

        public DataSet GetAllCityData()
        {
            sp.setUpCommand("GetAllCityData");
            return sp.getData();
        }

        public DataSet GetCitiesByState(string state)
        {
            sp.setUpCommand("GetCitiesByState");
            sp.setUpParameter(new SqlParameter("@State", state));
            return sp.getData();
        }

        public DataSet GetStates()
        {
            sp.setUpCommand("GetStates");
            return sp.getData();
        }

        public DataSet GetDataForCity(string city, string state)
        {
            sp.setUpCommand("GetDataForCity");
            sp.setUpParameters(new SqlParameter[]
            {
                sp.param("@City", city, SqlDbType.VarChar, 50),
                sp.param("@State", state, SqlDbType.VarChar, 50),
            });
            return sp.getData();
        }

        public DataSet GetCityStatePairs()
        {
            sp.setUpCommand("GetCityStatePairs");
            return sp.getData();
        }

        // Search methods
        public DataSet Search_PopulationLessThan(int value)
        {
            sp.setUpCommand("Search_PopulationLessThan");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }

        public DataSet Search_PopulationEquals(int value)
        {
            sp.setUpCommand("Search_PopulationEquals");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_PopulationGreaterThan(int value)
        {
            sp.setUpCommand("Search_PopulationGreaterThan");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianHouseholdIncomeLessThan(int value)
        {
            sp.setUpCommand("Search_MedianHouseholdIncomeLessThan");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianHouseholdIncomeEquals(int value)
        {
            sp.setUpCommand("Search_MedianHouseholdIncomeEquals");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianHouseholdIncomeGreaterThan(int value)
        {
            sp.setUpCommand("Search_MedianHouseholdIncomeGreaterThan");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianHomeValueLessThan(int value)
        {
            sp.setUpCommand("Search_MedianHomeValueLessThan");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianHomeValueEquals(int value)
        {
            sp.setUpCommand("Search_MedianHomeValueEquals");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianHomeValueGreaterThan(int value)
        {
            sp.setUpCommand("Search_MedianHomeValueGreaterThan");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianMaleAgeLessThan(int value)
        {
            sp.setUpCommand("Search_MedianMaleAgeLessThan");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianMaleAgeEquals(int value)
        {
            sp.setUpCommand("Search_MedianMaleAgeEquals");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public DataSet Search_MedianMaleAgeGreaterThan(int value)
        {
            sp.setUpCommand("Search_MedianMaleAgeGreaterThan");
            sp.setUpParameter(new SqlParameter("@Value", value));
            return sp.getData();
        }
        public void UpdateCity(string city, string state, int population, int medianHouseholdIncome, decimal percentOwners, decimal percentRenters, int medianHomeValue, int medianMaleAge, int medianFemaleAge, decimal unemploymentRate, decimal crimeIndex)
        {
            sp.setUpCommand("UpdateCity");
            sp.setUpParameters(new SqlParameter[]
            {
                sp.param("@City", city, SqlDbType.VarChar, 50),
                sp.param("@State", state, SqlDbType.VarChar, 50),
                sp.param("@Population", population, SqlDbType.Int),
                sp.param("@MedianHouseholdIncome", medianHouseholdIncome, SqlDbType.Int),
                sp.param("@PercentOwners", percentOwners, SqlDbType.Decimal, 9),
                sp.param("@PercentRenters", percentRenters, SqlDbType.Decimal, 9),
                sp.param("@MedianHomeValue", medianHomeValue, SqlDbType.Int),
                sp.param("@MedianMaleAge", medianMaleAge, SqlDbType.Int),
                sp.param("@MedianFemaleAge",medianFemaleAge, SqlDbType.Int),
                sp.param("@UnemploymentRate", unemploymentRate, SqlDbType.Decimal, 9),
                sp.param("@CrimeIndex", crimeIndex, SqlDbType.Decimal, 9)
            });
            sp.doUpdate();

        }
    }
}

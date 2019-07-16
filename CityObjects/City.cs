using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityObjects
{
    public class City
    {
        public string CityName
        { get; set; }
        public string State
        { get; set; }
        public int Population
        { get; set; }
        public int MedianHouseholdIncome
        { get; set; }
        public decimal PercentOwners
        { get; set; }
        public decimal PercentRenters
        { get; set; }
        public int MedianHomeValue
        { get; set; }
        public int MedianMaleAge
        { get; set; }
        public int MedianFemaleAge
        { get; set; }
        public decimal UnemploymentRate
        { get; set; }
        public decimal CrimeIndex
        {
            get; set;
        }

        public City()
        {
            this.CityName = "";
            this.State = "";
            this.Population = 0;
            this.MedianHouseholdIncome = 0;
            this.PercentOwners = 0;
            this.PercentRenters = 0;
            this.MedianHomeValue = 0;
            this.MedianMaleAge = 0;
            this.MedianFemaleAge = 0;
            this.UnemploymentRate = 0;
            this.CrimeIndex = 0;
        }

        public City(string city, string state, int population, int medianHouseholdIncome, decimal percentOwners, decimal percentRenters, int medianHomeValue, int medianMaleAge, int medianFemaleAge, decimal unemploymentRate, decimal crimeIndex)
        {
            this.CityName = city;
            this.State = state;
            this.Population = population;
            this.MedianHouseholdIncome = medianHouseholdIncome;
            this.PercentOwners = percentOwners;
            this.PercentRenters = percentRenters;
            this.MedianHomeValue = medianHomeValue;
            this.MedianMaleAge = medianMaleAge;
            this.MedianFemaleAge = medianFemaleAge;
            this.UnemploymentRate = unemploymentRate;
            this.CrimeIndex = crimeIndex;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagingSales.Business.Models
{
    public static class StateArray
    {

        static List<US_State> states;

        static StateArray()
        {
            states = new List<US_State>(50)
            {
                new US_State("AL", "Alabama"),
                new US_State("AK", "Alaska"),
                new US_State("AZ", "Arizona"),
                new US_State("AR", "Arkansas"),
                new US_State("CA", "California"),
                new US_State("CO", "Colorado"),
                new US_State("CT", "Connecticut"),
                new US_State("DE", "Delaware"),
                new US_State("DC", "District Of Columbia"),
                new US_State("FL", "Florida"),
                new US_State("GA", "Georgia"),
                new US_State("HI", "Hawaii"),
                new US_State("ID", "Idaho"),
                new US_State("IL", "Illinois"),
                new US_State("IN", "Indiana"),
                new US_State("IA", "Iowa"),
                new US_State("KS", "Kansas"),
                new US_State("KY", "Kentucky"),
                new US_State("LA", "Louisiana"),
                new US_State("ME", "Maine"),
                new US_State("MD", "Maryland"),
                new US_State("MA", "Massachusetts"),
                new US_State("MI", "Michigan"),
                new US_State("MN", "Minnesota"),
                new US_State("MS", "Mississippi"),
                new US_State("MO", "Missouri"),
                new US_State("MT", "Montana"),
                new US_State("NE", "Nebraska"),
                new US_State("NV", "Nevada"),
                new US_State("NH", "New Hampshire"),
                new US_State("NJ", "New Jersey"),
                new US_State("NM", "New Mexico"),
                new US_State("NY", "New York"),
                new US_State("NC", "North Carolina"),
                new US_State("ND", "North Dakota"),
                new US_State("OH", "Ohio"),
                new US_State("OK", "Oklahoma"),
                new US_State("OR", "Oregon"),
                new US_State("PA", "Pennsylvania"),
                new US_State("RI", "Rhode Island"),
                new US_State("SC", "South Carolina"),
                new US_State("SD", "South Dakota"),
                new US_State("TN", "Tennessee"),
                new US_State("TX", "Texas"),
                new US_State("UT", "Utah"),
                new US_State("VT", "Vermont"),
                new US_State("VA", "Virginia"),
                new US_State("WA", "Washington"),
                new US_State("WV", "West Virginia"),
                new US_State("WI", "Wisconsin"),
                new US_State("WY", "Wyoming")
            };
        }

        public static List<string> Abbreviations()
        {
            return states.Select(s => s.Abbreviation).ToList();
        }

        public static List<string> Names()
        {
            return states.Select(s => s.Name).ToList();
        }

        public static string GetName(string abbreviation)
        {
            return states.Where(s => s.Abbreviation.Equals(abbreviation, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Name).FirstOrDefault();
        }

        public static string GetAbbreviation(string name)
        {
            return states.Where(s => s.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Abbreviation).FirstOrDefault();
        }
    }

    class US_State
    {

        public US_State()
        {
            Name = null;
            Abbreviation = null;
        }

        public US_State(string ab, string name)
        {
            Name = name;
            Abbreviation = ab;
        }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Abbreviation, Name);
        }

    }
}


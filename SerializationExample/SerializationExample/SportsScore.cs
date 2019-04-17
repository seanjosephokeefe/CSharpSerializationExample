using System;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationExample
{
    [Serializable]
    //[XmlRoot("Scores")]
    //[System.Xml.Serialization.XmlRootAttribute("scores", IsNullable = false)]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "",IsNullable = false)]
    public class SportsScore
    {
        public String SId { get; set; }
        public int Id { get; set; }

        public String EventDate { get; set; }

        public String VisitorTeam { get; set; }

        public int VisitorScore { get; set; }

        public String HomeTeam { get; set; }

        public int HomeScore { get; set; }

        //Parameter Less constructor needed for XML Serialization Only!!!
        public SportsScore() { }

        public SportsScore(String sid, int id, String eDate, String vTeam, int vScore, String hTeam, int hScore)
        {
            SId = sid;
            Id = id;
            EventDate = eDate;
            VisitorTeam = vTeam;
            VisitorScore = vScore;
            HomeTeam = hTeam;
            HomeScore = hScore;
        }

        public String DisplayEntry()
        {
            return ("*******************************************\nId: " + SId + "\nVisitors: " + VisitorTeam + ", Score: " + VisitorScore + "\n" + "\nHome: " + HomeTeam + ", Score: " + HomeScore + "\n*******************************************");
        }
    }
}

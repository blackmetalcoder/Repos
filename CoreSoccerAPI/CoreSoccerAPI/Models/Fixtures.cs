using System;
using System.Collections.Generic;

namespace CoreSoccerAPI.Models
{
    public partial class Fixtures
    {
        public int Idnr { get; set; }
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public string League { get; set; }
        public string Round { get; set; }
        public string HomeTeam { get; set; }
        public int? HomeTeamId { get; set; }
        public string AwayTeam { get; set; }
        public string AwayTeamId { get; set; }
        public string Location { get; set; }
        public int? HomeGoals { get; set; }
        public int? AwayGoals { get; set; }
        public string Time { get; set; }
        public string HomeTeamYellowCardDetails { get; set; }
        public string AwayTeamYellowCardDetails { get; set; }
        public string HomeTeamRedCardDetails { get; set; }
        public string AwayTeamRedCardDetails { get; set; }
        public string HomeLineupGoalkeeper { get; set; }
        public string AwayLineupGoalkeeper { get; set; }
        public string HomeLineupDefense { get; set; }
        public string AwayLineupDefense { get; set; }
        public string HomeLineupMidfield { get; set; }
        public string AwayLineupMidfield { get; set; }
        public string HomeLineupForward { get; set; }
        public string AwayLineupForward { get; set; }
        public string HomeLineupSubstitutes { get; set; }
        public string AwayLineupSubstitutes { get; set; }
        public string HomeGoalDetails { get; set; }
        public string AwayGoalDetails { get; set; }
        public string Referee { get; set; }
    }
}

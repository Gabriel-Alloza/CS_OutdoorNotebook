namespace OutdoorNotebook.Core
{
	public class OutdoorEvent
	{
		public string name{ get; set; } = string.Empty;
		public DateTime date{ get; set; }
		public string place{ get; set; } = string.Empty;
		public int maxNbAtendees{ get; set; } = 0;
		public int currentNbAttendees{ get; set; } = 0;
		public string? description{ get; set; }
		
		
		public OutdoorEvent(
                    string name,
                    DateTime date,
                    string place,
                    int maxNbAtendees,
                    int currentNbAttendees,
                    string? description = null)
                {
                    this.name = name;
                    this.date = date;
                    this.place = place;
                    this.maxNbAtendees = maxNbAtendees;
                    this.currentNbAttendees = currentNbAttendees;
                    this.description = description;
                }

        public int GetRemainingPlaces()
        {
            return maxNbAtendees - currentNbAttendees;
        }

        public bool IsFull()
        {
            if(GetRemainingPlaces() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}
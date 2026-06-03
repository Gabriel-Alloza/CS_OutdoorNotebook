namespace OutdoorNotebook.Core
{
    public class EventService
    {
        public List<OutdoorEvent> events{get; set;}

        public EventService(List<OutdoorEvent> events)
        {
            this.events = events;
        }

        public List<OutdoorEvent> FutureOutings()
        {
            List<OutdoorEvent> returnList = events.Where(e => e.date >= DateTime.Now).ToList();
            return returnList;
        }

        public List<OutdoorEvent> CompleteEvents()
        {
            List<OutdoorEvent> returnList = events.Where(e => e.IsFull() == true).ToList();
            return returnList;
        }

        public List<OutdoorEvent> AvailableEvents()
        {
            List<OutdoorEvent> futureList = FutureOutings().ToList();
            List<OutdoorEvent> returnList = futureList.Where(e => e.IsFull() == false).ToList();
            return returnList;
        }

        public List<OutdoorEvent>  IsOutingValid()
        {
             List<OutdoorEvent> returnList = [];
            foreach(var e in events)
            {
                if(e.name == "" || e.place == "" || e.maxNbAtendees <= 0 || e.currentNbAttendees < 0 || e.currentNbAttendees > e.maxNbAtendees )
                {
                    returnList.Add(e);
                }

            }
            return returnList;

        }




    }
}
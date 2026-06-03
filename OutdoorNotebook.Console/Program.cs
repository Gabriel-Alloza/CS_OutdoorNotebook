using System;
using OutdoorNotebook.Core;

class Program
{
    static void Main()
    {
        OutdoorEvent oPassee = new OutdoorEvent("Sortie au ski", new DateTime(1788, 7, 5), "Annecy",  50, 2, "ceci est une description");
        OutdoorEvent oFuture = new OutdoorEvent("Sortie au ski du futur", new DateTime(2788, 7, 5), "Annecy",  50, 2, "ceci est une description");
        OutdoorEvent oFuture2 = new OutdoorEvent("Sortie a la montagne du futur", new DateTime(2788, 7, 6), "Annecy",  50, 2);
        OutdoorEvent oComplete = new OutdoorEvent("Sortie a la mer", new DateTime(2018, 7, 5), "Annecy",  50, 50, "ceci est une description");
        OutdoorEvent oDispo = new OutdoorEvent("Sortie", new DateTime(2018, 7, 5), "Annecy",  50, 0, "ceci est une description");

        List<OutdoorEvent> events = new List<OutdoorEvent>();

        events.Add(oPassee);
        events.Add(oFuture);
        events.Add(oFuture2);
        events.Add(oComplete);
        events.Add(oDispo);

        EventStorageService eventStorageService = new EventStorageService();

        eventStorageService.ToJson(events, "/home/user/OutdoorNotebook/data/outings.json");

         List<OutdoorEvent> loadedEvents = eventStorageService.FromJson("/home/user/OutdoorNotebook/data/outings.json");

         EventService eventService = new EventService(loadedEvents);


        foreach (var e in loadedEvents)
        {
                    Console.WriteLine(e.name);
                    Console.WriteLine(e.place);
                    Console.WriteLine(e.date);
                    Console.WriteLine(e.GetRemainingPlaces());
                    Console.WriteLine("places encore disponibles.");
                    if(e.IsFull())
                    {
                        Console.WriteLine("Plus de places libres");
                    }
                    else
                    {
                        Console.WriteLine("il reste des places libres");
                    }
                    if(e.description != null)
                    {
                        Console.WriteLine(e.description);
                    }
                    Console.WriteLine("");
        }

        //var notPassedYet = events.Where(e => e.date >= DateTime.Now);
        var notPassedYet = eventService.FutureOutings();

        foreach(var e in notPassedYet)
        {
            Console.WriteLine(e.name);
        }
        Console.WriteLine("");
        //var onlyIsFull = events.Where(e => e.IsFull() == true);


        var onlyIsFull = eventService.CompleteEvents();
        foreach(var e in onlyIsFull)
        {
            Console.WriteLine(e.name);
        }
        Console.WriteLine("");

        var onlyDispo = eventService.AvailableEvents();

        foreach(var e in onlyDispo)
        {
            Console.WriteLine(e.name);
        }


    }
}
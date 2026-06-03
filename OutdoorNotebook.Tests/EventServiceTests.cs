namespace OutdoorNotebook.Core
{
    using Xunit;


    public class EventServiceTests
    {
        [Fact]
        public void PastOutingsNotInFutureOutings()
        {
            // Arrange
            OutdoorEvent montagne = new OutdoorEvent("Sortie à la montagne", new DateTime(1788, 7, 5), "Annecy",  50, 2, "ceci est une description");
            OutdoorEvent mer = new OutdoorEvent("Sortie à la mer", new DateTime(2788, 7, 5), "Annecy",  50, 2, "ceci est une description");
            OutdoorEvent randonee = new OutdoorEvent("Randonnée", new DateTime(2788, 7, 5), "Annecy",  50, 2, "ceci est une description");
            List<OutdoorEvent> events = new List<OutdoorEvent>();
            events.Add(montagne);
            events.Add(mer);
            events.Add(randonee);
            EventService eventService = new EventService(events);

            // Act
            var notPassedYet = eventService.FutureOutings();


            // Assert
            Assert.DoesNotContain(montagne, notPassedYet);
        }


        [Fact]
                public void FullOutingsInFullOutings()
                {
                    // Arrange
                    OutdoorEvent montagne = new OutdoorEvent("Sortie à la montagne", new DateTime(1788, 7, 5), "Annecy",  50, 2, "ceci est une description");
                    OutdoorEvent mer = new OutdoorEvent("Sortie à la mer", new DateTime(2788, 7, 5), "Annecy",  50, 50, "ceci est une description");
                    OutdoorEvent randonee = new OutdoorEvent("Randonnée", new DateTime(2788, 7, 5), "Annecy",  50, 50, "ceci est une description");
                    List<OutdoorEvent> events = new List<OutdoorEvent>();
                    events.Add(montagne);
                    events.Add(mer);
                    events.Add(randonee);
                    EventService eventService = new EventService(events);

                    // Act
                    var completeEvents = eventService.CompleteEvents();


                    // Assert
                    Assert.Contains(randonee, completeEvents);
                }


        [Fact]
                        public void RemainingPlacesMustBeInRemainingPlaces()
                        {
                            // Arrange
                            OutdoorEvent montagne = new OutdoorEvent("Sortie à la montagne", new DateTime(1788, 7, 5), "Annecy",  50, 2, "ceci est une description");
                            OutdoorEvent mer = new OutdoorEvent("Sortie à la mer", new DateTime(2788, 7, 5), "Annecy",  50, 1, "ceci est une description");
                            OutdoorEvent randonee = new OutdoorEvent("Randonnée", new DateTime(2788, 7, 5), "Annecy",  50, 50, "ceci est une description");
                            List<OutdoorEvent> events = new List<OutdoorEvent>();
                            events.Add(montagne);
                            events.Add(mer);
                            events.Add(randonee);
                            EventService eventService = new EventService(events);

                            // Act
                            var availableEvents = eventService.AvailableEvents();


                            // Assert
                            Assert.Contains(mer, availableEvents);
                        }

[Fact]
        public void EmptyPlaceIsInvalid()
        {
            // Arrange
            OutdoorEvent montagne = new OutdoorEvent("Sortie à la montagne", new DateTime(1788, 7, 5), "",  50, 2, "ceci est une description");
            OutdoorEvent mer = new OutdoorEvent("Sortie à la mer", new DateTime(2788, 7, 5), "",  50, 2, "ceci est une description");
            OutdoorEvent randonee = new OutdoorEvent("Randonnée", new DateTime(2788, 7, 5), "Annecy",  50, 2, "ceci est une description");
            List<OutdoorEvent> events = new List<OutdoorEvent>();
            events.Add(montagne);
            events.Add(mer);
            events.Add(randonee);
            EventService eventService = new EventService(events);

            // Act
            var invalidOutings = eventService.IsOutingValid();


            // Assert
            Assert.Contains(mer, invalidOutings);
            Assert.Contains(montagne, invalidOutings);

        }



[Fact]
        public void MoreAttendeesThanMaxAtendeesIsInvalid()
        {
            // Arrange
            OutdoorEvent montagne = new OutdoorEvent("Sortie à la montagne", new DateTime(1788, 7, 5), "Annecy",  50, 2, "ceci est une description");
            OutdoorEvent mer = new OutdoorEvent("Sortie à la mer", new DateTime(2788, 7, 5), "Grenoble",  50, 78, "ceci est une description");
            OutdoorEvent randonee = new OutdoorEvent("Randonnée", new DateTime(2788, 7, 5), "Annecy",  50, 1284, "ceci est une description");
            List<OutdoorEvent> events = new List<OutdoorEvent>();
            events.Add(montagne);
            events.Add(mer);
            events.Add(randonee);
            EventService eventService = new EventService(events);

            // Act
            var invalidOutings = eventService.IsOutingValid();


            // Assert
            Assert.Contains(mer, invalidOutings);
            Assert.Contains(randonee, invalidOutings);

        }
    }



}
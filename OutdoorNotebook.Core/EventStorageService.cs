namespace OutdoorNotebook.Core
{
    using System.Text.Json;

    public class EventStorageService
    {
            public void ToJson(List<OutdoorEvent> events, string filePath)
            {
                string jsonOutput = JsonSerializer.Serialize(
                events,
                new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }
                );

                File.WriteAllText(filePath, jsonOutput);
                Console.WriteLine("Liste enregistrée dans events.json");
            }

            public List<OutdoorEvent> FromJson(string filePath)
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<OutdoorEvent>>(json);
            }
    }




}
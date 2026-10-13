using System.Text.Json;

public static class Persistencia
{
    private const string Archivo = "tareas.json";

    public static void Guardar(List<TaskItem> tareas)
    {
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(tareas, opciones);
        File.WriteAllText(Archivo, json);
    }
        public static List<TaskItem> Cargar()
    {
        if (!File.Exists(Archivo))
        {
            return new List<TaskItem>();
        }

        string json = File.ReadAllText(Archivo);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<TaskItem>();
        }

        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }
}
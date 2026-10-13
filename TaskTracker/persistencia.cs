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
}
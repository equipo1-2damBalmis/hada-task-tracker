using TaskTracker;

List<TaskItem> tareas = Persistencia.Cargar();
Console.WriteLine($"Tareas cargadas: {tareas.Count}");

tareas.Add(new TaskItem("Probar JSON", "Tu nombre", "Comprobar que se guarda y se carga"));

Persistencia.Guardar(tareas);
Console.WriteLine("Tareas guardadas en tareas.json");

foreach (TaskItem t in Persistencia.Cargar())
{
    Console.WriteLine(t);
}
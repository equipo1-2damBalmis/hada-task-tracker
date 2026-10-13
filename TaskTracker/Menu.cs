namespace TaskTracker
{
public partial class Program
 {
    public static void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("=== Menu de Tareas ===");
            Console.WriteLine("1. Añadir tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Buscar tareas por fechas");
            Console.WriteLine("4. Guardar/cargar tareas en fichero tareas.json");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            opcion switch
            {
                1 => AñadirTarea(),
                2 => ListarTareas(),
                3 => MarcarTareaCompletada(),
                4 => GuardarCargarTareas(),
                5 => Console.WriteLine("Saliendo..."),
                 => Console.WriteLine("Opción inválida. Intente nuevamente.")
            };
        } while (opcion != 5);



    }

    public List<TaskItem> AñadirTarea()
    {
        List<TaskItem> ListaTareas = new List<TaskItem>();



        Console.Write("Introduce el título de la tarea: ");
        string titulo = Console.ReadLine();

        Console.Write("Introduce la descripción de la tarea: ");
        string descripcion = Console.ReadLine();



        Console.WriteLine("Introduce el usuario responsable de la tarea: ");
        string usuarioResponsable = Console.ReadLine();

        TaskItem nuevaTarea = new TaskItem(titulo, descripcion, usuarioResponsable);

        ListaTareas.Add(nuevaTarea);

        Console.WriteLine("Tarea añadida exitosamente.");
        return ListaTareas;
    }
}
}
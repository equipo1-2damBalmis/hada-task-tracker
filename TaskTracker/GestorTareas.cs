using System.Text.Json;

namespace TaskTracker
{
    public class GestorTareas
    {
        private const string Archivo = "tareas.json";
        private List<TaskItem> ListaTareas = new List<TaskItem>();

        //Añadir tareas 

        //Listar

        //Marcar como completada
        public void MarcarTareaCompletada()
        {
            if (ListaTareas.Count == 0)
            {
                Console.WriteLine("No hay tareas para marcar como completadas.");
                return;
            }

            ListarTareas();

            Console.Write("\nIntroduce el ID de la tarea que has completado: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Debes introducir un ID numérico.");
                return;
            }

            TaskItem tareaEncontrada = null;

            foreach (TaskItem tarea in ListaTareas)
            {
                if (tarea.Id == id)
                {
                    tareaEncontrada = tarea;
                    break;
                }
            }

            if (tareaEncontrada == null)
            {
                Console.WriteLine("No se ha encontrado ninguna tarea con ese ID.");
                return;
            }

            if (tareaEncontrada.Completado)
            {
                Console.WriteLine("Esta tarea ya estaba completada.");
                return;
            }

            tareaEncontrada.Completado = true;

            Console.WriteLine("Tarea marcada como completada correctamente.");
        }

        //Buscar por fecha
        public void BuscarPorFecha()
        {
            Console.WriteLine("\n--- Buscar tareas por rango de fechas ---");

            Console.Write("Introduce la fecha de inicio (dd/MM/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaInicio))
            {
                Console.WriteLine("Fecha de inicio no válida.");
                return;
            }

            Console.Write("Introduce la fecha de fin (dd/MM/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaFin))
            {
                Console.WriteLine("Fecha de fin no válida.");
                return;
            }

            var tareasFiltradas = Filtra.PorRangoFechas(ListaTareas, fechaInicio, fechaFin);

            Console.WriteLine($"\nTareas encontradas entre {fechaInicio.ToShortDateString()} y {fechaFin.ToShortDateString()}:");
            foreach (var tarea in tareasFiltradas)
            {
                Console.WriteLine($"- [{(tarea.Completado ? "X" : " ")}] {tarea.Titulo} ({tarea.FechaCreacion.ToShortDateString()})");
            }
        }
        //Guardar en JSON
        public void GuardarEnJson()
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(ListaTareas, opciones);
            File.WriteAllText(Archivo, json);
            Console.WriteLine("Tareas guardadas correctamente.");
        }

        // Cargar JSON 
        public void CargarDesdeJson()
        {
            if (!File.Exists(Archivo))
            {
                return;
            }

            string json = File.ReadAllText(Archivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            ListaTareas = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }

    }
}
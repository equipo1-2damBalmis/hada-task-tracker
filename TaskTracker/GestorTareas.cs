namespace TaskTracker
{
    public class GestorTareas
{
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
    //Guardar en JSON
    
}
}
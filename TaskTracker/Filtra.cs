using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskTracker
{
    public static class Filtra
    {

        /// Filtra las tareas que se encuentran dentro de un rango de fechas .

        public static List<TaskItem> PorRangoFechas(IEnumerable<TaskItem> tareas, DateTime fechaInicio, DateTime fechaFin)
        {
            return tareas.Where(t => t.FechaCreacion.Date >= fechaInicio.Date && t.FechaCreacion.Date <= fechaFin.Date).ToList();
        }
    }
}
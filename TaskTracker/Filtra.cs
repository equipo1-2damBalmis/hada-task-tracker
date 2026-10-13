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


        /// Filtra las tareas creadas exactamente en una fecha concreta
        public static List<TaskItem> PorFechaConcreta(IEnumerable<TaskItem> tareas, DateTime fecha)
        {
            return tareas.Where(t => t.FechaCreacion.Date == fecha.Date).ToList();
        }

        /// Filtra las tareas creadas a partir de una fecha (hacia adelante).
        
        public static List<TaskItem> DesdeFecha(IEnumerable<TaskItem> tareas, DateTime fecha)
        {
            return tareas.Where(t => t.FechaCreacion.Date >= fecha.Date).ToList();
        }
    }
}
namespace TaskTracker;

public class TaskItem
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public bool Completado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string UsuarioResponsable { get; set; }
    public string Descripcion { get; set; }
    public TaskItem() { }
    
    public TaskItem(string titulo, string usuarioResponsable, string descripcion)
    {
        DateTime fechaCreacion = DateTime.Now;
        
        Id = Math.Abs(fechaCreacion.GetHashCode());
        Titulo = titulo;
        Completado = false;
        FechaCreacion = fechaCreacion;
        UsuarioResponsable = usuarioResponsable;
        Descripcion = descripcion;
    }
    
    public override string ToString()
    {
        string estado = Completado ? "[X]" : "[ ]";
        return $"{Id} {estado} {Titulo} - {UsuarioResponsable}";
    }
}
namespace EXAMEN1P_JUANDAVILA.MODELOS
{
    public class HistoricoEquipos
    {
        public int id  { get; set; }
        public int id_futbolista { get; set; }
        public int id_equipo { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
    }
}

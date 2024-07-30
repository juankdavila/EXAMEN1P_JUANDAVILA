using EXAMEN1P_JUANDAVILA.MODELOS;
using System.Data;
using System.Data.SqlClient;



namespace EXAMEN1P_JUANDAVILA.COMUNES
{
    public class ConexionBD
    {
        public static SqlConnection conexion;

        public static SqlConnection abrirConexion()
        {
            conexion = new SqlConnection("SERVER=Juank-Davila\\LICEO;DATABASE=JUGADORES;Trusted_Connection=true");
            //conexion = new SqlConnection("Server=Juank-Davila\\LICEO;Database=PROYECTO_2;User Id=sa;Password=Representaciones.2024;");
            conexion.Open();
            return conexion;
        }

        public static List<Futbolista> GetFutbolista()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_FUTBOLISTAS";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarFutbolista(dataSet.Tables[0]);
        }

        public static Futbolista GetFutbolistas(int id_futbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_FUTBOLISTA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_FUTBOLISTA", id_futbolista);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarFutbolista(dataSet.Tables[0])[0];
        }


        public static void PostFutbolista(Futbolista objFutbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_INS_FUTBOLISTA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_FUTBOLISTA", objFutbolista.id_futbolista);
            cmd.Parameters.AddWithValue("@PV_NOMBRE", objFutbolista.nombre);
            cmd.Parameters.AddWithValue("@PV_APELLIDOS", objFutbolista.apellidos);
            cmd.Parameters.AddWithValue("@PV_EDAD", objFutbolista.edad);
            cmd.Parameters.AddWithValue("@PV_DIRECCION", objFutbolista.direccion);
            cmd.Parameters.AddWithValue("@PV_MAIL", objFutbolista.mail);
            cmd.Parameters.AddWithValue("@PD_FECHA_NACIMIENTO", objFutbolista.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@PV_ESTADO", objFutbolista.estado);

            cmd.ExecuteNonQuery();
        }

        public static void PutFutbolista(int id_futbolista, Futbolista objFutbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_UPD_FUTBOLISTA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_FUTBOLISTA", id_futbolista);
            cmd.Parameters.AddWithValue("@PV_NOMBRE", objFutbolista.nombre);
            cmd.Parameters.AddWithValue("@PV_APELLIDOS", objFutbolista.apellidos);
            cmd.Parameters.AddWithValue("@PV_EDAD", objFutbolista.edad);
            cmd.Parameters.AddWithValue("@PV_DIRECCION", objFutbolista.direccion);
            cmd.Parameters.AddWithValue("@PV_MAIL", objFutbolista.mail);
            cmd.Parameters.AddWithValue("@PD_FECHA_NACIMIENTO", objFutbolista.fecha_nacimiento);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteFutbolista(int idfutbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_DEL_FUTBOLISTA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_FUTBOLISTA", idfutbolista);
            cmd.ExecuteNonQuery();
        }


        private static List<Futbolista> llenarFutbolista(DataTable dataTable)
        {
            List<Futbolista> lRespuesta = new List<Futbolista>();
            Futbolista objeto = new Futbolista();
            foreach (DataRow dr in dataTable.Rows)
            {
                objeto = new Futbolista();
                objeto.id_futbolista = Convert.ToInt32(dr["ID_FUTBOLISTA"].ToString());
                objeto.nombre = dr["NOMBRE"].ToString();
                objeto.apellidos = dr["APELLIDOS"].ToString();
                objeto.edad = dr["EDAD"].ToString();
                objeto.direccion = dr["DIRECCION"].ToString();
                objeto.mail = dr["MAIL"].ToString();
                objeto.fecha_nacimiento = Convert.ToDateTime(dr["FECHA_NACIMIENTO"].ToString());
                objeto.estado = dr["ESTADO"].ToString();
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }
        public static List<Equipo> GetEquipos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_EQUIPOS";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarEquipos(dataSet.Tables[0]);
        }

        public static Equipo GetEquipo(int id_equipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_EQUIPO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_EQUIPO", id_equipo);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarEquipos(dataSet.Tables[0])[0];
        }

        public static void PostEquipo(Equipo objEquipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_INS_EQUIPOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_EQUIPO", objEquipo.id_equipo);
            cmd.Parameters.AddWithValue("@PV_NOMBRE_EQUIPO", objEquipo.nombre_equipo);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objEquipo.descripcion);
            cmd.Parameters.AddWithValue("@PV_UBICACION", objEquipo.ubicacion);
            cmd.Parameters.AddWithValue("@PV_OBJETIVO", objEquipo.objetivo);
            cmd.Parameters.AddWithValue("@PV_CONTACTO", objEquipo.contacto);
            cmd.Parameters.AddWithValue("@PV_ESTADO", objEquipo.estado);

            cmd.ExecuteNonQuery();
        }

        public static void PutEquipo(int id_equipo, Equipo objEquipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_UPD_EQUIPOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_EQUIPO", id_equipo);
            cmd.Parameters.AddWithValue("@PV_NOMBRE_EQUIPO", objEquipo.nombre_equipo);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objEquipo.descripcion);
            cmd.Parameters.AddWithValue("@PV_UBICACION", objEquipo.ubicacion);
            cmd.Parameters.AddWithValue("@PV_OBJETIVO", objEquipo.objetivo);
            cmd.Parameters.AddWithValue("@PV_CONTACTO", objEquipo.contacto);
            cmd.Parameters.AddWithValue("@PV_ESTADO", objEquipo.estado);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteEquipo(int id_equipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_DEL_EQUIPOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_EQUIPO", id_equipo);
            
            cmd.ExecuteNonQuery();
        }

        private static List<Equipo> llenarEquipos(DataTable dataTable)
        {
            List<Equipo> lRespuesta = new List<Equipo>();
            Equipo objeto = new Equipo();
            foreach (DataRow dr in dataTable.Rows)
            {
                objeto = new Equipo();
                objeto.id_equipo = Convert.ToInt32(dr["ID_EQUIPO"].ToString());
                objeto.nombre_equipo = dr["NOMBRE_EQUIPO"].ToString();
                objeto.descripcion = dr["DESCRIPCION"].ToString();
                objeto.ubicacion = dr["UBICACION"].ToString();
                objeto.objetivo = dr["OBJETIVO"].ToString();
                objeto.estado = dr["ESTADO"].ToString();
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }

       
        public static List<HistoricoEquipos> GetHistorico_Equipos(int id_futbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_HISTORICO_EQUIPOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_FUTBOLISTA", id_futbolista);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarHistorico_Equipos(dataSet.Tables[0]);
        }



        private static List<HistoricoEquipos> llenarHistorico_Equipos(DataTable dataTable)
        {
            List<HistoricoEquipos> lRespuesta = new List<HistoricoEquipos>();
            HistoricoEquipos objeto = new HistoricoEquipos();
            foreach (DataRow dr in dataTable.Rows)
            {

                objeto = new HistoricoEquipos();
                objeto.nombrefutbolista = dr["NOMBREFUTBOLISTA"].ToString();
                objeto.apellidosfutbolista = dr["APELLIDOSFUTBOLISTA"].ToString();
                objeto.nombre_equipo = dr["NOMBRE_EQUIPO"].ToString();
                objeto.fecha_inicio = Convert.ToDateTime(dr["FECHA_INICIO"].ToString());
                objeto.fecha_fin = Convert.ToDateTime(dr["FECHA_FIN"].ToString());
             
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }


    }
    
}

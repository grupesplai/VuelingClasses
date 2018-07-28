using Student.Common.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAcces.Dao
{
    public class RepositoryStudent : IRepository
    {
        private readonly ILogger log;
        private readonly string connectionString;

        #region Constructores
        public RepositoryStudent() { }

        public RepositoryStudent(ILogger log)
        {
            this.log = log;
            connectionString = "Data Source=.;Initial Catalog=VuelingApiD;Integrated Security=true;";
        }
        #endregion


        public int AddAlumno(Alumno alumno)
        {
            try
            {
                var sql = "INSERT INTO dbo.Alumnos (Guid, Nombre, Apellidos, Dni, Registro, Nacimiento, Edad) VALUES (@Guid, @Nombre, @Apellidos, @Dni, @Registro, @Nacimiento, @Edad)";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@Guid", alumno.Guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre.ToString());
                        _cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos.ToString());
                        _cmd.Parameters.AddWithValue("@Dni", alumno.Dni.ToString());
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro.ToString());
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacimiento.ToString());
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad.ToString());

                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        _cmd.CommandText = "SELECT @@IDENTITY";

                        // Obtener el ultimo identificador insertado.
                        return Convert.ToInt32(_cmd.ExecuteScalar());

                        // var id = Convert.ToInt32(_cmd.ExecuteScalar());
                        // return SelectById(id);
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }


        public Alumno GetOneR(int id)
        {
            try
            {
                var sql = "SELECT * FROM dbo.Alumnos WHERE Id = @Id";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        Alumno alumno = new Alumno();
                        _conn.Open();
                        _cmd.Parameters.AddWithValue("@Id",id);

                        using (SqlDataReader oReader = _cmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                alumno.Id = Convert.ToInt32(oReader["Id"]);
                                alumno.Guid = new Guid(oReader["Guid"].ToString());
                                alumno.Nombre = oReader["Nombre"].ToString();
                                alumno.Apellidos = oReader["Apellidos"].ToString();
                                alumno.Dni = oReader["Dni"].ToString();
                                alumno.Edad = Convert.ToInt32(oReader["Edad"]);
                                alumno.Nacimiento = Convert.ToDateTime(oReader["Nacimiento"]);
                                alumno.Registro = Convert.ToDateTime(oReader["Registro"]);
                            }
                            _conn.Close();
                            return alumno;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        public bool DeleteOneR(int id)
        {
            try
            {
                var sql = "DELETE FROM dbo.Alumnos WHERE Id = @Id";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();
                        _cmd.Parameters.AddWithValue("@Id", id);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();
                        _conn.Close();
                    }
                    return true;
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        public IEnumerable<Alumno> GetAllR()
        {
            try
            {
                var sql = "SELECT Id, Guid, Dni, Nombre, Apellidos, Edad, Nacimiento, Registro FROM dbo.Alumnos";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        IEnumerable<Alumno> alumnoList = null;
                        _conn.Open();

                        using (SqlDataReader oReader = _cmd.ExecuteReader())
                        {
                            if (oReader.HasRows)
                            { 
                            while (oReader.Read())
                            {
                                alumnoList = alumnoList.Concat(
                                    new[] { new Alumno(
                                        Convert.ToInt32(oReader.GetValue(0)),
                                        new Guid(oReader.GetValue(1).ToString()),
                                        oReader.GetValue(2).ToString(),
                                        oReader.GetValue(3).ToString(),
                                        oReader.GetValue(4).ToString(),
                                        Convert.ToInt32(oReader.GetValue(5)),
                                        Convert.ToDateTime(oReader.GetValue(6)),
                                        Convert.ToDateTime(oReader.GetValue(7))
                                        )
                                   });
                            }
                        }
                            _conn.Close();
                            return alumnoList.AsEnumerable();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
    }
}

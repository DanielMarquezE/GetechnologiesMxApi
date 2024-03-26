using Apí.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Apí.Controllers
{
    [ApiController]
    [Route("Usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration config;
        public UsuariosController(IConfiguration configuration)
        {
            config = configuration;
        }

        [HttpGet]
        [Route("valida")]
        public bool validaUsurio(string correo, string contra)
        {        
            try
            {
                string strconexion = config.GetConnectionString("conexion");
                using (SqlConnection conexion = new SqlConnection(strconexion))
                {
                    string query = "Select * from usuarios where correo='"+correo+"' and contra='"+contra+"'";
                    SqlCommand cmd = new SqlCommand(query,conexion);
                    conexion.Open();
                    int opcion=Convert.ToInt32(cmd.ExecuteScalar());
                    if (opcion!=0)
                    {
                        conexion.Close();
                        return true;
                    }
                    else
                    {
                        conexion.Close();
                        return false;
                    }
                }

            }catch(Exception ex)
            {
                return false;
            }
        }


        [HttpPost]
        [Route("creaUsuario")]
        public Usuario createUsuario(Usuario usuario)
        {
            try
            {

                string strconexion = config.GetConnectionString("conexion");
                using (SqlConnection conexion = new SqlConnection(strconexion))
                {
                    string query = "insert into dbo.usuarios (correo,contra) values ('"+usuario.correo+"','"+usuario.contra+"')";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    return usuario;
                    
                }

            }
            catch (Exception ex)
            {
                return usuario=new Usuario();
            }
        }

    }
}

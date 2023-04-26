using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace TpWinform_Catalogo
{
    internal class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            //OBJETO CONECTAR CONECTAR
            SqlConnection conexion = new SqlConnection();
            //OBJETO COMANDO PARA REALIZAR ACCIONES
            SqlCommand comando = new SqlCommand();
            //OBJETO  RESULTADO, SET DE DATOS LECTOR
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "";

                comando.Connection = conexion;
                conexion.Open();

                lector=comando.ExecuteReader();

                while(lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.imagen =
                    aux.codigoArticulo =
                    aux.descripcion =
                    aux.precio =
                    aux.nombre =
                    aux.Marca.marca =
                    aux.Categoria.categoria =

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
               
        }
    }
}

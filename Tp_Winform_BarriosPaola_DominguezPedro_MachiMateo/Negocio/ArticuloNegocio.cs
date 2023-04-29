using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using dominio;


namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select a.Codigo as Codigo,a.Nombre as Nombre,a.Descripcion as Descripcion,c.Descripcion AS Categoria,m.Descripcion AS Marca,i.ImagenUrl AS UrlImagen, a.Precio as Precio from ARTICULOS as a inner join IMAGENEs as i on i.IdArticulo = a.Id inner join marcas as m on m.Id = a.IdMarca inner join CATEGORIAS as c on c.Id = a.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    
                    aux.codigoArticulo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    aux.Categoria=new Categoria();
                    aux.Categoria.categoria = (string)datos.Lector["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.marca = (string)datos.Lector["Marca"];

                    aux.urlImagen = (string)datos.Lector["UrlImagen"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
            
               
        }
    }
}

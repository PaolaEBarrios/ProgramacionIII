using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpWinform_Catalogo
{
    public partial class Agregar : Form
    {
        private Articulo articulo = null;
        public Agregar()
        {
            InitializeComponent();
        }

        public Agregar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (articulo == null)
                {
                    articulo = new Articulo();
                }
                articulo.Id = int.Parse(tbId.Text);
                articulo.codigoArticulo = tbCodigo.Text;
                articulo.nombre = tbNombre.Text;
                articulo.descripcion = tbDescripcion.Text;
                articulo.Categoria = new Categoria();
                articulo.Categoria.categoria = tbCategoria.Text;
                articulo.Marca = new Marca();
                articulo.Marca.marca = tbMarca.Text;
                articulo.urlImagen = tbURL.Text;
                articulo.precio = decimal.Parse(nudPrecio.Text);

                if(articulo.Id != 0)
                {
                    negocio.ModificarArticulo(articulo);
                    MessageBox.Show("Modificado!");
                }
                else
                {
                    negocio.AgregarArticulo(articulo);
                    MessageBox.Show("Agregado!");
                }

                Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            if(articulo != null)
            {
                tbId.Text = articulo.Id.ToString();
                tbCodigo.Text = articulo.codigoArticulo;
                tbNombre.Text = articulo.nombre;
                tbDescripcion.Text = articulo.descripcion;
                articulo.Categoria = new Categoria();
                tbCategoria.Text = articulo.Categoria.categoria;
                articulo.Marca = new Marca();
                tbMarca.Text = articulo.Marca.marca;
                tbURL.Text = articulo.urlImagen;
                nudPrecio.Text = articulo.precio.ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using dominio;
using Negocio;


namespace TpWinform_Catalogo
{
    public partial class FrmPrincipal : Form
    {
        private List<Articulo> listaArticulo; 
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            dgvArticulo.DataSource = listaArticulo;
            pbArticulo.Load(listaArticulo[0].urlImagen);
        }

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado=(Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            pbArticulo.Load(seleccionado.urlImagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbArticulo.Load("https://www.bicifan.uy/wp-content/uploads/2016/09/producto-sin-imagen.png");
            }
        }

    }
}

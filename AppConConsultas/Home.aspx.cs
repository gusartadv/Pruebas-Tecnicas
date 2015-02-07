using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AppTalentosYTecnologia
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int cantidadProducto = ConnectionClass.consultarCantidad(Convert.ToInt32(DropDownList2.SelectedValue));

            if (cantidadProducto < Convert.ToInt32(TextBox1.Text))
            {
                MessageBox.Show("No hay sufientes cantidades para cubrir esta venta");
            }

            else
            {
                int nuevaCantidad = cantidadProducto - Convert.ToInt32(TextBox1.Text);


                ConnectionClass.ActualizarProducto(Convert.ToInt32(DropDownList2.SelectedValue), nuevaCantidad);

                int numfil = ConnectionClass.RegistrarCompra(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(TextBox1.Text));

                if(numfil == 1)
                {
                    Label1.Text = "Transaccion realizada correctamente";
                }
                else
                {
                    Label1.Text = "Ocurrio un problema durante la transaccion";
                }

               Response.Redirect("Home.aspx");
                
            }
        }
    }
}
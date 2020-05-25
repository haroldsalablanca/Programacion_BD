using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio;
using capaEntidades;

namespace capaPresentacionWF
{
    public partial class fComentarios : Form
    {
        logicaNegocioComentarios logicaNR = new logicaNegocioComentarios();
        public fComentarios()
        {
            InitializeComponent();
        }
        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Comentarios objetoComentario = new Comentarios();
                    //objetoRecurso.idrecursos = textBoxId.Text;
                    objetoComentario.nombres = textBoxNombres.Text;
                    objetoComentario.correo = textBoxCorreo.Text;
                    objetoComentario.telefono = textBoxTelefono.Text;
                    objetoComentario.mensaje = textBoxMensaje.Text;

                    if (logicaNR.insertarComentarios(objetoComentario) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewComentarios.DataSource = logicaNR.listarComentarios();
                        //textBoxId.Text = "";
                        textBoxNombres.Text = "";
                        textBoxCorreo.Text= "";
                        textBoxTelefono.Text= "";
                        tabControl1.SelectedTab = tabPage2; //Consultar
                    }
                    else { MessageBox.Show("Error al agregar Recurso"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Comentarios objetoComentario = new Comentarios();
                    objetoComentario.idcomentario = Convert.ToInt32(textBoxId.Text);
                    objetoComentario.nombres = textBoxNombres.Text;
                    objetoComentario.correo = textBoxCorreo.Text;
                    objetoComentario.telefono = textBoxTelefono.Text;
                    objetoComentario.mensaje = textBoxMensaje.Text;

                    if (logicaNR.editarComentarios(objetoComentario) > 0)
                    {
                        MessageBox.Show("Actualizado con éxito");
                        dataGridViewComentarios.DataSource = logicaNR.listarComentarios();
                        textBoxNombres.Text = "";
                        textBoxCorreo.Text = "";
                        textBoxTelefono.Text = "";
                        tabControl1.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Comentario");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void fComentarios_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelidcomentario.Visible = false;
            dataGridViewComentarios.DataSource = logicaNR.listarComentarios();
        }

        //Boton Buscar en Detalle de Comentarios
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            List<Comentarios> listaComentarios = logicaNR.buscarComentarios(textBoxBuscar.Text);
            dataGridViewComentarios.DataSource = listaComentarios;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelidcomentario.Visible = true;

            textBoxId.Text = dataGridViewComentarios.CurrentRow.Cells["idcomentario"].Value.ToString();
            textBoxNombres.Text = dataGridViewComentarios.CurrentRow.Cells["nombres"].Value.ToString();
            textBoxCorreo.Text = dataGridViewComentarios.CurrentRow.Cells["correo"].Value.ToString();
            textBoxTelefono.Text = dataGridViewComentarios.CurrentRow.Cells["telefono"].Value.ToString();
            textBoxMensaje.Text = dataGridViewComentarios.CurrentRow.Cells["mensaje"].Value.ToString();
            
            tabControl1.SelectedTab = tabPage1;
            buttonGuardar.Text = "Actualizar";
        }

        private void buttonEliminar_Click_1(object sender, EventArgs e)
        {
            int codigoR = Convert.ToInt32(dataGridViewComentarios.CurrentRow.Cells["idrecursos"].Value.ToString());
            // Condultar si "CodigoR" debe ir en todos los formularios 
            try
            {
                if (logicaNR.eliminarComentarios(codigoR) > 0)
                {
                    MessageBox.Show("Eliminado con éxito!");
                    dataGridViewComentarios.DataSource = logicaNR.listarComentarios();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al elminar Comentario");
            }
        }
    }
}

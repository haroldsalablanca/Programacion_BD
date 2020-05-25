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
    public partial class tabRecursos : Form
    {
        logicaNegocioRecursos logicaNR = new logicaNegocioRecursos();
        public tabRecursos()
        {
            InitializeComponent();
        }      
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Recursos objetoRecurso = new Recursos();
                  //objetoRecurso.idrecursos = textBoxId.Text;
                    objetoRecurso.nombrer = textBoxNombrer.Text;
                    objetoRecurso.codigo = textBoxCodigo.Text;
                    objetoRecurso.descripcion = textBoxDescripcion.Text;

                    if (logicaNR.insertarRecursos(objetoRecurso) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
                      //textBoxId.Text = "";
                        textBoxNombrer.Text = "";
                        textBoxCodigo.Text = "";
                        textBoxDescripcion.Text = "";
                        tabControl1.SelectedTab = tabPage2; //Consultar
                    }
                    else { MessageBox.Show("Error al agregar Recurso"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Recursos objetoRecurso = new Recursos();
                    objetoRecurso.idrecursos = Convert.ToInt32(textBoxId.Text);
                    objetoRecurso.nombrer = textBoxNombrer.Text;
                    objetoRecurso.codigo = textBoxCodigo.Text;
                    objetoRecurso.descripcion = textBoxDescripcion.Text;

                    if (logicaNR.editarRecursos(objetoRecurso) > 0)
                    {
                        MessageBox.Show("Actualizado con éxito");
                        dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
                        textBoxNombrer.Text = "";
                        textBoxCodigo.Text = "";
                        textBoxDescripcion.Text = "";   
                        tabControl1.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Recurso");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        //Ocultar Id cuando se agrega un nuevo Recursos "Se agrega por defecto"
        private void tabControl1_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelId.Visible = false;
            dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
        }

        //Boton Buscar en Detalle de Recursos
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            List<Recursos> listaRecursos = logicaNR.buscarRecursos(textBoxBuscar.Text);
            dataGridViewRecursos.DataSource = listaRecursos;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            textBoxId.Text = dataGridViewRecursos.CurrentRow.Cells["idrecursos"].Value.ToString();
            textBoxNombrer.Text = dataGridViewRecursos.CurrentRow.Cells["nombrer"].Value.ToString();
            textBoxCodigo.Text = dataGridViewRecursos.CurrentRow.Cells["codigo"].Value.ToString();
            textBoxDescripcion.Text = dataGridViewRecursos.CurrentRow.Cells["descripcion"].Value.ToString();

            tabControl1.SelectedTab = tabPage1;
            buttonGuardar.Text = "Actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int codigoR = Convert.ToInt32(dataGridViewRecursos.CurrentRow.Cells["idrecursos"].Value.ToString());
            try
            {
                if (logicaNR.eliminarRecursos(codigoR) > 0)
                {
                    MessageBox.Show("Eliminado con éxito!");
                    dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al elminar recurso");
            }
        }
    }
}

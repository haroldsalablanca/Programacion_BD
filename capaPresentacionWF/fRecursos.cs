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

        public static TabPage SelectedTab { get; private set; } //Consultar

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Recursos objetoRecurso = new Recursos();
                    objetoRecurso.nombrer = textBoxNombrer.Text;
                    objetoRecurso.codigo = textBoxCodigo.Text;
                    objetoRecurso.descripcion = textBoxDescripcion.Text;

                    if (logicaNR.insertarRecursos(objetoRecurso) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
                        textBoxNombrer.Text = "";
                        textBoxDescripcion.Text = "";
                        textBoxCodigo.Text = "";
                        tabRecursos.SelectedTab = tabPage2; //Consultar
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
                        tabRecursos.SelectedTab = tabPage2;
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





        //Boton guardar en detalle
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (buttonBuscar.Text == "Buscar")
            //    {
            //        Recursos objetoRecurso = new Recursos();
            //        objetoRecurso.nombrer = textBoxNombrer.Text;
            //        objetoRecurso.codigo = textBoxCodigo.Text;
            //        objetoRecurso.descripcion = textBoxDescripcion.Text;

            //        if (logicaNR.insertarRecursos(objetoRecurso) > 0)
            //        {
            //            MessageBox.Show("Agregado con éxito");
            //            dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
            //            textBoxNombrer.Text = "";
            //            textBoxDescripcion.Text = "";
            //            textBoxCodigo.Text = "";
            //            tabRecursos.SelectedTab = tabPage2; //Consultar
            //        }
            //        else { MessageBox.Show("Error al agregar Recurso"); }
            //    }
            //    if (buttonGuardar.Text == "Actualizar")
            //    {
            //        Recursos objetoRecurso = new Recursos();
            //        objetoRecurso.idrecursos = Convert.ToInt32(textBoxId.Text);
            //        objetoRecurso.nombrer = textBoxNombrer.Text;
            //        objetoRecurso.codigo = textBoxCodigo.Text;
            //        objetoRecurso.descripcion = textBoxDescripcion.Text;

            //        if (logicaNR.editarRecursos(objetoRecurso) > 0)
            //        {
            //            MessageBox.Show("Actualizado con éxito");
            //            dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
            //            textBoxNombrer.Text = "";
            //            textBoxCodigo.Text = "";
            //            textBoxDescripcion.Text = "";
            //            tabRecursos.SelectedTab = tabPage2;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error al actualizar Recurso");
            //        }
            //        buttonGuardar.Text = "Guardar";
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("ERROR");
            //}


        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabRecursos_Load(object sender, EventArgs e)
        {

        }
    }
}

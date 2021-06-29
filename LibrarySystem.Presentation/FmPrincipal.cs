﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarySystem.Business;

namespace LibrarySystem.Presentation
{
    public partial class FmPrincipal : Form
    {
        private int childFormNumber = 0;

        public FmPrincipal()
        {
            InitializeComponent();
        }


        
        private void BuscarLibros(string identificador)
        {
            try
            {
                if (CmbLibro.Text == "Codigo") { DgvListLibro.DataSource = BLibro.BuscarId(identificador); }
                else if (CmbLibro.Text == "Titulo"){ DgvListLibro.DataSource = BLibro.BuscarTitulo(identificador); }
                else if (CmbLibro.Text == "Autor") { DgvListLibro.DataSource = BLibro.BuscarAutor(identificador); }
                this.FormatoLibros();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BuscarPrestamos(string Id)
        {
            try
            {
                DgvListPrestamo.DataSource = BPrestamo.Buscar(Id);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BuscarProfesor(string identificador)
        {
            try
            {
                DgvListProfesor.DataSource = BUsuario.BuscarProfesor(identificador);
                this.FormatoProfesores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoLibros()
        {
            DgvListLibro.Columns[0].Width = 50;
            DgvListLibro.Columns[1].Visible = false;
            DgvListLibro.Columns[2].Width = 100;
            DgvListLibro.Columns[3].Width = 100;
            DgvListLibro.Columns[4].Width = 100;
            DgvListLibro.Columns[5].Visible = false;
            DgvListLibro.Columns[6].Visible = false;
            DgvListLibro.Columns[7].Visible = false;
            DgvListLibro.Columns[8].Width = 100;
            DgvListLibro.Columns[9].Visible = false;
            DgvListLibro.Columns[10].Visible = false;
            DgvListLibro.Columns[11].Visible = false;
            DgvListLibro.Columns[12].Width = 150;

        }

        private void FormatoProfesores()
        {
            DgvListProfesor.Columns[0].Width = 50;
            DgvListProfesor.Columns[1].Width = 100;
            DgvListProfesor.Columns[2].Width=100;
            DgvListProfesor.Columns[3].Width=200;
            DgvListProfesor.Columns[4].Visible = false;
            DgvListProfesor.Columns[5].Visible = false;
        }






        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BuscarLibros(TxtLibro.Text);

        }

        private void FmPrincipal_Load(object sender, EventArgs e)
        {
           
        }

        private void FmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void DgvListProfesor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                //recupero valor string de la celda "id"
                String id = Convert.ToString(DgvListProfesor.CurrentRow.Cells["ID"].Value);
                this.BuscarPrestamos(id);



            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione celda");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.BuscarProfesor(TxtProfesor.Text);
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DgvListProfesor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

           
        }
    }
}

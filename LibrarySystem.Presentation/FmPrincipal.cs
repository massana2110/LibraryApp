using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LibrarySystem.Business;

namespace LibrarySystem.Presentation
{
    public partial class FmPrincipal : Form
    {
        private int childFormNumber = 0;
        public int IdUsuario;
        public int IdRol;
        public string Nombre;
        public string Rol;
        public bool Estado; 

        public FmPrincipal()
        {
            InitializeComponent();
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Library System", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Library System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarMantenimiento()
        {
            
            TxtISBN.Text = "";
            TxtTitulo.Text = "";
            TxtAutor.Text = "";
            TxtEditorial.Text = "";
            TxtEdicion.Text = "";
            TxtNumeroEdicion.Text = "";
            TxtPais.Text = "";
            TxtIdioma.Text = "";
            TxtMateria.Text = "";
            TxtNumeroPaginas.Text = "";
            TxtUbicacion.Text = "";
            TxtDescripcion.Text = "";

        }
        private void ListarLibrosDisponibles()
        {
            try
            {
                DgvListLibro.DataSource = BLibro.ListarDisponibles();
                this.FormatoLibrosPrestamo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DesactivarLibro(int id)
        {
            try
            {
                BLibro.DesactivarEstado(id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void DesactivarPrestamo(int id)
        {
            try
            {
                 BPrestamo.ActualizarDevolucion(id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ActivarLibro(int id)
            {
                try
                {
                   BLibro.ActivarEstado(id);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        private void ListarProfesores()
        {
            try
            {
                DgvListProfesor.DataSource = BUsuario.ListarProfesores();
                this.FormatoProfesores();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void ListarProfesoresDevolucion()
        {
            try
            {
                DgvProfesoresDevolucion.DataSource = BUsuario.ListarProfesores();
                this.FormatoProfesoresDevolucion();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void ListarLibrosConsultasTab()
        {
            try
            {
                DgvListLibrosConsultas.DataSource = BLibro.Listar();
                this.FormatoLibrosConsulta();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void ListarLibrosMantenimientoTab()
        {
            try
            {
                DgvMantenimiento.DataSource = BLibro.Listar();
                this.FormatoLibrosMantenimiento();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void BuscarLibrosPrestamosTab(string identificador)
        {
            try
            {
                if (CmbLibro.Text == "Codigo") { DgvListLibro.DataSource = BLibro.BuscarIdActivo(identificador); this.FormatoLibrosPrestamo(); }
                else if (CmbLibro.Text == "Titulo"){ DgvListLibro.DataSource = BLibro.BuscarTituloActivo(identificador); this.FormatoLibrosPrestamo(); }
                else if (CmbLibro.Text == "Autor") { DgvListLibro.DataSource = BLibro.BuscarAutorActivo(identificador); this.FormatoLibrosPrestamo(); }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void BuscarLibrosConsultasTab(string identificador)
        {
            try
            {
                if (CmbConsulta.Text == "Codigo") { DgvListLibrosConsultas.DataSource = BLibro.BuscarId(identificador); this.FormatoLibrosConsulta(); }
                else if (CmbConsulta.Text == "Titulo") { DgvListLibrosConsultas.DataSource = BLibro.BuscarTitulo(identificador); this.FormatoLibrosConsulta(); }
                else if (CmbConsulta.Text == "Autor") { DgvListLibrosConsultas.DataSource = BLibro.BuscarAutor(identificador); this.FormatoLibrosConsulta(); }
               
            }
            catch (Exception ex)
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
        private void BuscarPrestamosDevolucion(string Id)
        {
            try
            {
                DgvPrestamosActivosDevolucion.DataSource = BPrestamo.Buscar(Id);
                this.FormatoDgvPrestamoDevolucion();
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
        private void BuscarProfesorDevolucion(string identificador)
        {
            try
            {
                DgvProfesoresDevolucion.DataSource = BUsuario.BuscarProfesor(identificador);
                this.FormatoProfesoresDevolucion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoLibrosPrestamo()
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
            DgvListLibro.Columns[13].Visible = false;


        }
        private void FormatoLibrosConsulta()
        {
            DgvListLibrosConsultas.Columns[0].Width = 50;
            DgvListLibrosConsultas.Columns[1].Width = 150;
            DgvListLibrosConsultas.Columns[2].Width = 150;
            DgvListLibrosConsultas.Columns[3].Width = 150;
            DgvListLibrosConsultas.Columns[4].Width = 150;
            DgvListLibrosConsultas.Columns[5].Width = 150;
            DgvListLibrosConsultas.Columns[6].Width = 150;
            DgvListLibrosConsultas.Columns[7].Width = 150;
            DgvListLibrosConsultas.Columns[8].Width = 150;
            DgvListLibrosConsultas.Columns[9].Width = 150;
            DgvListLibrosConsultas.Columns[10].Width = 150;
            DgvListLibrosConsultas.Columns[11].Width = 150;
            DgvListLibrosConsultas.Columns[12].Width = 150;
            DgvListLibrosConsultas.Columns[13].Width = 200;
            DgvListLibrosConsultas.Columns[13].HeaderText = "Disponibilidad";

        }

        private void FormatoLibrosMantenimiento()
        {
            DgvMantenimiento.Columns[0].Width = 50;
            DgvMantenimiento.Columns[1].Visible = false;
            DgvMantenimiento.Columns[2].Visible = false;
            DgvMantenimiento.Columns[3].Visible = false;
            DgvMantenimiento.Columns[4].Visible = false;
            DgvMantenimiento.Columns[5].Visible = false;
            DgvMantenimiento.Columns[6].Visible = false;
            DgvMantenimiento.Columns[7].Visible = false;
            DgvMantenimiento.Columns[8].Visible = false;
            DgvMantenimiento.Columns[9].Visible = false;
            DgvMantenimiento.Columns[10].Visible = false;
            DgvMantenimiento.Columns[11].Visible = false;
            DgvMantenimiento.Columns[12].Visible = false;
            DgvMantenimiento.Columns[13].Visible = false;
            DgvMantenimiento.Columns[13].Visible = false;

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
        private void FormatoProfesoresDevolucion()
        {
            DgvProfesoresDevolucion.Columns[0].Width = 50;
            DgvProfesoresDevolucion.Columns[1].Width = 100;
            DgvProfesoresDevolucion.Columns[2].Width = 100;
            DgvProfesoresDevolucion.Columns[3].Width = 200;
            DgvProfesoresDevolucion.Columns[4].Visible = false;
            DgvProfesoresDevolucion.Columns[5].Visible = false;
        }
        private void FormatoDgvPrestamoDevolucion()
        {
            DgvPrestamosActivosDevolucion.Columns[0].Width = 50;
            DgvPrestamosActivosDevolucion.Columns[1].Width = 100;
            DgvPrestamosActivosDevolucion.Columns[2].Width = 100;
            DgvPrestamosActivosDevolucion.Columns[3].Width = 100;
            DgvPrestamosActivosDevolucion.Columns[4].Width = 100;
            DgvPrestamosActivosDevolucion.Columns[5].Width = 100;
        }

        private void FormatoDgvPrestamoReporte()
        {
            DgvReportes.Columns[0].Width = 50;
            DgvReportes.Columns[1].Width = 300;
            DgvReportes.Columns[2].Width = 300;
            DgvReportes.Columns[3].Width = 300;
            DgvReportes.Columns[4].Width = 300;
            DgvReportes.Columns[5].Width = 300;
        }
        private void FormatoLibroActivosReporte()
        {
            DgvReportes.Columns[0].Width = 50;
            DgvReportes.Columns[1].Width = 150;
            DgvReportes.Columns[2].Width = 150;
            DgvReportes.Columns[3].Width = 150;
            DgvReportes.Columns[4].Width = 150;
            DgvReportes.Columns[5].Width = 150;
            DgvReportes.Columns[6].Width = 150;
            DgvReportes.Columns[7].Width = 150;
            DgvReportes.Columns[8].Width = 150;
            DgvReportes.Columns[9].Width = 150;
            DgvReportes.Columns[10].Width = 150;
            DgvReportes.Columns[11].Width = 150;
            DgvReportes.Columns[12].Width = 150;
            DgvReportes.Columns[13].Width = 200;
            DgvReportes.Columns[13].HeaderText = "Disponibilidad";
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
            this.BuscarLibrosPrestamosTab(TxtLibro.Text);

        }

        private void FmPrincipal_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido: " + this.Nombre, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            

            if (this.Rol.Equals("profesor"))
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.SelectTab("tabPage2");
                tabControl1.SelectedIndex = 2;
            }

            this.ListarLibrosConsultasTab();
            this.ListarLibrosDisponibles();
            this.ListarProfesores();
            this.ListarProfesoresDevolucion();
            ListarLibrosMantenimientoTab();
            this.DgvListLibro.AllowUserToAddRows = false;
            this.DgvListLibrosConsultas.AllowUserToAddRows = false;
            this.DgvListProfesor.AllowUserToAddRows = false;
            this.DgvListPrestamo.AllowUserToAddRows = false;
            this.DgvProfesoresDevolucion.AllowUserToAddRows = false;
            this.DgvPrestamosActivosDevolucion.AllowUserToAddRows = false;
            DgvProfesoresDevolucion.CurrentCell = null;
            DgvPrestamosActivosDevolucion.CurrentCell = null;    
            DgvListLibro.CurrentCell = null;
            DgvListProfesor.CurrentCell = null;
            this.DgvReportes.AllowUserToAddRows = false;
            DgvReportes.CurrentCell = null;
            this.DgvMantenimiento.AllowUserToAddRows = false;
            DgvMantenimiento.CurrentCell = null;



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
                
                this.BuscarPrestamos(Convert.ToString(DgvListProfesor.CurrentRow.Cells["ID"].Value));
               


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
            try
            {
                string Rpta = "";
                if(DgvListLibro.CurrentCell==null)
                {
                    this.MensajeError("Falta Seleccionar Libro");

                }
                else if (DgvListProfesor.CurrentCell == null)
                {
                    this.MensajeError("Falta Seleccionar Profesor");
                }
                else if(DatePickerDevolucion.Value==null)
                {
                    this.MensajeError("Falta Seleccionar Fecha de devolucion");
                    
                }
                else
                {


                    Rpta = BPrestamo.Insertar
                        (
                        Convert.ToInt32(DgvListProfesor.CurrentRow.Cells["ID"].Value),
                        Convert.ToInt32(DgvListLibro.CurrentRow.Cells["ID"].Value),
                        DateTime.Now,
                        DatePickerDevolucion.Value,
                        true
                        );

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se ingreso de forma correcta");
                        this.DesactivarLibro(Convert.ToInt32(DgvListLibro.CurrentRow.Cells["ID"].Value));
                        this.ListarLibrosDisponibles();
                        this.BuscarPrestamos(Convert.ToString(DgvListProfesor.CurrentRow.Cells["ID"].Value));


                        TxtLibro.Text = "";
                        TxtProfesor.Text = "";
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                    
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
           
           
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.BuscarLibrosConsultasTab(TxtConsulta.Text);
        }

        private void DgvListProfesor_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            DgvListLibro.CurrentCell = null;
            DgvListProfesor.CurrentCell = null;
            DgvListPrestamo.CurrentCell = null;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void DgvProfesoresDevolucion_DoubleClick(object sender, EventArgs e)
        {

        }

        private void DgvProfesoresDevolucion_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //recupero valor string de la celda "id"

                this.BuscarPrestamosDevolucion(Convert.ToString(DgvProfesoresDevolucion.CurrentRow.Cells["ID"].Value));



            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione celda");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.BuscarProfesorDevolucion(TxtDevolucion.Text);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            DgvPrestamosActivosDevolucion.CurrentCell = null;
            
           
        }

        private void button5_Click(object sender, EventArgs e)
        {



            try
            {
                
                if (DgvPrestamosActivosDevolucion.CurrentCell == null)
                {
                    this.MensajeError("Falta Seleccionar Registro de prestamo");

                }
   
                else
                {

                    this.MensajeOk("Se regreso el libro a disponibilidad");
                    this.DesactivarPrestamo(Convert.ToInt32(DgvPrestamosActivosDevolucion.CurrentRow.Cells["ID"].Value));
                    this.ActivarLibro(Convert.ToInt32(DgvPrestamosActivosDevolucion.CurrentRow.Cells["IdLibro"].Value));
                    this.ListarLibrosDisponibles();
                    this.BuscarPrestamosDevolucion(Convert.ToString(DgvProfesoresDevolucion.CurrentRow.Cells["ID"].Value));
                    this.BuscarPrestamos(Convert.ToString(DgvListProfesor.CurrentRow.Cells["ID"].Value));
                    TxtDevolucion.Text = "";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void TxtEdicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtNumeroPaginas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtNumeroEdicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (
                TxtISBN.Text == "" ||
                TxtTitulo.Text == "" ||
                TxtAutor.Text == "" ||
                TxtEditorial.Text == "" ||
                TxtEdicion.Text == "" ||
                TxtNumeroEdicion.Text == "" ||
                TxtPais.Text == "" ||
                TxtIdioma.Text == "" ||
                TxtMateria.Text == "" ||
                TxtNumeroPaginas.Text == "" ||
                TxtUbicacion.Text == "" ||
                TxtDescripcion.Text == "")
                {
                    this.MensajeError("Falta Llenar informacion");

                }

                else
                {


                    Rpta = BLibro.Insertar
                        (
                    TxtISBN.Text.Trim(),
                    TxtTitulo.Text.Trim(),
                    TxtAutor.Text.Trim(),
                    TxtEditorial.Text.Trim(),
                    TxtEdicion.Text.Trim(),
                    Convert.ToInt32(TxtNumeroEdicion.Text.Trim()),
                    TxtPais.Text.Trim(),
                    TxtIdioma.Text.Trim(),
                    TxtMateria.Text.Trim(),
                    Convert.ToInt32(TxtNumeroPaginas.Text.Trim()),
                    TxtUbicacion.Text.Trim(),
                    TxtDescripcion.Text.Trim(),
                    true
                    
                        );

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se ingreso de forma correcta");
                        this.ListarLibrosConsultasTab();
                        this.ListarLibrosDisponibles();
                        ListarLibrosMantenimientoTab();

                        LimpiarMantenimiento();

                        
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            try
            {
                string Rpta = "";

                 if (DgvMantenimiento.CurrentCell == null)
                {

                    this.MensajeError("Falta seleccionar ID");

                }
                else if (
               
                Convert.ToString(DgvMantenimiento.CurrentRow.Cells["ID"].Value) == "" ||
                TxtISBN.Text == "" ||
                TxtTitulo.Text == "" ||
                TxtAutor.Text == "" ||
                TxtEditorial.Text == "" ||
                TxtEdicion.Text == "" ||
                TxtNumeroEdicion.Text == "" ||
                TxtPais.Text == "" ||
                TxtIdioma.Text == "" ||
                TxtMateria.Text == "" ||
                TxtNumeroPaginas.Text == "" ||
                TxtUbicacion.Text == "" ||
                TxtDescripcion.Text == "")
                {
                    this.MensajeError("Falta añadir datos");

                }
               

                else
                {


                    Rpta = BLibro.Actualizar
                        (
                    Convert.ToInt32(DgvMantenimiento.CurrentRow.Cells["ID"].Value),
                    TxtISBN.Text.Trim(),
                    TxtTitulo.Text.Trim(),
                    TxtAutor.Text.Trim(),
                    TxtEditorial.Text.Trim(),
                    TxtEdicion.Text.Trim(),
                    Convert.ToInt32(TxtNumeroEdicion.Text.Trim()),
                    TxtPais.Text.Trim(),
                    TxtIdioma.Text.Trim(),
                    TxtMateria.Text.Trim(),
                    Convert.ToInt32(TxtNumeroPaginas.Text.Trim()),
                    TxtUbicacion.Text.Trim(),
                    TxtDescripcion.Text.Trim(),
                    true
                        );

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizo de forma correcta");
                        this.ListarLibrosConsultasTab();
                        this.ListarLibrosDisponibles();
                        ListarLibrosMantenimientoTab();
                        

                        LimpiarMantenimiento();


                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {


                string Rpta = "";


                 if (DgvMantenimiento.CurrentCell == null)
                {

                    this.MensajeError("Falta seleccionar ID de libro a Eliminar");

                }
                else if (Convert.ToString(DgvMantenimiento.CurrentRow.Cells["ID"].Value) == "" )
                
                {
                    this.MensajeError("Falta seleccionar ID de libro a cual eliminar");

                }

                else if (Convert.ToBoolean(DgvMantenimiento.CurrentRow.Cells["Estado"].Value) == false)

                {
                    this.MensajeError("No se puede eliminar un libro que este alquilado");

                }

                else
                {


                    Rpta = BLibro.Eliminar
                        (
                    Convert.ToInt32(DgvMantenimiento.CurrentRow.Cells["ID"].Value)

                        );

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se elimino sastifactoriamente");
                        this.ListarLibrosConsultasTab();
                        this.ListarLibrosDisponibles();
                        ListarLibrosMantenimientoTab();

                        LimpiarMantenimiento();


                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbReporte.Text == "Libros Registrados") { DgvReportes.DataSource = BLibro.Listar(); this.FormatoLibroActivosReporte(); }
                else if (CmbReporte.Text == "Prestamos Activos") { DgvReportes.DataSource = BPrestamo.Listar(); this.FormatoDgvPrestamoReporte(); }
                else if (CmbReporte.Text == "") { this.MensajeError("Favor elegir una opcion"); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DgvReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

            
           

        }

        private void DgvMantenimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
            DgvMantenimiento.CurrentCell = null;
            LimpiarMantenimiento();
        }

        private void DgvMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtISBN.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["ID"].Value);
            TxtAutor.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Autor"].Value);
            TxtTitulo.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Titulo"].Value);
            TxtEditorial.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Editorial"].Value);
            TxtEdicion.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Edicion"].Value);
            TxtNumeroEdicion.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["#Edicion"].Value);
            TxtPais.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Pais"].Value);
            TxtIdioma.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Idioma"].Value);
            TxtMateria.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Materia"].Value);
            TxtNumeroPaginas.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["#Paginas"].Value);
            TxtUbicacion.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Ubicacion"].Value);
            TxtDescripcion.Text = Convert.ToString(DgvMantenimiento.CurrentRow.Cells["Descripcion"].Value);
        }

        private void CmbReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }
    }
    
}

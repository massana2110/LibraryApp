using System;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // TODO: Cambiar logica para que funcione el login correctamente
            try
            {
                DataTable Tabla = new DataTable();
                Tabla = BUsuario.Login(TxtEmail.Text.Trim(), txtContrasenia.Text.Trim());

                if(Tabla.Rows.Count <= 0)
                {
                    MessageBox.Show("Sus credenciales son incorrectas.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(Convert.ToBoolean(Tabla.Rows[0][4]) == false)
                    {
                        MessageBox.Show("El usuario no esta activo", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                    else
                    {
                        FmPrincipal mainForm = new FmPrincipal();
                        mainForm.IdUsuario = Convert.ToInt32(Tabla.Rows[0][0]);
                        mainForm.IdRol = Convert.ToInt32(Tabla.Rows[0][1]);
                        mainForm.Rol = Convert.ToString(Tabla.Rows[0][2]);
                        mainForm.Nombre = Convert.ToString(Tabla.Rows[0][3]);
                        mainForm.Estado = Convert.ToBoolean(Tabla.Rows[0][4]);
                        mainForm.Show();
                        this.Hide();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

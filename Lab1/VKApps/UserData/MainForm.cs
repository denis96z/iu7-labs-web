using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserData
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                VkManager vkManager = new VkManager();
                VkUser user = vkManager.GetUserById(long.Parse(tbId.Text));
                tbName.Text = user.Name;
                tbMiddleName.Text = user.MiddleName;
                tbSurname.Text = user.Surname;
                tbDateOfBirth.Text = user.DateOfBirth;
                tbCity.Text = user.City;
                if (user.Photo != null)
                {
                    pbPhoto.Image = user.Photo;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private bool photoMaximized = false;

        private void pbPhoto_Click(object sender, EventArgs e)
        {
            if (photoMaximized)
            {
                Left += 200;
                Top += 200;
                Width -= 160;
                Height -= 400;
                pbPhoto.Left += 260;
                pbPhoto.Width -= 400;
                pbPhoto.Height -= 400;
                photoMaximized = false;
            }
            else
            {
                Left -= 200;
                Top -= 200;
                Width += 160;
                Height += 400;
                pbPhoto.Left -= 260;
                pbPhoto.Width += 400;
                pbPhoto.Height += 400;
                photoMaximized = true;
            }
        }
    }
}

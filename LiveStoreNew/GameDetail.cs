using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace LiveStoreNew
{
    public partial class GameDetail : MetroForm
    {
        public GameDetail(string name, string data, string image_url)
        {
            InitializeComponent();
            this.Text =  "Game detail - " + name;
            this.popisek.Text = data;
            this.image.ImageLocation = image_url;
            MessageBox.Show(image_url);
        }

        private void GameDetail_Load(object sender, EventArgs e)
        {

        }
    }
}

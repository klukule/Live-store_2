using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Diagnostics;
using System.Reflection;
using System.Globalization;
using System.Configuration;

namespace LiveStoreNew
{
    public partial class main : MetroForm
    {
        /*PUBLIC VARIABLES*/
        Data Data = new Data();
        public string GetMD5(string StrToHash)
        {
            byte[] hash = MD5CryptoServiceProvider.Create().ComputeHash(Encoding.ASCII.GetBytes(StrToHash));
            StringBuilder str = new StringBuilder();
            foreach (byte b in hash)
            {
                str.Append(b.ToString("x2"));
            }
            return str.ToString();
        }
        /*END PUBLIC VARIABLES*/

        /*LOGIN*/
        bool loginacc;
        public void LoginPanelStatus()
        {
            if (loginacc == true)
            {
                this.LoginPanel.Visible = false;
                this.mainpanel.Visible = true;
                this.loadingdatapanel.Visible = true;
                this.logindatapanel.Visible = true;
            }
            else
            {
                this.LoginPanel.Visible = true;
                this.mainpanel.Visible = false;
                this.loadingdatapanel.Visible = false;
                this.logindatapanel.Visible = false;
            }
        
        }

        public void doLoad()
        {
            string url = "http://" + Data.IP + "/gamelibrary.php";
            string response = Util.HTTPRequest(url);
            if (response != "")
            {
                //Game 1
                string gamelogo1 = Util.ParseBetween(response, "<game1>", "</game1>");
                if (gamelogo1 != "none")
                {
                    game1.ImageLocation = gamelogo1;
                }
                else{game1.Visible = false;};
                //Game 2
                string gamelogo2 = Util.ParseBetween(response, "<game2>", "</game2>");
                if (gamelogo2 != "none")
                {
                    game2.ImageLocation = gamelogo2;
                }
                else { game2.Visible = false; };
                loadingdatapanel.Visible = false;
            }
            
        }
        public void doLogin()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string DataToPost = "un=" + txtUser.Text + "&ps=" + GetMD5(txtPass.Text);
            byte[] data = encoding.GetBytes(DataToPost);
            StringBuilder sb = new StringBuilder();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + Data.IP + "/loginweb.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream sendStream = request.GetRequestStream();
            sendStream.Write(data, 0, data.Length);
            sendStream.Close();
            byte[] bRead = new byte[8192];
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;

            do
            {
                count = resStream.Read(bRead, 0, bRead.Length);
                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(bRead, 0, count);
                    sb.Append(tempString);
                }
            }

            while (count > 0);
            if ("  " + txtUser.Text + " " == sb.ToString())
            {
                loginacc = true;
                LoginPanelStatus();
                UserName.Text = sb.ToString();
                UserName.AutoSize = true;
                UserName.Left = 182 + 50 - UserName.Width;
                useravatar.ImageLocation = "http://" + Data.IP + "/avatar.png";
                doLoad();
            }
            else
                metroLabel1.Text = "Bad username or password";
        }
        /*END LOGIN*/


        public main()
        {
            loginacc = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoginPanelStatus();
           
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            doLogin();
        }
        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e, string clickedid)
        {
            string url = "http://" + Data.IP + "/loaddata.php?id=" + clickedid + "";
            string response = Util.HTTPRequest(url);
            if (response != "")
            {
                string name = Util.ParseBetween(response, "<name>", "</name>");
                string image_url = Util.ParseBetween(response, "<image_url>", "</image_url>");
                string[] data = Util.GetStringInBetween("<data>", "</data>", response, false, false);
                data[0] = data[0].Replace("//", "\r\n");
                if (!string.IsNullOrEmpty(data[0]))
                {
                    GameDetail form2 = new GameDetail(name, data[0], image_url);
                    form2.ShowDialog();
                    form2.Activate();

                }
            }
        }

        private void game1_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync(game1);
            MessageBox.Show("WORKING ON IT :D");
        }

        private void button_register_Click(object sender, EventArgs e)
        {

        }

        private void game2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WORKING ON IT :D");

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            loginacc = false;
            LoginPanelStatus();
        }



    }
}

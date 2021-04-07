using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            waterWark();
        }
        void waterWark()
        {
            txtUser.Text = "Vui lòng nhập Tài Khoản";
            txtUser.ForeColor = Color.LightGray;
            txtUser.Font = new Font(txtUser.Font.Name, txtUser.Font.Size, FontStyle.Italic);

            txtPassWord.Text = "Vui lòng nhập Mật Khẩu";
            txtPassWord.ForeColor = Color.LightGray;
            txtPassWord.Font = new Font(txtPassWord.Font.Name, txtPassWord.Font.Size, FontStyle.Italic);

            txtUser.Leave += new System.EventHandler(this.TxtUser_Leave);
            txtUser.Enter += new System.EventHandler(this.TxtUser_Enter);

            txtPassWord.Leave += new System.EventHandler(this.TxtPassWord_Leave);
            txtPassWord.Enter += new System.EventHandler(this.TxtPassWord_Enter);
        }

        private void TxtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Vui lòng nhập Tài Khoản")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
                txtUser.Font = new Font(txtUser.Font.Name, txtUser.Font.Size, FontStyle.Bold);
            }
        }
        private void TxtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Vui lòng nhập Tài Khoản";
                txtUser.ForeColor = Color.LightGray;
                txtUser.Font = new Font(txtUser.Font.Name, txtUser.Font.Size, FontStyle.Italic);
            }
        }


        private void TxtPassWord_Leave(object sender, EventArgs e)
        {
            if (txtPassWord.Text == "")
            {
                txtPassWord.Text = "Vui lòng nhập Mật Khẩu";
                txtPassWord.ForeColor = Color.LightGray;
                txtPassWord.Font = new Font(txtPassWord.Font.Name, txtPassWord.Font.Size, FontStyle.Italic);
            }
        }
       
        private void TxtPassWord_Enter(object sender, EventArgs e)
        {
            if (txtPassWord.Text == "Vui lòng nhập Mật Khẩu")
            {
                txtPassWord.Text = "";
                txtPassWord.ForeColor = Color.Black;
                txtPassWord.Font = new Font(txtPassWord.Font.Name, txtPassWord.Font.Size, FontStyle.Bold);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text;
            string passWord = txtPassWord.Text;
            if (Login(userName,passWord))
            {
                AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);

                RoomManager R = new RoomManager(loginAccount);
                this.Hide();
                R.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Thông báo");
            }    
        }
        bool Login(string UserName,string PassWord)
        {
            return AccountDAO.Instance.Login(UserName, PassWord);
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

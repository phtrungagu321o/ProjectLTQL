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
    public partial class AccountProfile : Form
    {
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value;  }

        }
        public AccountProfile(AccountDTO acc)
        {
            InitializeComponent();
            
            loginAccount = acc;
            changeAccuont(loginAccount);
        }
        void changeAccuont(AccountDTO acc)
        {
            txtUser.Text = loginAccount.UserName;
            txtDisplayName.Text = loginAccount.DisPlayName;

        }
        private event EventHandler <AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string displayName = txtDisplayName.Text;
            string passWord = txtPassWord.Text;
            string newPass = txtNewPassWord.Text;
            string reenter = txtReEnterPassWord.Text;
            string userName = txtUser.Text;

            
                if (!newPass.Equals(reenter))
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!!!!!");
                }
                else
                {
                if (txtPassWord.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!!");
                    return;
                }

                else
                {
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có chắc với sự thay đổi này không"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {

                        if (AccountDAO.Instance.UpdateAccount(userName, displayName, passWord, newPass))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            if (updateAccount != null)
                            {
                                updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng điền đúng mật khẩu");
                        }
                    }
                }
                    
                
            }
        }
    }
     public class AccountEvent:EventArgs
    {
        private AccountDTO acc;//hàm dựng

        public AccountDTO Acc { get => acc; set => acc = value; }

        public AccountEvent(AccountDTO acc)
        {
            this.Acc = acc;
        }
    }
 }    
      
    
   



using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class AccountDTO
    {
        public AccountDTO(string username,string displayname,int type, string password=null)
        {
            this.UserName = username;
            this.DisPlayName = displayname;
            this.Type = type;
            this.PassWord1 = password;
            
        }
        public AccountDTO(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisPlayName = row["Displayname"].ToString();
            this.Type = (int)row["type"];
            this.PassWord1 = row["PassWord"].ToString();
            
        }
        private string userName;
        private string disPlayName;
        private string PassWord;
        private int type;
        public string UserName {
            get { return userName; }
            set { userName = value; }
        }
        public string DisPlayName {
            get { return disPlayName; }
            set { disPlayName = value; }
        }
        public string PassWord1 {
            get { return PassWord; }
            set { PassWord = value; }
        }
        public int Type {
            get { return type; }
            set { type = value; }
        }
    }
}

using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO();return instance; }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }


        /// <summary>
        /// Mã hóa chuỗi có mật khẩu
        /// </summary>
        /// <param name="toEncrypt">Chuỗi cần mã hóa</param>
        /// <returns>Chuỗi đã mã hóa</returns>
        public static string Encrypt(string toEncrypt)
        {
            string key = "ToiTenLaTrung";

            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// Giản mã
        /// </summary>
        /// <param name="toDecrypt">Chuỗi đã mã hóa</param>
        /// <returns>Chuỗi giản mã</returns>
        public static string Decrypt(string toDecrypt)
        {
            string key = "ToiTenLaTrung";
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public bool Login(string UserName,string PassWord)
        {   
            string encodestring = Encrypt(PassWord);       
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] {UserName, encodestring });
            return result.Rows.Count > 0;
        }
        public bool UpdateAccount(string userName, string displayName,string passWord,string newpass)
        {
            
            string Encodestring = Encrypt(passWord);
            if (newpass == "")
            {
                int result1 = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @DisPlayName , @passWord , @NewpassWord", new object[] { userName, displayName, Encodestring, newpass });
                return result1 > 0;
            }
            else
            {
                string NewEncodestring = Encrypt(newpass);

                int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @DisPlayName , @passWord , @NewpassWord", new object[] { userName, displayName, Encodestring, NewEncodestring });
                return result > 0;
            }
        }

        public DataTable GetlistAccount()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT UserName,Displayname,type FROM dbo.Account");
        }
        public AccountDTO GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Account where UserName= '"+username+"'");
            foreach(DataRow item in data.Rows)
            {
                return new AccountDTO(item);        
            }
            return null;
        }
        public List<AccountDTO> GetAccount()
        {
            List<AccountDTO> list = new List<AccountDTO>();
            string query = "SELECT *FROM Account ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                list.Add(account);
            }
            return list;
        }
        public bool InsertAccount(string username,string displayname,int type)
        {
            string query = string.Format("INSERT INTO dbo.Account(UserName,Displayname,type,passWord)VALUES(   N'{0}', N'{1}', {2},N'/np3PhX7Fao=')", username,displayname,type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string username)
        {

            string query = string.Format("delete from Account where UserName=N'{0}'",username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(string username, string displayname, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET Displayname=N'{0}',type={1} WHERE UserName=N'{2}'", displayname, type, username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetPassWord(string username)
        {
            
            string query = string.Format("UPDATE dbo.Account SET PassWord=N'/np3PhX7Fao=' WHERE UserName=N'{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}

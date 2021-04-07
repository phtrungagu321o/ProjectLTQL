using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        {
            get { if (instance == null) instance = new BillInfoDAO();return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        private BillInfoDAO() { }

        public List<BillInfoDTO> GetListBillInfo(int id)
        {
            List<BillInfoDTO> listBillInfo = new List<BillInfoDTO>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT *FROM dbo.BillInfo WHERE idBill=" + id);
            foreach (DataRow item in data.Rows) 
            {
                BillInfoDTO info = new BillInfoDTO(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idService, int countService,int idRoom)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idService , @countService , @idRoom", new object[] { idBill, idService, countService,idRoom });
        }
        public void DeleteBillInfoByServiceID(int id)
        {
            DataProvider.Instance.ExcuteQuery("Delete from BillInfo WHERE idService= " + id);
        }
        public void DeleteBillInfoByBillID(int id)
        {
            DataProvider.Instance.ExcuteQuery("Delete from BillInfo WHERE idBill= " + id);
        }
    }
}

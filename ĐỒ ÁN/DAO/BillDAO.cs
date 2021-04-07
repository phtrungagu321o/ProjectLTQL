using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{

    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }
        /// <summary>
        /// Thành công: billID
        /// thất bại -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetUnCheckBillIDByRoomID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Bill WHERE idRoom=" + id + " AND status=0");

            if (data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID;

            }
            return -1;
        }
        public List<BillDTO> GetCheckBillIDByRoomID(int id)
        {
            List<BillDTO> list = new List<BillDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Bill WHERE idRoom=" + id );
            foreach(DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                list.Add(bill);
            }    

            return list;
        }
        public void CheckOut(int id,int disCount,string totalTime,float priceoldtime,float totalPice)
        {
            string query = "Update dbo.bill set DateTimeCheckOut= GETDATE(), status=1,"+"DisCount = "+disCount+", ToTaLTime = N'"+totalTime+"'"+", PRiceOldTime= "+ priceoldtime + ", totalPrice= "+totalPice+ "where id="+id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InserBill @idRoom", new object[] { id });
        }
        public void InsertStartBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InserStartBill @idRoom", new object[] { id });
        }
        public DataTable GetBillListByDateTime(DateTime checkIn,DateTime checkOut)
        {
           return DataProvider.Instance.ExcuteQuery("USP_GetListBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public DataTable GetBillListByDateTimeAndPage(DateTime checkIn, DateTime checkOut,int PageNum)
        {
            return DataProvider.Instance.ExcuteQuery("USP_GetListBillByDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn, checkOut, PageNum });
        }
        public int GetBillNumByDateTime(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id)FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
        public void DeleteBillByidRoom(int id)
        {
            List<BillDTO> lits = BillDAO.Instance.GetCheckBillIDByRoomID(id);
            foreach (BillDTO item in lits)
            {
                BillInfoDAO.Instance.DeleteBillInfoByBillID(item.ID);
            }
             DataProvider.Instance.ExecuteNonQuery("delete from Bill where idRoom=" + id);
        }
    }
}

using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class RoomCategoryDAO
    {
        private static RoomCategoryDAO instance;

        public static RoomCategoryDAO Instance {
            get { if (instance == null) instance = new RoomCategoryDAO();return RoomCategoryDAO.instance; }
            private set { RoomCategoryDAO.instance = value; }
        }
        private RoomCategoryDAO() { }

        public List<RoomCategoryDTO> ListRoomCategory()
        {
            List<RoomCategoryDTO> list = new List<RoomCategoryDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT *FROM dbo.RoomCategory");
            foreach(DataRow item in data.Rows)
            {
                RoomCategoryDTO listRoomCategory = new RoomCategoryDTO(item);
                list.Add(listRoomCategory);
            }    
            return list;
        }
        public RoomCategoryDTO GetRoomCategoryByID(int id)
        {
            RoomCategoryDTO categoryRoom = null;
            string query = "SELECT *FROM RoomCategory where id= " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                categoryRoom = new RoomCategoryDTO(item);
                return categoryRoom;
            }

            return categoryRoom;
        }
        public bool InsertRoomCategory(string name,float price)
        {
            string query = string.Format("INSERT INTO dbo.RoomCategory(RoomNameCategory,Price)VALUES(   N'{0}', {1} )",name,price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateRoomCategory(string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.RoomCategory SET RoomNameCategory=N'{0}',Price={1} WHERE id={2}", name, price, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeteleRoomCategory(int id)
        {
            RoomDAO.Instance.DeteleRoomByCategory(id);
            string query = string.Format("DELETE FROM dbo.RoomCategory WHERE id={0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}

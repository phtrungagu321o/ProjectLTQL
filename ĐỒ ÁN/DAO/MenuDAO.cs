using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance 
        {
            get { if (instance == null) instance = new MenuDAO();return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }

        public List<MenuServiceDTO> GetListMenuFoodByRoom(int id)
        {
            List<MenuServiceDTO> listmenu = new List<MenuServiceDTO>();
            string query = "SELECT  s.name AS [ServiceName],s.price AS [ServicePrice],bi.countService,s.price*bi.countService AS [TotalPrice] FROM dbo.BillInfo AS bi, dbo.Bill AS b,dbo.Service AS s,dbo.Room AS r WHERE r.id=b.idRoom and bi.idBill=b.id AND bi.idService=s.id AND b.status=0 AND b.idRoom=" + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                MenuServiceDTO menu = new MenuServiceDTO(item);
                listmenu.Add(menu);
            }    
            return listmenu;
        }
        public List<MenuTimeDTO> GetListTimeByIdRoom(int id)
        {
            List<MenuTimeDTO> ListTime = new List<MenuTimeDTO>();
            string query = "SELECT CONCAT((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60),N' tiếng ' ,(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60),' phút') AS [Time],((DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())/60)*rc.Price+(DATEDIFF(MINUTE, b.DateTimeCheckIn, GETDATE())%60)*rc.Price/60) AS [TimePrice] FROM dbo.Bill AS b,dbo.Room AS r,dbo.RoomCategory AS rc WHERE b.idRoom=r.id AND r.idRoomCategory=rc.id and b.status=0 and CheckSwitch=0 and  b.idRoom=" + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                MenuTimeDTO time = new MenuTimeDTO(item);
                ListTime.Add(time);
            }    
            return ListTime;
        }
        public List<MenuPriceOldDTO> GetPriceOld(int id)
        {
            List<MenuPriceOldDTO> ListTime = new List<MenuPriceOldDTO>();
            string query = "SELECT PRiceOldTime FROM dbo.Bill WHERE status=0  AND idRoom=" + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuPriceOldDTO time = new MenuPriceOldDTO(item);
                ListTime.Add(time);
            }
            return ListTime;
        }

    }
}

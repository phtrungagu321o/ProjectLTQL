using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class ServiceDAO
    {
        private static ServiceDAO instance;

        public static ServiceDAO Instance {
            get { if (instance == null) instance = new ServiceDAO();return ServiceDAO.instance; }
            private set { ServiceDAO.instance = value; }
        }
        private ServiceDAO() { }

        public List<ServiceDTO> GetListServiceByCategory(int id)
        {
            List<ServiceDTO> list = new List<ServiceDTO>();
            string query = "SELECT *FROM dbo.Service where idServiceCategory=" + id ;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                ServiceDTO food = new ServiceDTO(item);
                list.Add(food);
            }    
            return list;
        }
        public List<ServiceDTO>GetlistService()
        {
            List<ServiceDTO> list = new List<ServiceDTO>();
            string query = "SELECT *FROM dbo.Service ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ServiceDTO food = new ServiceDTO(item);
                list.Add(food);
            }
            return list;
        }
        public List<ServiceDTO> SearchServiceByName(string name)
        {
            List<ServiceDTO> list = new List<ServiceDTO>();
            string query = string.Format("SELECT *FROM dbo.Service WHERE dbo.fuConvertToUnsign2(name) LIKE N'%' +dbo.fuConvertToUnsign2(N'{0}')+'%'", name) ;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ServiceDTO food = new ServiceDTO(item);
                list.Add(food);
            }
            return list;
        }

        public bool InsertService(int idcategory, string name, float price)
        {
            string query = string.Format("INSERT dbo.Service(name,idServiceCategory, price)VALUES(   N'{0}', {1}, {2} )",name,idcategory,price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateService(int id,int idcategory, string name, float price)
        {
            string query = string.Format("UPDATE dbo.Service SET name =N'{0}',idServiceCategory={1},price={2} WHERE id={3};", name, idcategory, price,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteService(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByServiceID(id);
            string query = string.Format("Delete Service where id= {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void DeleteServiceByCategory(int id)
        {
            List<ServiceDTO> list = ServiceDAO.Instance.GetListServiceByCategory(id);
            foreach(ServiceDTO item in list)
            {
                BillInfoDAO.Instance.DeleteBillInfoByServiceID(item.ID);
            }    
            DataProvider.Instance.ExcuteQuery("delete from service where idServiceCategory= " + id);
        }
    }
}

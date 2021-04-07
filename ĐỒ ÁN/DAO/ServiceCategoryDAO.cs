using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class ServiceCategoryDAO
    {
        private static ServiceCategoryDAO instance;

        public static ServiceCategoryDAO Instance {
            get { if (instance == null) instance = new ServiceCategoryDAO();return ServiceCategoryDAO.instance; }
            private set { ServiceCategoryDAO.instance = value; }
        }
        private ServiceCategoryDAO() { }

        public List<ServiceCategoryDTO> GetListCategory()
        {
            List<ServiceCategoryDTO> ListCategory = new List<ServiceCategoryDTO>();
            string query = "SELECT *FROM dbo.ServiceCategory";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                ServiceCategoryDTO FoodCategory = new ServiceCategoryDTO(item);
                ListCategory.Add(FoodCategory);
            }    
            return ListCategory;
        }
        public ServiceCategoryDTO GetCategory(int id)//lây 1 thằng 
        {
            ServiceCategoryDTO category = null;
            string query = "SELECT *FROM dbo.ServiceCategory where id= "+id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new ServiceCategoryDTO(item);
                return category;
            }

            return category;
        }
        public bool InsertServiceCategory(string name)
        {
            string query = string.Format("INSERT INTO dbo.ServiceCategory(name)VALUES(N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteServiceCategory(int id)
        {
            ServiceDAO.Instance.DeleteServiceByCategory(id);
            string query = string.Format("DELETE FROM dbo.ServiceCategory WHERE id={0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateServiceCategory(string name,int id)
        {
            string query = string.Format("UPDATE dbo.ServiceCategory SET name=N'{0}' WHERE id={1}", name,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}

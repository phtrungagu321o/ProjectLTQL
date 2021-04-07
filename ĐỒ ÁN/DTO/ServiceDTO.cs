using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class ServiceDTO
    {
        public ServiceDTO(int id,string name, int idservicecategory, float price)
        {
            this.ID = id;
            this.Name = name;
            this.IDServiceCategory = idservicecategory;
            this.Price = price;
        }
        public ServiceDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IDServiceCategory = (int)row["idServiceCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
        private int iD;
        private string name;
        private int iDServiceCategory;
        private float price;


        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        
        public float Price { get => price; set => price = value; }
        public int IDServiceCategory { get => iDServiceCategory; set => iDServiceCategory = value; }
    }
}

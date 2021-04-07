using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class MenuServiceDTO
    {
        public MenuServiceDTO(string nameservice,int countservice,float serviceprice,float totalprice=0)
        {
            
            this.ServiceName = nameservice;
            
            this.CountService = countservice;
            
            this.ServicePrice = serviceprice;
            
            this.TotalPrice = totalprice;
        }
        public MenuServiceDTO(DataRow row)
        {
            
            this.ServiceName = row["ServiceName"].ToString();
            this.ServicePrice = (float)Convert.ToDouble(row["ServicePrice"].ToString());
            this.CountService = (int)row["countService"];
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
        }

        private string serviceName;
       
        private int countService;
       
        private float servicePrice;
       
        private float totalPrice;

       
       
        
       
        
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
       
        
        public string ServiceName { get => serviceName; set => serviceName = value; }
        public int CountService { get => countService; set => countService = value; }
        public float ServicePrice { get => servicePrice; set => servicePrice = value; }
    }
}

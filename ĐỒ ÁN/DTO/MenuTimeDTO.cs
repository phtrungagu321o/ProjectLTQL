using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class MenuTimeDTO
    {
        public MenuTimeDTO(string time= "?? tiếng ?? phút", float timeprice=0)
        {
            this.Time = time;
            this.TimePrice = timeprice;
        }
        public MenuTimeDTO(DataRow row)
        {
            this.Time = row["Time"].ToString();
            this.TimePrice = (float)Convert.ToDouble(row["TimePrice"].ToString());
        }
        private string time;
        private float timePrice;
        public string Time { get => time; set => time = value; }
        public float TimePrice { get => timePrice; set => timePrice = value; }
    }
}

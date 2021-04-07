using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class BillDTO
    {
        public BillDTO(int id,DateTime? datecheckin,DateTime? datecheckout,int idroom,int status,int discount,string totaltime,float priceoldtime)
        {
            this.ID = id;
            this.DateCheckIn = datecheckin;
            this.DateCheckOut = datecheckout;
            this.IDRoom = idroom;
            this.Status = status;
            this.DisCount = discount;
            this.TotalTime = totaltime;
            this.PriceOldTime = priceoldtime;
        }
        public BillDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["DateTimeCheckIn"];

            var dateCheckOutTemp = row["DateTimeCheckOut"];
            if(dateCheckOutTemp.ToString()!="")
                this.DateCheckOut =(DateTime?)dateCheckOutTemp;
            this.IDRoom = (int)row["idRoom"];
            this.Status = (int)row["status"];

            if(row["DisCount"].ToString() !="")
                this.DisCount = (int)row["DisCount"];
            this.TotalTime = row["ToTalTime"].ToString();
            this.PriceOldTime = (float)Convert.ToDouble(row["PRiceOldTime"].ToString());
        }
        private int iD;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int iDRoom;
        private int status;
        private int disCount;
        private string totalTime;
        private float priceOldTime;

      
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int IDRoom { get => iDRoom; set => iDRoom = value; }
        public int Status { get => status; set => status = value; }
        public int ID { get => iD; set => iD = value; }
        public int DisCount { get => disCount; set => disCount = value; }
        public string TotalTime { get => totalTime; set => totalTime = value; }
        public float PriceOldTime { get => priceOldTime; set => priceOldTime = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
   public class RoomCategoryDTO
    {
        public RoomCategoryDTO(int id,string name,float price)
        {
            this.ID = id;
            this.NameRoomCategory = name;
            this.Price = price;
        }
        public RoomCategoryDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.NameRoomCategory = row["RoomNameCategory"].ToString();
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
        }
        private int iD;
        private string nameRoomCategory;
        private float price;

        public int ID { get => iD; set => iD = value; }
        public string NameRoomCategory { get => nameRoomCategory; set => nameRoomCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class MenuPriceOldDTO
    {
        public MenuPriceOldDTO(float priceold)
        {
            this.PriceOld1 = priceold;
        }
        public MenuPriceOldDTO(DataRow row )
        {
            this.PriceOld1 = (float)Convert.ToDouble(row["PRiceOldTime"].ToString());
        }

        private float PriceOld;

        public float PriceOld1 { get => PriceOld; set => PriceOld = value; }
    }
}

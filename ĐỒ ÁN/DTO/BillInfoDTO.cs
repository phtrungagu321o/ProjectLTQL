using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class BillInfoDTO
    {
        public BillInfoDTO(int id, int idbill, int idservice,int countservice)
        {
            this.ID = id;
            this.IDBill = idbill;
            this.IDService = idservice;
            this.CountService = countservice;

        }
        public BillInfoDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDBill = (int)row["idBill"];
            this.IDService = (int)row["idService"];
            this.CountService = (int)row["countService"];

        }
        private int iD;
        private int iDBill;
        private int iDService;
        private int countService;


        public int ID { get => iD; set => iD = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int IDService { get => iDService; set => iDService = value; }
        public int CountService { get => countService; set => countService = value; }
    }
}

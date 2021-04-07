using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN
{
    public partial class RoomManager : Form
    {
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount 
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        
        }

        public RoomManager(AccountDTO acc)
        {
            InitializeComponent();

            this.loginAccount = acc;
            ChangeAccount(loginAccount.Type);
            LoadRoom();
            LoadServiceCategory();
            LoadComboBoxRoom(cbbSwitchRoom);
        }
        #region Method
        
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type ==1;
            
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + loginAccount.DisPlayName + ")";
        }
        void LoadRoom()
        {
            flpNormalRoom.Controls.Clear();
            flpVIPRoom.Controls.Clear();
           List<RoomDTO> RoomList= RoomDAO.Instance.LoadRoomList();
            foreach(RoomDTO item in RoomList)
            {
                Button btn = new Button() {Width=RoomDAO.RoomWidth,Height=RoomDAO.RoomHeight };
                btn.Text = item.Name + "\n" + item.Status;
               
                btn.Click += Btn_Click;
                  
    
                btn.Tag = item;
               

                switch (item.Status)
                {
                    case " Trống":
                        btn.BackColor = Color.LightBlue;
                        break;
                    default:
                        btn.BackColor = Color.LightCoral;
                        break;
                }    
                
                if (item.IDRoomCategory == 1)
                    flpNormalRoom.Controls.Add(btn);
                else
                    flpVIPRoom.Controls.Add(btn);
                
            }   
                
        }

        void ShowServiceBill(int id)
        {
            lstvBill.Items.Clear();
            List<MenuServiceDTO> listFoodBillInfo = MenuDAO.Instance.GetListMenuFoodByRoom(id);
            float totalPrice = 0;
            foreach(MenuServiceDTO item in listFoodBillInfo)
            {
                ListViewItem lvItem = new ListViewItem(item.ServiceName.ToString()); 
                lvItem.SubItems.Add(item.ServicePrice.ToString());
                lvItem.SubItems.Add(item.CountService.ToString());           
                lvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lstvBill.Items.Add(lvItem);
            }
            txtTotalPriceService.Text = totalPrice.ToString();

             
        }
   
        void ShowTimeBill(int id)
        {

            txtAddTime.Text = "?? tiếng ?? phút";
            int t = 0;
            txtPriceTimeTest.Text = "0";
            CultureInfo culture = new CultureInfo("vi-VN");
            txtPriceTime.Text = t.ToString("c",culture);
            List<MenuTimeDTO> listTimeBillInfo = MenuDAO.Instance.GetListTimeByIdRoom(id);
            foreach (MenuTimeDTO item in listTimeBillInfo)
            {
                txtAddTime.Text = item.Time;
                float f = item.TimePrice;
                Console.WriteLine(f.ToString());
                
                txtPriceTime.Text = f.ToString("c",culture);
                txtPriceTimeTest.Text = f.ToString();
                
            }
        }
       
        void AddTimeBill()
        {
          
            int tr = 0;
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn xuất số giờ của bàn này vào Bill không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                ListViewItem list1 = new ListViewItem("--------------------");               
                lstvBill.Items.Add(list1);
                ListViewItem list2 = new ListViewItem("Số Giờ: "+txtAddTime.Text);
                list2.SubItems.Add("");
                list2.SubItems.Add("");
                list2.SubItems.Add(txtPriceTime.Text);
                lstvBill.Items.Add(list2);
                ListViewItem list3 = new ListViewItem("--------------------");
                lstvBill.Items.Add(list3);
                ListViewItem list4 = new ListViewItem("Số Tiền Bổ sung: ");
                list4.SubItems.Add("");
                list4.SubItems.Add("");
                list4.SubItems.Add(txtPriceTimeBillOld.Text);
                lstvBill.Items.Add(list4);

                CultureInfo culture = new CultureInfo("vi-VN");
                txtPriceTime.Text = tr.ToString("c",culture);
            }
        }
        void AddPriceOld(int id)
        {
            txtPriceTimeBillOld.Text = "0,00 ₫";
            txtTimeOldTest.Text = "0";
            List<MenuPriceOldDTO> listPriceOld = MenuDAO.Instance.GetPriceOld(id);
            foreach(MenuPriceOldDTO item in listPriceOld)
            {
                
                float f = item.PriceOld1;
                CultureInfo culture = new CultureInfo("vi-VN");
                txtPriceTimeBillOld.Text = f.ToString("c",culture);
                txtTimeOldTest.Text = f.ToString();
                
            }    
        }
        void TotalPrice()
        {
            
            double f = float.Parse(txtTotalPriceService.Text);
                     
            double t = float.Parse(txtPriceTimeTest.Text);
            double old = float.Parse(txtTimeOldTest.Text);
            double TP = f + t + old;
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPrice.Text = TP.ToString("c",culture);
            txtToTalPriceTest.Text = TP.ToString();
        }
        void LoadComboBoxRoom(ComboBox cb)
        {
            cb.DataSource = RoomDAO.Instance.LoadRoomList();
            cb.DisplayMember = "name";
        }
        void LoadServiceCategory()
        {
            List<ServiceCategoryDTO> listCategory = ServiceCategoryDAO.Instance.GetListCategory();
            cbbServiceCategory.DataSource = listCategory;
            cbbServiceCategory.DisplayMember = "name";
        }
        void LoadServiceListByCategoryID(int id)
        {
            List<ServiceDTO> listFood = ServiceDAO.Instance.GetListServiceByCategory(id);
            cbbService.DataSource = listFood;
            cbbService.DisplayMember = "name";
        }
     

        #endregion

        #region Events
        private void Btn_Click(object sender, EventArgs e)
        {
            
            int roomID = ((sender as Button).Tag as RoomDTO).ID;
            lstvBill.Tag = (sender as Button).Tag;
            ShowServiceBill(roomID);          
            ShowTimeBill(roomID);
            AddPriceOld(roomID);
            TotalPrice();
           
          


        }
        private void Btn_DoubleClick(object sender, EventArgs e)
        {

            
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
                this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfile af = new AccountProfile(loginAccount);
            af.UpdateAccount += Af_UpdateAccount;
            af.ShowDialog();
            
        }

        private void Af_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisPlayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.loginAccount = LoginAccount;
            a.InsertService += A_InsertService;
            a.UpdateService += A_UpdateService;
            a.DeleteService += A_DeleteService;

            a.InsertRoom += A_InsertRoom;
            a.UpdateRoom += A_UpdateRoom;
            a.DeleteRoom += A_DeleteRoom;

            a.InsertServiceCategory += A_InsertServiceCategory;
            a.UpdateServiceCategory += A_UpdateServiceCategory;
            a.DeleteServiceCategory += A_DeleteServiceCategory;

            a.InsertRoomCategory += A_InsertRoomCategory;
            a.UpdateRoomCategory += A_UpdateRoomCategory;
            a.DeleteRoomCategory += A_DeleteRoomCategory;
            a.ShowDialog();
        }

        private void A_DeleteRoomCategory(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);
            
        }

        private void A_UpdateRoomCategory(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);
        }

        private void A_InsertRoomCategory(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);
        }

        private void A_DeleteServiceCategory(object sender, EventArgs e)
        {
            LoadServiceCategory();
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);
            
            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
            LoadRoom();
        }

        private void A_UpdateServiceCategory(object sender, EventArgs e)
        {
            LoadServiceCategory();
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);

            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
        }

        private void A_InsertServiceCategory(object sender, EventArgs e)
        {
            LoadServiceCategory();
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);

            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
        }

        private void A_DeleteRoom(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);
        }

        private void A_UpdateRoom(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);

        }

        private void A_InsertRoom(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);

        }

        private void A_DeleteService(object sender, EventArgs e)
        {
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);
            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
            LoadRoom();
        }

        private void A_UpdateService(object sender, EventArgs e)
        {
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);
            if(lstvBill.Tag !=null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
        }

        private void A_InsertService(object sender, EventArgs e)
        {
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);
            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
        }

        private void rdAddFood_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rdSurcharge_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            AddTimeBill();
            RoomDTO room = lstvBill.Tag as RoomDTO;
            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
            int disCount = (int)nmrDiscount.Value;

            double totalPrice = float.Parse(txtToTalPriceTest.Text);

            double FinalTotalPrice = totalPrice - (totalPrice / 100) * disCount;

            string totalTime = txtAddTime.Text;
            float priceoldtime = float.Parse(txtTimeOldTest.Text);
            if(idBill !=-1) //bill đã có
            {
                if(MessageBox.Show(string.Format("Bạn có chắc muốn thanhe toán hóa đơn cho bàn {0}\n Tổng tiền - (Tổng Tiền / 100) x Giảm giá\n<=> {1} - ({1}/100) x {2} = {3}",room.Name, totalPrice,disCount, FinalTotalPrice),"Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, disCount, totalTime, priceoldtime,(float)FinalTotalPrice);
                    
                    ShowServiceBill(room.ID);
                }   
            }
            LoadRoom();
            ShowTimeBill(room.ID);
            AddPriceOld(room.ID);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            ServiceCategoryDTO selected = cb.SelectedItem as ServiceCategoryDTO;
            id = selected.ID;

            LoadServiceListByCategoryID(id);
        }
        private void cbbDeviceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;
            if(room==null)
            {
                MessageBox.Show("Hãy chọn bàn!!!");
                return; 
            }    
            
            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
            int Service = (cbbService.SelectedItem as ServiceDTO).ID;
            int countService = (int)nmrCountService.Value;
            int idRoom = (lstvBill.Tag as RoomDTO).ID;
           
            if (idBill == -1)//không có bill nào hết ;
            {
                BillDAO.Instance.InsertBill(room.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), Service, countService,idRoom); 
            }    
            else //Bill đã tồn tại
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, Service, countService,idRoom);
            }
            ShowServiceBill(room.ID);       
            TotalPrice();
            LoadRoom();
            ShowTimeBill(room.ID);
        }


        #endregion

        private void btnAddSurcharge_Click(object sender, EventArgs e)
        {
       
        }

        private void btnSwitchRoom_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;
            int id1 = (lstvBill.Tag as RoomDTO).ID;
            int id2 = (cbbSwitchRoom.SelectedItem as RoomDTO).ID;
            List<RoomDTO> list = RoomDAO.Instance.LoadRoomListByID(id2);
            foreach (RoomDTO item in list)
            {
                string f = item.Status;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển  {0} qua  {1}", (lstvBill.Tag as RoomDTO).Name, (cbbSwitchRoom.SelectedItem as RoomDTO).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {     
                    if (f=="Có Người")
                        {
                             MessageBox.Show(string.Format("{0} đã có người", (cbbSwitchRoom.SelectedItem as RoomDTO).Name));
                         }    
                    else 
                    {
                        RoomDAO.Instance.SwitchRoom(id1, id2);
                        RoomDAO.Instance.SwitchOldTimePrice(id1, id2);
                        LoadRoom();
                        ShowTimeBill(room.ID);
                        AddPriceOld(room.ID);
                    }

                }
            }
           
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;
           
            if (room == null)
            {
                MessageBox.Show("Hãy chọn bàn!!!");
                return;
            }

            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
           
            int idRoom = (lstvBill.Tag as RoomDTO).ID;
            if (idBill == -1)//không có bill nào hết ;
            {
                BillDAO.Instance.InsertStartBill(room.ID);
                
            }

        
            else //Bill đã tồn tại
            {
                MessageBox.Show("Phòng này đã bắt đầu tính giờ", "Thông báo");
                return;
            }
           
            ShowServiceBill(room.ID);
            TotalPrice();
            LoadRoom();
            ShowTimeBill(room.ID);

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFood_Click(this, new EventArgs());
        }

        private void bắtĐầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStart_Click(this, new EventArgs());
        }

        private void thànhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(this, new EventArgs());
        }

        private void chuyểnPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSwitchRoom_Click(this, new EventArgs());
        }
    }
}

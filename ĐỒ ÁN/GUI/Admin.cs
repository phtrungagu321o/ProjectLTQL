using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DTO;
using ĐỒ_ÁN.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN
{
    public partial class Admin : Form
    {
        BindingSource Servicelist = new BindingSource();
        BindingSource RoomList = new BindingSource();
        BindingSource ServiceCategoryList = new BindingSource();
        BindingSource RoomCategoryList = new BindingSource();
        BindingSource AccountList = new BindingSource();

        public AccountDTO loginAccount;
        public Admin()
        {
            InitializeComponent();

            dgvService.DataSource = Servicelist;
            dgvRoom.DataSource = RoomList;
            dgvServiceCategory.DataSource = ServiceCategoryList;
            dgvRoomCategory.DataSource = RoomCategoryList;
            dgvAccount.DataSource = AccountList;

            LoadLitsBillByDate(dtpFromTime.Value, dtpToTime.Value);
            loadlist();
            AddBinding();
            LoadCategory();

            LoadWaterMark();
            


        }
        void LoadWaterMark()
        {
            txtSearchServiceName.ForeColor = Color.LightGray;
            txtSearchServiceName.Text = "Vui lòng nhập tên dịch vụ cần tìm";
            txtSearchServiceName.Font = new Font(txtSearchServiceName.Font.Name, txtSearchServiceName.Font.Size, FontStyle.Italic);
            this.txtSearchServiceName.Leave += new System.EventHandler(this.TxtSearchServiceName_Leave);
            this.txtSearchServiceName.Enter += new System.EventHandler(this.TxtSearchServiceName_Enter);
        }

        private void TxtSearchServiceName_Enter(object sender, EventArgs e)
        {
            if (txtSearchServiceName.Text == "Vui lòng nhập tên dịch vụ cần tìm")
            {
                txtSearchServiceName.Text = "";
                txtSearchServiceName.ForeColor = Color.Black;
                txtSearchServiceName.Font = new Font(txtSearchServiceName.Font.Name, txtSearchServiceName.Font.Size, FontStyle.Bold);
            }
        }

        private void TxtSearchServiceName_Leave(object sender, EventArgs e)
        {
            if(txtSearchServiceName.Text=="")
            {
                txtSearchServiceName.Text = "Vui lòng nhập tên dịch vụ cần tìm";
                txtSearchServiceName.ForeColor = Color.Gray;
                txtSearchServiceName.Font = new Font(txtSearchServiceName.Font.Name, txtSearchServiceName.Font.Size, FontStyle.Italic);
            }    
        }

        void loadlist()
        {
            LoadLitsBillByDate(dtpFromTime.Value, dtpToTime.Value);
            LoadDateTimePickerBill();
            LoadListService();
            LoadListRoom();
            loadListServiceCategory();
            LoadListsRoomCategory();
            LoadListAccount();
        }
        void AddBinding()
        {
            AddServiceBinding();
            AddRoomBinding();
            AddServiceCategoryBinding();
            AddRoomSeviceBinding();
            AddAccountBinding();
        }
        void LoadCategory()
        {
            LoadCategoryIntoComboBox(cbbServiceCategory);
            loadRoomcategoryIntoCBB(cbbRoomcategory);
        }

        List<ServiceDTO> SearchNameService(string name)
        {
            List<ServiceDTO> listService = ServiceDAO.Instance.SearchServiceByName(name);

         
            return listService;

        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFromTime.Value = new DateTime(today.Year, today.Month, 1);
            dtpToTime.Value = dtpFromTime.Value.AddMonths(1).AddDays(-1);
        }
        void LoadLitsBillByDate(DateTime checkIn, DateTime checkOut)
        {

            dgvBill.DataSource = BillDAO.Instance.GetBillListByDateTime(checkIn, checkOut);
        }
        void LoadListService()
        {
             
            Servicelist.DataSource = ServiceDAO.Instance.GetlistService();
        }
        void LoadListRoom()
        {
            RoomList.DataSource = RoomDAO.Instance.LoadListRoom();
        }
        void loadListServiceCategory()
        {
            ServiceCategoryList.DataSource = ServiceCategoryDAO.Instance.GetListCategory();
        }
        void LoadListsRoomCategory()
        {
            RoomCategoryList.DataSource = RoomCategoryDAO.Instance.ListRoomCategory();
        }
        void LoadListAccount()
        {
            AccountList.DataSource = AccountDAO.Instance.GetlistAccount();
        }
        void AddAccountBinding()
        {
            txtAccountUser.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtAccountDislayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisPlayName", true, DataSourceUpdateMode.Never));
            nmrAccountType.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void AddServiceBinding()

        {
            txtServiceName.DataBindings.Add(new Binding("Text", dgvService.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtServiceID.DataBindings.Add(new Binding("Text", dgvService.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nudPrice.DataBindings.Add(new Binding("Value", dgvService.DataSource, "price", true, DataSourceUpdateMode.Never));
        }
        void AddRoomBinding()
        {
            txtRoomID.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtRoomName.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void AddServiceCategoryBinding()
        {
            txtIDServiceCategory.DataBindings.Add(new Binding("Text", dgvServiceCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtNameServiceCategory.DataBindings.Add(new Binding("Text", dgvServiceCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void AddRoomSeviceBinding()
        {
            txtIDRoomCategory.DataBindings.Add(new Binding("Text", dgvRoomCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtNameRoomCategory.DataBindings.Add(new Binding("Text", dgvRoomCategory.DataSource, "NameRoomCategory", true, DataSourceUpdateMode.Never));
            nudTime.DataBindings.Add(new Binding("value", dgvRoomCategory.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = ServiceCategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        void loadRoomcategoryIntoCBB(ComboBox cb)
        {
            cb.DataSource = RoomCategoryDAO.Instance.ListRoomCategory();
            cb.DisplayMember = "NameRoomCategory";
        }

        private void tp_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFoodName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadLitsBillByDate(dtpFromTime.Value, dtpToTime.Value);
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListService();
        }

        private void txtServiceID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvService.SelectedCells.Count > 0 && dgvService.SelectedCells[0].OwningRow.Cells["idServiceCategory"].Value!=null)
                {
                    int id = (int)dgvService.SelectedCells[0].OwningRow.Cells["idServiceCategory"].Value;//chọn ô đầu tiên trong danh sach category sau đó lấy cái dòng chưa ô đã chọn


                    ServiceCategoryDTO Servicecategory = ServiceCategoryDAO.Instance.GetCategory(id);
                    cbbServiceCategory.SelectedItem = Servicecategory;
                    int index = -1;
                    int i = 0;
                    foreach (ServiceCategoryDTO item in cbbServiceCategory.Items)
                    {
                        if (item.ID == Servicecategory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbbServiceCategory.SelectedIndex = index;
                }

            }
            catch {
                
            }

        }
        private void txtRoomID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoom.SelectedCells.Count > 0)
                {
                    int id = (int)dgvRoom.SelectedCells[0].OwningRow.Cells["idRoomCategory"].Value;

                    RoomCategoryDTO Roomcategory = RoomCategoryDAO.Instance.GetRoomCategoryByID(id);
                    cbbRoomcategory.SelectedItem = Roomcategory;
                    int index = -1;
                    int i = 0;
                    foreach (RoomCategoryDTO item in cbbRoomcategory.Items)
                    {
                        if (item.ID == Roomcategory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbbRoomcategory.SelectedIndex = index;

                }
            }
            catch { }
        }
        private void btnAddServiceCategory_Click(object sender, EventArgs e)
        {
            string name = txtNameServiceCategory.Text;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Thêm Loại {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (ServiceCategoryDAO.Instance.InsertServiceCategory(name))
                {
                    MessageBox.Show("Thêm danh mục dịch vụ thành công");
                    loadListServiceCategory();
                    LoadListService();
                    LoadCategoryIntoComboBox(cbbServiceCategory);
                    if (insertServiceCategory != null)
                        insertServiceCategory(this, new EventArgs());
            }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm!!");
                }
            }
            
        }
        private void btnDeleteServicecategory_Click(object sender, EventArgs e)
        {
            string name = txtNameServiceCategory.Text;
            int id = Convert.ToInt32(txtIDServiceCategory.Text);
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Xóa loại {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (ServiceCategoryDAO.Instance.DeleteServiceCategory(id))
                {
                    MessageBox.Show("Xóa danh mục dịch vụ thành công");
                    loadListServiceCategory();
                    LoadListService();
                    LoadCategoryIntoComboBox(cbbServiceCategory);
                    if (deleteServiceCategory != null)
                        deleteServiceCategory(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi Xóa!!");
                }
            }
        }
        private void btnUpdateServiceCategory_Click(object sender, EventArgs e)
        {
            string name = txtNameServiceCategory.Text;
            int id = Convert.ToInt32(txtIDServiceCategory.Text);
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Sửa loại này không ?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (ServiceCategoryDAO.Instance.UpdateServiceCategory(name,id))
                {
                    MessageBox.Show("Sủa danh mục dịch vụ thành công");
                    loadListServiceCategory();
                    LoadListService();
                    LoadCategoryIntoComboBox(cbbServiceCategory);
                    if (updateServiceCategory != null)
                        updateServiceCategory(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi Sửa!!");
                }
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txtServiceName.Text;
            int categoryID = (cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID;
            float price = (float)nudPrice.Value;
            if (ServiceDAO.Instance.InsertService(categoryID, name, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListService();
                if (insertService != null)
                    insertService(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            string name = txtServiceName.Text;
            int categoryID = (cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID;
            float price = (float)nudPrice.Value;
            int id = Convert.ToInt32(txtServiceID.Text);
            if (ServiceDAO.Instance.UpdateService(id, categoryID, name, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListService();
                if (updateService != null)
                {
                    updateService(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi Sủa thức ăn");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtServiceID.Text);
            if (ServiceDAO.Instance.DeleteService(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListService();
                if (deleteService != null)
                    deleteService(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xóa thức ăn");
            }

        }

        private event EventHandler insertService;
        public event EventHandler InsertService
        {
            add { insertService += value; }
            remove { insertService -= value; }
        }

        private event EventHandler updateService;
        public event EventHandler UpdateService
        {
            add { updateService += value; }
            remove { updateService -= value; }
        }
        private event EventHandler deleteService;
        public event EventHandler DeleteService
        {
            add { deleteService += value; }
            remove { deleteService -= value; }
        }

        private event EventHandler insertRoom;
        public event EventHandler InsertRoom
        {
            add { insertRoom += value; }
            remove { insertRoom -= value; }
        }
        private event EventHandler deleteRoom;
        public event EventHandler DeleteRoom
        {
            add { deleteRoom += value; }
            remove { deleteRoom -= value; }
        }
        private event EventHandler updateRoom;
        public event EventHandler UpdateRoom
        {
            add { updateRoom += value; }
            remove { updateRoom -= value; }
        }
        private event EventHandler insertServiceCategory;
        public event EventHandler InsertServiceCategory
        {
            add { insertServiceCategory += value; }
            remove { insertServiceCategory -= value; }
        }
        private event EventHandler updateServiceCategory;
        public event EventHandler UpdateServiceCategory
        {
            add { updateServiceCategory += value; }
            remove { updateServiceCategory -= value; }
        }
        private event EventHandler deleteServiceCategory;
        public event EventHandler DeleteServiceCategory
        {
            add { deleteServiceCategory += value; }
            remove { deleteServiceCategory -= value; }
        }
        private event EventHandler insertRoomCategory;
        public event EventHandler InsertRoomCategory
        {
            add { insertRoomCategory += value; }
            remove { insertRoomCategory -= value; }
        }
        private event EventHandler updateRoomCategory;
        public event EventHandler UpdateRoomCategory
        {
            add { updateRoomCategory += value; }
            remove { updateRoomCategory -= value; }
        }
        private event EventHandler deleteRoomCategory;
        public event EventHandler DeleteRoomCategory
        {
            add { deleteRoomCategory += value; }
            remove { deleteRoomCategory -= value; }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            if(txtSearchServiceName.Text=="")
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin Cần Tìm", "Thông báo");
            }

           Servicelist.DataSource=SearchNameService(txtSearchServiceName.Text);
        }

        private void btnShowRoom_Click(object sender, EventArgs e)
        {
            LoadListRoom();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            string name = txtRoomName.Text;
            int idCategory = (cbbRoomcategory.SelectedItem as RoomCategoryDTO).ID;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Thêm phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (RoomDAO.Instance.InsertRoom(name, idCategory))
                {
                    MessageBox.Show("Thêm phòng thành công");
                    LoadListRoom();
                    if (insertRoom != null)
                        insertRoom(this, new EventArgs()); 
                }
                else
                {
                    MessageBox.Show("có lỗi khi thêm Phòng!!!");
                }
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(txtRoomID.Text);
            string name = txtRoomName.Text;

            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn xóa phòng {0} không ?",name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (RoomDAO.Instance.DeleteRoom(id))
                {
                    MessageBox.Show("Xóa phòng thành công");
                    LoadListRoom();
                    if (deleteRoom != null)
                        deleteRoom(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("có lỗi khi Xóa Phòng!!!");
                }
            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            string name = txtRoomName.Text;           
            int idCategory = (cbbRoomcategory.SelectedItem as RoomCategoryDTO).ID;
            int id = Convert.ToInt32(txtRoomID.Text);
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn sửa không ?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (RoomDAO.Instance.UpdateRoom(name, idCategory, id))
                {
                    MessageBox.Show("Sửa phòng thành công");
                    LoadListRoom();
                    if (updateRoom != null)
                        updateRoom(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("có lỗi khi Sửa Phòng!!!");
                }
            }
        }

        private void btnShowServiceCategory_Click(object sender, EventArgs e)
        {
            loadListServiceCategory();
        }

        private void btnShowRoomCategory_Click(object sender, EventArgs e)
        {
            LoadListsRoomCategory();
        }

        private void btnAddRoomCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDRoomCategory.Text);
            string name = txtNameRoomCategory.Text;
            float price = (float)nudTime.Value;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Thêm phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (RoomCategoryDAO.Instance.InsertRoomCategory(name,price))
                {
                    MessageBox.Show("Thêm phòng thành công");
                    LoadListsRoomCategory();
                    LoadListRoom();
                   
                    if (insertRoomCategory!=null)
                    {
                        insertRoomCategory(this, new EventArgs());
                    }    
                }
                else
                {
                    MessageBox.Show("có lỗi khi Thêm Phòng!!!");
                }
            }
        }

        private void btnUpdateRoomCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDRoomCategory.Text);
            string name = txtNameRoomCategory.Text;
            float price = (float)nudTime.Value;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Thêm phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (RoomCategoryDAO.Instance.UpdateRoomCategory(name,id,price))
                {
                    MessageBox.Show("Sửa phòng thành công");
                    LoadListsRoomCategory();
                    LoadListRoom();
                    
                    if (updateRoomCategory != null)
                        updateRoomCategory(this, new EventArgs());
                    
                }
                else
                {
                    MessageBox.Show("có lỗi khi Sửa Phòng!!!");
                }
            }
        }

        private void btnDeleteRoomCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDRoomCategory.Text);
            string name = txtNameRoomCategory.Text;
            float price = (float)nudTime.Value;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Xóa phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (RoomCategoryDAO.Instance.DeteleRoomCategory(id))
                {
                    MessageBox.Show(" Xóa thành công");
                    LoadListsRoomCategory();
                    LoadListRoom();
                   
                    if (deleteRoomCategory != null)
                        deleteRoomCategory(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("có lỗi khi Xóa Phòng!!!");
                }
            }
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string user=txtAccountUser.Text;
            string displayname = txtAccountDislayName.Text;
            int type =(int)nmrAccountType.Value;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Thêm tài khoản {0} không ?", user), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                List<AccountDTO> list = AccountDAO.Instance.GetAccount();
                foreach (AccountDTO item in list)
                {
                    if (user == item.UserName)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại");
                        return;
                    }
                }
                if (AccountDAO.Instance.InsertAccount(user, displayname, type))
                {
                    MessageBox.Show("Thêm Tài Khoản thành công");
                    LoadListAccount();
                }
                else
                {
                    MessageBox.Show("Thêm Tài Khoản thất bại");
                }
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string user = txtAccountUser.Text;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Xóa tài khoản {0} không ?", user), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (loginAccount.UserName.Equals(user))
                {
                    MessageBox.Show("Tài Khoản đang chạy");
                    return;
                }
                if (AccountDAO.Instance.DeleteAccount(user))
                {
                    MessageBox.Show("Xóa Tài Khoản thành công");
                    LoadListAccount();
                }
                else
                {
                    MessageBox.Show("Xóa Tài Khoản thất bại");
                }
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string user = txtAccountUser.Text;
            string displayname = txtAccountDislayName.Text;
            int type = (int)nmrAccountType.Value;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn Sửa Tài Khoản này không ?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (AccountDAO.Instance.UpdateAccount(user, displayname, type))
                {
                    MessageBox.Show("Cập nhập Tài Khoản thành công");
                    LoadListAccount();
                }
                else
                {
                    MessageBox.Show("Không được sửa tài khoản");
                }
            }
        }

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            string user = txtAccountUser.Text;
            DialogResult t;
            t = MessageBox.Show(string.Format("Bạn có muốn đặt lại mặt khẩu cho tài khoản {0} không ?", user), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                if (AccountDAO.Instance.ResetPassWord(user))
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công");

                }
                else
                {
                    MessageBox.Show("Đặt lại mật khẩu thất bại");
                }
            }
        }

        private void btnFristPage_Click(object sender, EventArgs e)
        {
            txtNumPage.Text = "1";

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetBillNumByDateTime(dtpFromTime.Value, dtpToTime.Value);
            int LastPage = sumRecord / 10;
            if(sumRecord % 10 !=0)
            {
                LastPage++;
            }
            txtNumPage.Text = LastPage.ToString();
        }

        private void txtNumPage_TextChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDateTimeAndPage(dtpFromTime.Value, dtpToTime.Value, Convert.ToInt32(txtNumPage.Text));
        }

        private void btnPervious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtNumPage.Text);

            if(page>1)
            {
                page--;
            }
            txtNumPage.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtNumPage.Text);
            int sumRecord = BillDAO.Instance.GetBillNumByDateTime(dtpFromTime.Value, dtpToTime.Value);

            if (page < sumRecord)
                page++;
            txtNumPage.Text = page.ToString(); 
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
           
            
        }

        private void rpViewer_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
            ReportBill rp = new ReportBill();
            rp.Checkin = dtpFromTime.Value;
            rp.CheckOut = dtpToTime.Value;
            rp.ShowDialog();







        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
          
        }
    }
}

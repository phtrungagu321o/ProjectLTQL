using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    
    public class DataProvider
    {
        
        private static DataProvider instance;/*nếu bất cứ thứ gì thông qua instance mà lấy ra thì là duy nhất vì nó chỉ tạo nó 1 lần*/
        
        public static DataProvider Instance
        {
            get {  if (instance == null) instance = new DataProvider(); return instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }

        private string connectionSTR = @"Data Source=DESKTOP-BSHIH1R;Initial Catalog=QuanLiPhongKaraoke;Integrated Security=True";

        
        public DataTable ExcuteQuery(String query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR)) // kết nói từ client đến server
                                                                                //kết thúc khối lệnh dữ liệu connection sẽ tự được giải phóng
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query/*câu lệnh truy vấn cần thực hiện*/, connection);// câu truy vấn dùng để thực thi

               if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]); /*add N para*/
                            i++;
                        }
                    }
                }
               
                SqlDataAdapter adapter = new SqlDataAdapter(command);//Lệnh trung gian thực hiện câu truy vấn để lấy dữ liệu

                adapter.Fill(data);
                connection.Close();//tranh việc nhiều đối tượng cùng đổ về =>lỗi
            }

            return data;

        }
        public int ExecuteNonQuery(String query, object[] parameter = null)/* trả ra kết quả thành công hay không*/
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR)) // kết nói từ client đến server
                                                                                //kết thúc khối lệnh dữ liệu connection sẽ tự được giải phóng
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);// câu truy vấn dùng để thực thi

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();//tranh việc nhiều đối tượng cùng đổ về =>lỗi
            }

            return data;

        }//gọi các lệnh sql,store,trat về số row bị tác động (insert, Up, delete
        public object ExecuteScalar(String query, object[] parameter = null)/* trả về cái ô đầu tiên trong bảng kết quả*/
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR)) // kết nói từ client đến server
                                                                                //kết thúc khối lệnh dữ liệu connection sẽ tự được giải phóng
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);// câu truy vấn dùng để thực thi

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();//tranh việc nhiều đối tượng cùng đổ về =>lỗi
            }

            return data;

        }//thực hiện lệnh và trả về giá trị đơn
    }
}

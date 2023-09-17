using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

// tìm hiểu kiến trúc
// lớp biểu diễn cơ sở dữ liệu (DataSet)
// lớp biểu diễn bảng (DataTable)

// DataSet thì nó như cơ sở dữ liệu luôn

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
                THÔNG TIN VỀ DATA SET

                DataSet là một cấu trúc phức tạp
                là thành phần cơ bản của ADO.NET
                
                Nó ánh xạ cơ sở dữ liệu
                thành các đối tượng trong bộ nhớ
                
                DataSet chứa trong nó
                là tập hợp các đối tượng DataTable

                Cách tạo đối tượng:
                DataSet dt = new DataSet();
            */


            /*
                THÔNG TIN VỀ DATA TABLE

                DataTable là đối tượng chứa dữ liệu
                
                Nó có tên

                Nó có các dòng, các cột

                Qua đó, nó là ánh xạ của một bảng
                trong cơ sở dữ liệu
            */


            // tạo đối tượng DataSet
            DataSet dt_DataSet = new DataSet();


            // tạo đối tượng DataTable
            // với tên bảng là "NHAN_VIEN"
            DataTable dt_DataTable = new DataTable("NHAN_VIEN");


            // thêm các cột vào bảng
            dt_DataTable.Columns.Add("Id");
            dt_DataTable.Columns.Add("Ten dang nhap");
            dt_DataTable.Columns.Add("Mat khau");


            // thêm các bản ghi vào bảng
            // hay còn gọi là thêm các dòng vào bảng
            dt_DataTable.Rows.Add(1, "admin", "123456");
            dt_DataTable.Rows.Add(2, "nva", "112233");
            dt_DataTable.Rows.Add(3, "nvb", "66668888");
            dt_DataTable.Rows.Add(4, "nvc", "9999abcd");
            dt_DataTable.Rows.Add(5, "nvd", "abcd_efgh");


            // in ra tên bảng
            Console.WriteLine($"---------- DataTable: Bang {dt_DataTable.TableName} ----------");


            // in ra tên cột
            Console.Write($"{dt_DataTable.Columns[0].ColumnName,-10}");
            Console.Write($"{dt_DataTable.Columns[1].ColumnName,-25}");
            Console.Write($"{dt_DataTable.Columns[2].ColumnName,-20}");


            // dòng code này để xuống dòng
            Console.WriteLine();


            // in ra các bản ghi
            // hoặc có thể nói là in ra các dòng
            for (int i = 0; i < dt_DataTable.Rows.Count; i++)
            {
                /*
                    trong các dòng code bên dưới
                    tôi sử dụng các số -10, -25, -20
                    có tác dụng căn lề bên trái
                    và độ rộng để in dữ liệu ra màn hình là 10, 25, 20
                */


                // cách 1:
                // sử dụng index để lấy ra cột có index = 0
                Console.Write($"{dt_DataTable.Rows[i][0],-10}");

                // cách 2:
                // sử dụng tên cột
                Console.Write($"{dt_DataTable.Rows[i]["Ten dang nhap"],-25}");

                Console.Write($"{dt_DataTable.Rows[i]["Mat khau"],-20}");

                // dòng code này để xuống dòng
                Console.WriteLine();
            }


            // ví dụ bạn muốn truy cập
            // đến dữ liệu ở dòng 2 (thì index của nó sẽ bằng 1)
            // cột mật khẩu
            Console.WriteLine("\n\nTruy cap den dong 2, cot \"Mat khau\":");
            Console.WriteLine($"Rows[1][\"Mat khau\"] = {dt_DataTable.Rows[1]["Mat khau"]}");


            // DataTable có thể đưa vào trong DataSet
            // lúc này cái đối tượng DataTable
            // được thêm đầu tiên
            // thì nó sẽ có index = 0
            dt_DataSet.Tables.Add(dt_DataTable);


            // sử dụng DataSet
            // để in ra màn hình
            // các bản ghi


            // in ra tên bảng
            // lúc lấy ra bảng
            // nhớ thêm index = 0
            Console.WriteLine($"\n\n---------- DataSet: Bang {dt_DataSet.Tables[0].TableName} ----------");


            // in ra tên cột

            // cách 1:
            // sử dụng "index" để truy cập bảng
            // trong đối tượng DataSet
            Console.Write($"{dt_DataSet.Tables[0].Columns[0].ColumnName,-10}");

            // cách 2:
            // sử dụng "tên bảng" để truy cập bảng
            // trong đối tượng DataSet
            Console.Write($"{dt_DataSet.Tables["NHAN_VIEN"].Columns[1].ColumnName,-25}");

            Console.Write($"{dt_DataSet.Tables[0].Columns[2].ColumnName,-20}");


            // dòng code này để xuống dòng
            Console.WriteLine();


            // in ra các bản ghi
            // hoặc có thể nói là in ra các dòng
            for (int i = 0; i < dt_DataSet.Tables["NHAN_VIEN"].Rows.Count; i++)
            {
                /*
                    trong các dòng code bên dưới
                    tôi sử dụng các số -10, -25, -20
                    có tác dụng căn lề bên trái
                    và độ rộng để in dữ liệu ra màn hình là 10, 25, 20
                */


                // cách 1:
                // sử dụng index để lấy ra cột có index = 0
                Console.Write($"{dt_DataSet.Tables["NHAN_VIEN"].Rows[i][0],-10}");

                // cách 2:
                // sử dụng tên cột
                // chỗ này tên cột là "Ten dang nhap"
                Console.Write($"{dt_DataSet.Tables["NHAN_VIEN"].Rows[i]["Ten dang nhap"],-25}");

                // còn chỗ này
                // thì tên cột là "Mat khau"
                Console.Write($"{dt_DataSet.Tables["NHAN_VIEN"].Rows[i]["Mat khau"],-20}");


                // dòng code này để xuống dòng
                Console.WriteLine();
            }


            // bảng nhân viên
            // là bảng có chỉ số index = 0
            // trong đối tượng DataSet
            Console.WriteLine($"\n\n=> Bang {dt_DataSet.Tables[0]} la Tables[0] cua doi tuong DataSet");
        }
    }
}
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using QuanLySinhVien;

namespace QuanLySinhVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding UTP8 = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            NhapSinhVien nhapSinhVien = new NhapSinhVien();
            while (true)
            {
                Console.WriteLine("Quản lý thông tin sinh viên");
                Console.WriteLine("1. Thêm thông tin sinh viên");
                Console.WriteLine("2. Cập nhật thông tin sinh viên");
                Console.WriteLine("3. Sắp sếp sinh viên theo điểm trung bình");
                Console.WriteLine("4. Tìm kiếm thông tin theo tên");
                Console.WriteLine("5. Xóa sinh viên theo ID");
                Console.WriteLine("6. Sắp xếp sinh viên theo tên");
                Console.WriteLine("7. Hiển thị danh sách sinh viên");
                Console.WriteLine("8. Sắp xếp sinh viên theo ID");
                Console.WriteLine("0. Thoát chương trình");




                int key = Convert.ToInt32(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        Console.WriteLine("\nThêm sinh viên");
                        nhapSinhVien.GhiSinhVien();
                        Console.WriteLine("Thêm sinh viên thành công");
                        break;
                    case 2:
                        int id;
                        Console.WriteLine("\nCập nhật thông tin sinh viên");
                        Console.WriteLine("\nNhập ID");
                        id = Convert.ToInt32(Console.ReadLine());
                        nhapSinhVien.UpdateThongTinSinhVien(id);
                        break;
                    case 3:
                        if (nhapSinhVien.SoLuongSinhVien() > 0) 
                        {
                            Console.WriteLine("\nSắp xếp sinh viên theo điểm trung binh");
                            nhapSinhVien.SortByDiemTrungBinh();
                            nhapSinhVien.ShowSinhVien(nhapSinhVien.getListSinhVien());                          
                        }

                        else
                        {
                            Console.WriteLine("\nDanh sách sinh viên trống");
                        }
                        break;
                    case 4:
                        if (nhapSinhVien.SoLuongSinhVien() > 0)
                        {
                            Console.WriteLine("\n. Tìm kiếm sinh viên theo tên.");
                            Console.WriteLine("\nNhập tên để tìm kiếm : ");
                            string name = Convert.ToString(Console.ReadLine());
                            List<QuanLySinhVien.NhapSinhVien.SinhVien> searchResult = nhapSinhVien.FindByName(name);
                            nhapSinhVien.ShowSinhVien(searchResult);
                        }

                        else
                        {
                            Console.WriteLine("\nDanh sách sinh viên trống");
                        }
                        break;
                    case 5:
                        if (nhapSinhVien.SoLuongSinhVien() > 0)
                        {
                            int Id;
                            Console.WriteLine("\n. Xóa sinh viên.");
                            Console.WriteLine("\nNhập ID: ");
                            Id = Convert.ToInt32(Console.ReadLine());
                            if (nhapSinhVien.DeleteById(Id))
                            {
                                Console.WriteLine("\nSinh viên có ID = {0} đã bị xóa.", Id);    
                            }
                        }
                        break;
                    case 6:
                        if (nhapSinhVien.SoLuongSinhVien() > 0)
                        {
                            nhapSinhVien.ShortByName();
                            nhapSinhVien.ShowSinhVien(nhapSinhVien.getListSinhVien());
                        }
                        break;
                    case 7:
                        if(nhapSinhVien.SoLuongSinhVien() > 0)
                        {
                            Console.WriteLine("\nHiển thị số lượng sinh viên");
                            nhapSinhVien.ShowSinhVien(nhapSinhVien.getListSinhVien());
                        }

                        else
                        {
                            Console.WriteLine("\nDanh sách sinh viên trống!");
                        }
                        break;
                    case 8:
                        if (nhapSinhVien.SoLuongSinhVien() > 0)
                        {
                            Console.WriteLine("\nSắp xếp sinh viên theo ID.");
                            nhapSinhVien.SortById();
                            nhapSinhVien.ShowSinhVien(nhapSinhVien.getListSinhVien());
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nBạn đã chọn thoát chương trình");
                        return;                      
                    default:
                        Console.WriteLine("\nKhông có chức năng này");
                        Console.WriteLine("\nHãy chọn chức năng có trong Menu");    
                        break;
                }
            }
        }
    }
}
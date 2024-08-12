using System.Security.Cryptography.X509Certificates;

namespace QuanLySinhVien
{
    public class NhapSinhVien
    {
        public class SinhVien
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
            public int Age { get; set; }
            public double diemToan { get; set; }
            public double diemLy { get; set; }
            public double diemHoa { get; set; }
            public double diemTB { get; set; }
            public string hocLuc { get; set; }
        }
        //ham tao ID tang dan cho sinh vien
        public List<SinhVien> listSinhVien = null;

        public NhapSinhVien()
        {
            listSinhVien = new List<SinhVien>();
        }

        private int GenerateID()
        {
            int max = 1;
            if (listSinhVien != null && listSinhVien.Count > 0)
            {
                max = listSinhVien[0].ID;
                foreach (SinhVien sv in listSinhVien)
                {
                    if (max < sv.ID)
                    {
                        max = sv.ID;
                    }
                    max++;
                }
                return max;
            }
            return 0;
        }
        public int SoLuongSinhVien()
        {
            int count = 0;
            if (listSinhVien != null)
            {
                count = listSinhVien.Count;
            }
            return count;
        }
        //ham nhap thong tin sinh vien-------------------------------------------
        public void GhiSinhVien()
        {
            SinhVien sv = new SinhVien();
            sv.ID = GenerateID();
            Console.WriteLine("Nhap ten sinh vien : ");
            sv.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap gioi tinh sinh vien : ");
            sv.Sex = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap tuoi cua sinh vien : ");
            sv.Age = int.Parse(Console.ReadLine());

            Console.Write("Nhap diem Toan cua sinh vien : ");
            sv.diemToan = double.Parse(Console.ReadLine());

            Console.Write("Nhap diem Ly cua sinh vien : ");
            sv.diemLy = double.Parse(Console.ReadLine());

            Console.Write("Nhap diem Hoa cua sinh vien : ");
            sv.diemHoa = double.Parse(Console.ReadLine());

            tinhdtb(sv);
            XepLoaiHocLuc(sv);
            listSinhVien.Add(sv);
        }
        //ham tinh diem trung binh sinh vien-------------------------------------------------------------------
        void tinhdtb(SinhVien sv)
        {
            double diemTB = (sv.diemToan + sv.diemLy + sv.diemHoa) / 3;
            sv.diemTB = Math.Round(diemTB, 2, MidpointRounding.AwayFromZero);
        }

        //ham xep loai hoc luc cho sinh vien--------------------------------------------------------------------
        private void XepLoaiHocLuc(SinhVien sv)
        {
            if (sv.diemTB >= 8)
            {
                sv.hocLuc = "Gioi";
            }
            else if (sv.diemTB >= 6.5)
            {
                sv.hocLuc = "Kha";
            }
            else if (sv.diemTB >= 5)
            {
                sv.hocLuc = "Trung binh";
            }
            else
            {
                sv.hocLuc = "Yeu";
            }
        }

        //ham update thong tin sinh vien----------------------------------------------------------------------
        private SinhVien FindByID(int ID)
        {
            return listSinhVien.Find(sv => sv.ID == ID);
        }
        public void UpdateThongTinSinhVien(int ID)
        {
            SinhVien sv = FindByID(ID);
            if (sv != null)
            {
                Console.WriteLine("Nhap ten sinh vien : ");
                string name = Console.ReadLine();
                if (name != null && name.Length > 0)
                {
                    sv.Name = name;
                }

                Console.WriteLine("Nhap gioi tinh sinh vien : ");
                string sex = Console.ReadLine();
                if (sex != null && sex.Length > 0)
                {
                    sv.Sex = sex;
                }

                Console.WriteLine("Nhap tuoi sinh vien : ");
                string ageStr = Convert.ToString(Console.ReadLine());
                if (ageStr != null && ageStr.Length > 0)
                {
                    sv.Age = int.Parse(ageStr);
                }

                Console.WriteLine("Nhap diem Toan cua sinh vien : ");
                string diemToanStr = Convert.ToString(Console.ReadLine());
                if (diemToanStr != null && diemToanStr.Length > 0)
                {
                    sv.diemToan = Convert.ToDouble(diemToanStr);
                }

                Console.WriteLine("Nhap diem Ly cua sinh vien : ");
                string diemLyStr = Convert.ToString(Console.ReadLine());
                if (diemLyStr != null && diemLyStr.Length > 0)
                {
                    sv.diemLy = Convert.ToDouble(diemLyStr);
                }

                Console.WriteLine("Nhap diem Hoa cua sinh vien : ");
                string diemHoaStr = Convert.ToString(Console.ReadLine());
                if (diemHoaStr != null && diemHoaStr.Length > 0)
                {
                    sv.diemHoa = Convert.ToDouble(diemHoaStr);
                }
            }
        }

        //Hàm sắp xếp sinh viên theo điểm trung binh---------------------------------------------------------------------
        public void SortByDiemTrungBinh()
        {
            listSinhVien.Sort(delegate(SinhVien sv1, SinhVien sv2)
            {
                return sv1.diemTB.CompareTo(sv2.diemTB);
            });
        }

        public void ShowSinhVien(List<SinhVien> listSV)
        {
            // hien thi tieu de cot
            Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                  "ID", "Name", "Sex", "Age", "Toan", "Ly", "Hoa", "Diem TB", "Hoc Luc");
            // hien thi danh sach sinh vien------------------------------------------------------------------------------
            if (listSV != null && listSV.Count > 0)
            {
                foreach (SinhVien sv in listSV)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                                      sv.ID, sv.Name, sv.Sex, sv.Age, sv.diemToan, sv.diemLy, sv.diemHoa,
                                      sv.diemTB, sv.hocLuc);
                }
            }
            Console.WriteLine();
        }

        //Tim sinh vien theo ten----------------------------------------------------------
        public List<SinhVien> FindByName(String keyword)
        {
            List<SinhVien> searchResult = new List<SinhVien>();
            if (listSinhVien != null && listSinhVien.Count > 0)
            {
                foreach (SinhVien sv in listSinhVien)
                {
                    if (sv.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(sv);
                    }
                }
            }
            return searchResult;
        }

        public List<SinhVien> getListSinhVien()
        {
            return listSinhVien;
        }

        //Hàm xóa sinh viên theo ID--------------------------------------------------
        public bool DeleteById(int ID)
        {
            bool IsDeleted = false;
            SinhVien sv = FindByID(ID);
            if (sv != null)
            {
                IsDeleted = listSinhVien.Remove(sv);
            }
            return IsDeleted;
        }

        //Sắp xếp sinh viên theo tên----------------------------------------------
        public void ShortByName()
        {
            listSinhVien.Sort(delegate (SinhVien sv1, SinhVien sv2)
            {
                return sv1.Name.CompareTo(sv2.Name);
            }
            );
        }

        public void SortById()
        {
            listSinhVien.Sort(delegate (SinhVien sv1, SinhVien sv2)
            {
                return sv1.ID.CompareTo(sv2.ID);
            });
        }
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static string[] tenBanh = { "Banh mi", "Banh chuoi", "Banh su", "Banh trung" };
    static double[] giaBanh = { 10000, 5000, 15000, 50000 };

    static int tongDon = 0;
    static double tongDoanhThu = 0;
    static int demDonLon = 0;
    static int demDonThuong = 0;

    static void Main(string[] args)
    {
        Console.WriteLine(" Chao mung den voi he thong cua tiem banh");
        Console.WriteLine("Go 'exit' de thoat chuong trinh\n");

        while (true)
        {
            HienThiMenu();

            Console.Write("Nhap ten banh muon mua: ");
            string ten = Console.ReadLine();
            if (ten.ToLower() == "exit") break;

            int index = Array.FindIndex(tenBanh, b => b.ToLower() == ten.ToLower());
            if (index == -1)
            {
                Console.WriteLine(" Banh khong ton tai. Vui long thu lai.");
                continue;
            }

            Console.Write("Nhap so luong: ");
            string slInput = Console.ReadLine();
            if (slInput.ToLower() == "exit") break;

            if (!int.TryParse(slInput, out int soLuong) || soLuong <= 0)
            {
                Console.WriteLine(" So luong khong hop le. Vui long thu lai.");
                continue;
            }

            double tongTien = TinhTien(ten, soLuong);
            string loaiDon = XepLoaiDon(tongTien);

            HienThiThongTin(ten, soLuong, tongTien, loaiDon);

            tongDon++;
            tongDoanhThu += tongTien;
            if (loaiDon == "Don lon") demDonLon++; else demDonThuong++;

            Console.WriteLine("\n--- Don hang tiep theo hoac go 'exit' de dung ---\n");
        }

        Console.WriteLine("\n THONG KE NGAY HOM NAY:");
        Console.WriteLine($"Tong so đon hang: {tongDon}");
        Console.WriteLine($"Tong doanh thu: {tongDoanhThu} VND");
        Console.WriteLine($"So don lon: {demDonLon}");
        Console.WriteLine($"So đon thuong: {demDonThuong}");
    }

    static void HienThiMenu()
    {
        Console.WriteLine(" Danh sach banh hien co:");
        for (int i = 0; i < tenBanh.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {tenBanh[i]} - {giaBanh[i]} VND");
        }
        Console.WriteLine();
    }

    static double TinhTien(string tenBanh, int soLuong)
    {
        int index = Array.FindIndex(Program.tenBanh, b => b.ToLower() == tenBanh.ToLower());
        return giaBanh[index] * soLuong;
    }

    static int TinhTien(int gia, int soLuong)
    {
        return gia * soLuong;
    }

    static string XepLoaiDon(double tongTien)
    {
        return tongTien > 100000 ? "Don lon" : "Don thuong";
    }

    static void HienThiThongTin(string tenBanh, int soLuong, double tongTien, string loaiDon)
    {
        Console.WriteLine("\n Chi tiet don hang:");
        Console.WriteLine($"- Banh: {tenBanh}");
        Console.WriteLine($"- So luong: {soLuong}");
        Console.WriteLine($"- Tong tien: {tongTien} VND");
        Console.WriteLine($"- Loai don: {loaiDon}");
    }
}
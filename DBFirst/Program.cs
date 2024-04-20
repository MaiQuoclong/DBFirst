using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DBFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new YourDbContext())
            {
                context.Database.EnsureCreated();

                var sinhViens = NhapDanhSachSinhVien();

                context.SinhViens.AddRange(sinhViens);
                context.SaveChanges();

                Console.WriteLine("danh sach sinh vien sau khi them:");
                foreach (var sv in context.SinhViens)
                {
                    Console.WriteLine($"ID: {sv.SinhVienId}, Ten: {sv.Ten}, Tuoi: {sv.Tuoi}");
                }
            }
        }

        static List<SinhVien> NhapDanhSachSinhVien()
        {
            var sinhViens = new List<SinhVien>();

            Console.WriteLine("Nhap danh sach sinh vien:");
            while (true)
            {
                var sinhVien = new SinhVien();

                Console.Write("Nhap ten sinh vien ( de trong neu ket thuc ): ");
                string ten = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ten))
                    break;

                sinhVien.Ten = ten;

                Console.Write("Nhap tuoi: ");
                if (!int.TryParse(Console.ReadLine(), out int tuoi))
                {
                    Console.WriteLine("Tuoi khong hop le, xin nhap lai.");
                    continue;
                }
                sinhVien.Tuoi = tuoi;

                sinhViens.Add(sinhVien);
            }

            return sinhViens;
        }
    }
}

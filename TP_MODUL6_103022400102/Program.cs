using System;
using System.Diagnostics;

namespace TP_MODUL6_103022400102
{
    public class SayaMusicTrack 
    {
        private int id;
        private int playCount;
        private string title;

        public SayaMusicTrack(string title)
        {
            Debug.Assert(title != null, "Judul tidak boleh null");
            Debug.Assert(title.Length <= 100, "Judul track memiliki panjang maksimal 100 karakter");

            this.title = title;
            this.playCount = 0;

            Random random = new Random();
            this.id = random.Next(10000, 1000000);
        }

        public void IncreasePlayCount(int count)
        {
            Debug.Assert(count <= 10000000, "Jumlah peningkatan play count tidak boleh melebihi 1 juta");
            Debug.Assert(count >= 0, "Jumlah peningkatan play count tidak boleh negatif");

            try
            {
                checked
                {
                    this.playCount += count;
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"\n[Error]: Terjadi overflow saat menambahkan play count! {e.Message}");
                Console.WriteLine($"Tidak dapat menambahkan {count} ke total saat ini ({this.playCount}).\n");
            }
        }
        public void PrintTrackDetails()
        {
            Console.WriteLine($"Track ID    : {this.id}");
            Console.WriteLine($"Title       : {this.title}");
            Console.WriteLine($"Play Count  : {this.playCount}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PENGUJIAN NORMAL ===");
            SayaMusicTrack track1 = new SayaMusicTrack("Lagu Konstruksi Perangkat Lunak");
            track1.PrintTrackDetails();

            track1.IncreasePlayCount(5000000);
            track1.PrintTrackDetails();

            Console.WriteLine("\n=== PENGUJIAN EXCEPTION & OVERFLOW ===");
            Console.WriteLine("Melakukan penambahan play count dengan for loop...");
            
            
            for (int i = 0; i < 300; i++)
            {
                track1.IncreasePlayCount(10000000);
            }
            Console.WriteLine("Program berhasil melewati blok exception tanpa terhenti.");
            track1.PrintTrackDetails();
        }
    }
}
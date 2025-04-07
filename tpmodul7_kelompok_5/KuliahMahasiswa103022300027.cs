using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Course
{
    public string code { get; set; }
    public string name { get; set; }
}

public class CourseData
{
    public List<Course> courses { get; set; }
}

public class KuliahMahasiswa103022300027
{
    public void ReadJSON()
    {
        string jsonFileName = "C:\\Users\\ASUS\\source\\repos\\tpmodul7_kelompok_5\\tpmodul7_kelompok_5\\tp7_2_103022300027.json";
        try
        {
            string jsonString = File.ReadAllText(jsonFileName);
            CourseData dataKuliah = JsonSerializer.Deserialize<CourseData>(jsonString);
            if (dataKuliah != null && dataKuliah.courses != null)
            {
                Console.WriteLine("Daftar mata kuliah yang diambil:");
                for (int i = 0; i < dataKuliah.courses.Count; i++)
                {
                    Course matkul = dataKuliah.courses[i];
                    Console.WriteLine($"MK {i + 1} {matkul.code} - {matkul.name}");
                }
            }
            else
            {
                Console.WriteLine("Gagal melakukan deserialisasi data JSON atau daftar mata kuliah kosong.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File JSON '{jsonFileName}' tidak ditemukan.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error saat parsing JSON: {ex.Message}. Pastikan format JSON valid.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi error: {ex.Message}");
        }
    }
}
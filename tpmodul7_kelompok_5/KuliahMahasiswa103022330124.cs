using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Course103022330124
{
    public string code { get; set; }
    public string name { get; set; }
}

public class CourseData103022330124
{
    public List<Course103022330124> courses { get; set; }
}

public class KuliahMahasiswa103022330124
{
    public void ReadJSON()
    {
        string jsonFileName = "tp7_2_103022330124.json";
        try
        {
            string jsonString = File.ReadAllText(jsonFileName);
            CourseData103022330124 dataKuliah = JsonSerializer.Deserialize<CourseData103022330124>(jsonString);
            if (dataKuliah != null && dataKuliah.courses != null)
            {
                Console.WriteLine("Daftar mata kuliah yang diambil:");
                for (int i = 0; i < dataKuliah.courses.Count; i++)
                {
                    Course103022330124 matkul = dataKuliah.courses[i];
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
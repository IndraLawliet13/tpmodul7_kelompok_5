using System;
using System.IO;
using System.Text.Json;

public class NamaMahasiswa
{
    public string depan { get; set; }
    public string belakang { get; set; }
}

public class MahasiswaData
{
    public NamaMahasiswa nama { get; set; }
    public string nim { get; set; }
    public string fakultas { get; set; }
}

public class DataMahasiswa103022300017
{
    public void ReadJSON()
    {
        string jsonFileName = "tp7_1_103022300017.json";
        try
        {
            string jsonString = File.ReadAllText(jsonFileName);
            MahasiswaData dataMahasiswa = JsonSerializer.Deserialize<MahasiswaData>(jsonString);
            if (dataMahasiswa != null)
            {
                Console.WriteLine($"Nama {dataMahasiswa.nama.depan} {dataMahasiswa.nama.belakang} dengan nim {dataMahasiswa.nim} dari fakultas {dataMahasiswa.fakultas}");
            }
            else
            {
                Console.WriteLine("Gagal melakukan deserialisasi data JSON.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File JSON '{jsonFileName}' tidak ditemukan.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error saat parsing JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi error: {ex.Message}");
        }
    }
}
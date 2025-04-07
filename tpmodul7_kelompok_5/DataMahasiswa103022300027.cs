using System;
using System.IO;
using System.Text.Json;

public class NamaMahasiswa103022300027
{
    public string depan { get; set; }
    public string belakang { get; set; }
}

public class MahasiswaData103022300027
{
    public NamaMahasiswa103022300027 nama { get; set; }
    public string nim { get; set; }
    public string fakultas { get; set; }
}

public class DataMahasiswa103022300027
{
    public void ReadJSON()
    {
        string jsonFileName = "tp7_1_103022300027.json";
        try
        {
            string jsonString = File.ReadAllText(jsonFileName);
            MahasiswaData103022300027 dataMahasiswa = JsonSerializer.Deserialize<MahasiswaData103022300027>(jsonString);
            if (dataMahasiswa != null)
            {
                Console.WriteLine($"Nama {dataMahasiswa.nama.depan} {dataMahasiswa.nama.belakang} dengan nim " +
                    $"{dataMahasiswa.nim} dari fakultas {dataMahasiswa.fakultas}");
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
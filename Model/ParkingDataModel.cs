using System.Text.Json;

namespace ParkingLotImprovement.Model;

public class ParkingData
{
    // Public Variables
    public int LotID { get; set; }
    public bool IsFull { get; set; }
    public int TotalStalls { get; set; }
    public int OpenStalls { get; set; }
}

public class ParkingDataModel : ParkingData
{
    // Internet Request Variables
    HttpClient httpClient = new();
    //string url = "https://drive.google.com/file/d/13gV3cvpUyISCspJunlihMcRM3vmwhmyi/view";
    string url = "https://github.com/cmouanoutoua001e/ParkingLotImprovement.App/raw/main/Data/ParkingData.json";

    // Constructor
    public ParkingDataModel() {  }


    // Data Update Function
    public string[] UpdateParkingData()
    {
        string[] labels = new string[4];
        string json = httpClient.GetStringAsync(url).Result;
        var newPd = JsonSerializer.Deserialize<ParkingData>(json);

        LotID = newPd.LotID;
        IsFull = newPd.IsFull;
        TotalStalls = newPd.TotalStalls;
        OpenStalls = newPd.OpenStalls;

        labels[0] = LotID.ToString();
        labels[1] = IsFull ? "Full" : "Not Full";
        labels[2] = OpenStalls.ToString();
        labels[3] = TotalStalls.ToString();

        return labels;
    }
}

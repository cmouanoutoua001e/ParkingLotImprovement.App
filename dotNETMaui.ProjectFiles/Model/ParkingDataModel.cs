using System.Text.Json;

namespace ParkingLotImprovement.Model;

public class ParkingData
{
    // Public Variables
    public int LotID { get; set; }
    public int TotalStalls { get; set; }
    public int OpenStalls { get; set; }
}

public class ParkingDataModel : ParkingData
{
    // Internet Request Variables
    HttpClient httpClient = new();
    //string url = "https://drive.google.com/file/d/13gV3cvpUyISCspJunlihMcRM3vmwhmyi/view";
    string url = "https://github.com/cmouanoutoua001e/ParkingLotImprovement.App/raw/main/ParkingData/ParkingData.json";

    // Constructor
    public ParkingDataModel() {  }


    // Data Update Function
    public string[] UpdateParkingData()
    {
        string[] labels = new string[4];
        string json = httpClient.GetStringAsync(url).Result;
        var newPd = JsonSerializer.Deserialize<ParkingData>(json);

        LotID = newPd.LotID;
        TotalStalls = newPd.TotalStalls;
        OpenStalls = newPd.OpenStalls;

        labels[0] = "P" + LotID.ToString();
        float percent = ((float)TotalStalls - (float)OpenStalls) / (float)TotalStalls * 100;
        labels[1] = percent.ToString("0") + "% Full";
        labels[2] = "(" + TotalStalls.ToString() + " Total Stalls)";
        labels[3] = OpenStalls.ToString();

        return labels;
    }
}

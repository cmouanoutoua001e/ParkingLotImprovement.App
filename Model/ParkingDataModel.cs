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
    string url = "https://drive.google.com/file/d/13gV3cvpUyISCspJunlihMcRM3vmwhmyi/view";
    //string url = "https://github.com/cmouanoutoua001e/ParkingLotImprovement.App/raw/main/ParkingData.json";

    // Constructor
    public ParkingDataModel() {  }


    // Data Update Functions
    public string[] UpdateParkingData()
    {
        string[] labels = new string[4];
        string json = httpClient.GetStringAsync(url).Result;
        var newPdm = JsonSerializer.Deserialize<ParkingData>(json);

        LotID = newPdm.LotID;
        IsFull = newPdm.IsFull;
        TotalStalls = newPdm.TotalStalls;
        OpenStalls = newPdm.OpenStalls;

        labels[0] = LotID.ToString();
        labels[1] = IsFull.ToString();
        labels[2] = TotalStalls.ToString();
        labels[3] = OpenStalls.ToString();

        return labels;
    }
    // Overloaded Function
    /* public void UpdateParkingData(ref string[] labels)
    {
        string json = httpClient.GetStringAsync(url).Result;
        var newPdm = JsonSerializer.Deserialize<ParkingDataModel>(json);

        LotID = newPdm.LotID;
        IsFull = newPdm.IsFull;
        TotalStalls = newPdm.TotalStalls;
        OpenStalls = newPdm.OpenStalls;

        labels[0] = LotID.ToString();
        labels[1] = IsFull.ToString();
        labels[2] = TotalStalls.ToString();
        labels[3] = OpenStalls.ToString();
    } */
}

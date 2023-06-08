using System.Text.Json;

namespace ParkingLotImprovement.Model;

public class ParkingData
{
    // Public Variables
    public int[] LotIDList { get; set; }
    public int[] TotalStallsList { get; set; }
    public int[] OpenStallsList { get; set; }
}

public class ParkingDataModel : ParkingData
{
    // Internet Request Variables
    /* HttpClient httpClient = new();
    string url = "https://raw.githubusercontent.com/cmouanoutoua001e/ParkingLotImprovement.App/main/ParkingData/ParkingData.json"; */

    // Constructor
    //public ParkingDataModel() {  }


    // Data Update Function
    public string[] UpdateParkingData(int id = 0)
    {
        string[] labels = Enumerable.Repeat("", 4).ToArray();
        if (id == 0)
        {
            labels[0] = "-- Select Parking Lot --";

            return labels;
        }
        
        //string json = httpClient.GetStringAsync(url).Result;

        string json = File.ReadAllText("C:/Users/muasn/Files/4-Coding/0-Temp/ParkingData.json");
        var newPd = JsonSerializer.Deserialize<ParkingData>(json);

        LotIDList = newPd.LotIDList;
        TotalStallsList = newPd.TotalStallsList;
        OpenStallsList = newPd.OpenStallsList;

        labels[0] = "P" + LotIDList[id].ToString();
        float percent = ((float)TotalStallsList[id] - (float)OpenStallsList[id]) / (float)TotalStallsList[id] * 100;
        labels[1] = percent.ToString("0") + "% Full";
        labels[2] = (TotalStallsList[id] == 0)?
            ("") :
            ("(" + TotalStallsList[id].ToString() + " Total Stalls)");
        labels[3] = OpenStallsList[id].ToString();

        return labels;
    }

    /* public string[] UpdateParkingData()
    {
        string[] labels = new string[4];
        //string json = httpClient.GetStringAsync(url).Result;

        string json = File.ReadAllText("C:/Users/muasn/Files/4-Coding/0-Temp/ParkingData.json");
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
    } */
}

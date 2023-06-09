//using GoogleGson;
//using Java.Net;
using System.Net.Http;
using System.Text.Json;

namespace ParkingLotImprovement.Model;

public class ParkingDataModel
{
    // Public Variables
    public int[] LotIDList { get; set; }
    public int[] TotalStallsList { get; set; }
    public int[] OpenStallsList { get; set; }
}

public class ParkingViewData
{
    // Constructor
    public ParkingViewData()
    {
        var pdm = JsonSerializer.Deserialize<ParkingDataModel>(json);
        int n = pdm.LotIDList.Length;
        ValidLotIDList.Add(0);
        ValidLotList.Add("-- Select --");

        for (int i = 0; i < n; i++)
        {
            if (pdm.TotalStallsList[i] != 0)
            {
                ValidLotIDList.Add(pdm.LotIDList[i]);
                ValidLotList.Add("P" + pdm.LotIDList[i].ToString());
            }
        }
    }

    // Variables
    string json
    {
        get
        {
            return File.ReadAllText("C:/Users/muasn/Files/4-Coding/dotNET/ParkingLotImprovement.App/ParkingData/ParkingData.json");

            //string url = "https://github.com/cmouanoutoua001e/ParkingLotImprovement.App/raw/dotNETMaui/ParkingData/ParkingData.json";
            //return httpClient.GetStringAsync(url).Result;
        }
    }

    public List<int> ValidLotIDList { get; private set; } = new();

    public List<string> ValidLotList { get; private set; } = new();

    // Functions
    public string[] UpdateParkingData(int lotID = 0)
    {
        string[] labels = Enumerable.Repeat("", 4).ToArray();
        if (lotID == 0)
        {
            labels[0] = "-- Select Parking Lot --";

            return labels;
        }

        var newPd = JsonSerializer.Deserialize<ParkingDataModel>(json);
        labels[0] = "P" + newPd.LotIDList[lotID].ToString();

        float percent = ((float)newPd.TotalStallsList[lotID] - (float)newPd.OpenStallsList[lotID]) / (float)newPd.TotalStallsList[lotID] * 100;
        labels[1] = (percent == 0) ?
            "Empty" :
            ((percent == 100) ?
                "" :
                percent.ToString("0") + "% ")
            + "Full";

        labels[2] = (newPd.TotalStallsList[lotID] == 0) ?
            "" :
            ("(" + newPd.TotalStallsList[lotID].ToString() + " Total Stalls)");

        labels[3] = newPd.OpenStallsList[lotID].ToString();

        return labels;
    }

    private int BinarySearch(int lotID, int length, int[] lotIDList)
    {
        string[] labels = new string[4];
        int i = length / 2;
        while (i > 0 && i < length)
        {
            if (lotID < lotIDList[i])
            {
                i -=  i / 2;
            }
            else if (lotID > lotIDList[i])
            {
                i += i / 2;
            }
            else
            {
                return i;
            }
        }

        return 0;
    }
}

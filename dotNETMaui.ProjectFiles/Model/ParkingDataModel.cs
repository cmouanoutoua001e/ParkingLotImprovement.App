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

        for (int i = 0; i < n; i++)
        {
            if (pdm.TotalStallsList[i] != 0)
                ValidLotIDList.Add(pdm.LotIDList[i]);
        }
    }

    // Variables
    string json
    {
        get
        {
            return File.ReadAllText("C:/Users/muasn/Files/4-Coding/0-Temp/ParkingData.json");

            //string url = "https://github.com/cmouanoutoua001e/ParkingLotImprovement.App/raw/dotNETMaui/ParkingData/ParkingData.json";
            //return httpClient.GetStringAsync(url).Result;
        }
    }

    public List<int> ValidLotIDList { get; private set; } = new List<int>();


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
        var pdID = BinarySearch(lotID, labels.Length, newPd.LotIDList);

        if (pdID == 0)
        {
            return labels;
        }

        labels[0] = "P" + newPd.LotIDList[pdID].ToString();
        float percent = ((float)newPd.TotalStallsList[pdID] - (float)newPd.OpenStallsList[pdID]) / (float)newPd.TotalStallsList[pdID] * 100;
        labels[1] = percent.ToString("0") + "% Full";
        labels[2] = (newPd.TotalStallsList[pdID] == 0)?
            ("") :
            ("(" + newPd.TotalStallsList[pdID].ToString() + " Total Stalls)");
        labels[3] = newPd.OpenStallsList[pdID].ToString();

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

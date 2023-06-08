using ParkingLotImprovement.Model;
using ParkingLotImprovement.App.Service;
using System.Speech.Synthesis;

namespace ParkingLotImprovement.App;

public partial class MainPage : ContentPage
{
	ParkingDataModel pdm = new();
    ReadAloudModel ram = new();

    public MainPage()
	{
		InitializeComponent();
		SetParkingData();
	}

	private void SetParkingData()
	{
		var Labels = pdm.UpdateParkingData(Int32.Parse(LotID.Text));
		
		LotID.Text = Labels[0];
		Status.Text = Labels[1];
        TotalStalls.Text = Labels[2];
        OpenStalls.Text = Labels[3];

		ram.Set(Labels);
		ram.ReadAloud();
    }


	private void OnRefreshClicked(object sender, EventArgs e)
	{
		SetParkingData();
    }
}

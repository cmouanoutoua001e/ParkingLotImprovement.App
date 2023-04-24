using ParkingLotImprovement.Model;
using System.Text.Json;

namespace ParkingLotImprovement.App;

public partial class MainPage : ContentPage
{
	ParkingDataModel pdm = new();

    public MainPage()
	{
		InitializeComponent();
		SetParkingData();
	}

	private void SetParkingData()
	{
		var Labels = pdm.UpdateParkingData();
		
		LotID.Text = Labels[0];
		Status.Text = Labels[1];
        TotalStalls.Text = Labels[2];
        OpenStalls.Text = Labels[3];
    }

	private void OnRefreshClicked(object sender, EventArgs e)
	{
		SetParkingData();
    }
}

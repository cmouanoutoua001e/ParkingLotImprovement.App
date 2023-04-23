using ParkingLotImprovement.Model;
using System.Text.Json;

namespace ParkingLotImprovement.App;

public partial class MainPage : ContentPage
{
	ParkingDataModel pdm = new();
	int count = 0;

    public MainPage()
	{
		InitializeComponent();
		//SetParkingData();
	}

	private void SetParkingData()
	{
		var Labels = pdm.UpdateParkingData();
		
		LotID.Text = Labels[0];
		IsFull.Text = Labels[1];
        OpenStalls.Text = Labels[2];
        TotalStalls.Text = Labels[3];

		/* SemanticScreenReader.Announce(LotID.Text);
        SemanticScreenReader.Announce(IsFull.Text);
        SemanticScreenReader.Announce(TotalStalls.Text);
        SemanticScreenReader.Announce(OpenStalls.Text); */
    }

	private void OnRefreshClicked(object sender, EventArgs e)
	{
		count++;
		SetParkingData();
		if (count < 10)
		{
            LotID.Text = count.ToString();
        }
    }
}

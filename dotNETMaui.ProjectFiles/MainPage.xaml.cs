using ParkingLotImprovement.Model;
using ParkingLotImprovement.App.Service;
using System.Speech.Synthesis;

namespace ParkingLotImprovement.App;

public partial class MainPage : ContentPage
{
	ParkingViewData pvd = new();
    ReadAloudModel ram = new();

    public MainPage()
	{
		InitializeComponent();
		SetLotIDList();
		SetParkingData();
	}

	private void SetLotIDList()
    {
		foreach (var ID in pvd.ValidLotIDList)
			LotID.Items.Add(ID.ToString());
    }

	private void SetParkingData()
	{
		LotID.SelectedIndex = (LotID.SelectedIndex == -1) ? 0 : LotID.SelectedIndex;
		var Labels = pvd.UpdateParkingData(Int32.Parse( LotID.Items[LotID.SelectedIndex] ));

		//LotID.Text = Labels[0];
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

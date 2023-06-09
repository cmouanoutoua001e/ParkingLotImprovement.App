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
		foreach (var ID in pvd.ValidLotList)
			LotID.Items.Add(ID.ToString());
    }

	private void SetParkingData()
	{
		bool firstRun = false;

		if (LotID.SelectedIndex == -1)
		{
			LotID.SelectedIndex = 0;
			firstRun = true;
        }

		var Labels = pvd.UpdateParkingData(pvd.ValidLotIDList[LotID.SelectedIndex]);

		//LotID.Text = Labels[0];
		Status.Text = Labels[1];
        TotalStalls.Text = Labels[2];
        OpenStalls.Text = Labels[3];

		ram.Set(Labels);
		if (!firstRun)
			ram.ReadAloud();
    }


	private void Refresh(object sender, EventArgs e)
	{
		SetParkingData();
    }
}

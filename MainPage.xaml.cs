namespace ParkingLotImprovement.App;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	int count = 0;

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		string strCmdText = $"/C curl -o https://github.com/cmouanoutoua001e/dotNETMAUITutorial/raw/main/README.md";
        System.Diagnostics.Process.Start("CMD.exe", strCmdText);

        // curl -O "C:\Users\muasn\OneDrive\Desktop\YEYE.txt" https://github.com/cmouanoutoua001e/dotNETMAUITutorial/raw/main/README.md

        /*
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";

		else if (count == 5)
			CounterBtn.Text = "yeye";

		else
		{
			if (count > 20)
				count = 0;
			CounterBtn.Text = $"Clicked {count} times";
		}
		*/

        SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


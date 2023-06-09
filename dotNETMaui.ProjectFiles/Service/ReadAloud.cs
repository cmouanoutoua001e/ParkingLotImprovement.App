using Microsoft.Maui.Media;
using System.Speech.Synthesis;

namespace ParkingLotImprovement.App.Service
{
    public class ReadAloudService
    {
        // Public Variables
        public string ToRead { get; set; }

        // Public Methods
        public async void ReadAloud()
        {
            await TextToSpeech.Default.SpeakAsync(ToRead, options);
        }
        public void Set(string[] labels)
        {
            if (labels[2] == ""){
                ToRead = "Please Select a Parking Lot";
                return;
            }

            ToRead =
                labels[0] + " is " + labels[1] + ".  There " +          // 'P21' is '47% Full'.  There 
                ((labels[3] == "1") ? ("is" + labels[3] + "stall")      // (is '1' stall)
                : ("are" + labels[3] + "stalls")) + "open.";             // (are '9' stalls) open.
        }


        // Private Variables
        SpeechOptions options = new()
        {
            Pitch = 2f,
            Volume = 1f
        };
    }
}

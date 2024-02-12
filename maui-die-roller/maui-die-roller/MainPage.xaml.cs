namespace maui_die_roller
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public List<string> dieTypes = new List<string>()
        { "d20", "d12", "d10", "d8", "d6", "D4", "d100" };

        private void onClick(object sender, EventArgs e)
        {
            dieTypePicker.ItemsSource = dieTypes;
            string selectedDie = dieTypePicker.SelectedItem.ToString();
            int numSides = SelectDie(selectedDie);
            int numDice = int.Parse(numDiceEntry.Text);

            int rolled = Roll(numSides, numDice);
            lblOut.Text = $"You rolled a {rolled}!";
        }

        private int SelectDie(string dieType)
        {
            int sides = 0;
            switch(dieType)
            {
                case "d20":
                    sides = 20;
                    break;
                case "d12":
                    sides = 12;
                    break;
                case "d10":
                    sides = 10;
                    break;
                case "d8":
                    sides = 8;
                    break;
                case "d6":
                    sides = 6;
                    break;
                case "d4":
                    sides = 4;
                    break;
                case "d100":
                    sides = 100;
                    break;
            }
            if (sides == 0)
            {
                return -1;
                DisplayAlert("Error.", "Select a valid option.", "Go back.");
            }
            else
            {
                return sides;
            }
        }

        private int Roll(int numSides, int numDice)
        {
            Random die = new Random();
            int result = die.Next(numSides) + 1;
            return result;
        }
    }
}
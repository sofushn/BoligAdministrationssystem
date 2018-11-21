namespace UWP_App.Model
{
    public class StatusRapportVindue : StatusRapportBase
    {
        public Vindue Vindue { get; set; }
        public override StatusRapportTypes RapportType { get => StatusRapportTypes.Vindue; }

        public StatusRapportVindue(): base() {
            Vindue = new Vindue();
        }
    }
}
namespace UWP_App.Model
{
    public class StatusRapportVindue : StatusRapportBase
    {
        public int Vindue_ID { get; set; }
        public override StatusRapportTypes RapportType { get => StatusRapportTypes.Vindue; }
    }
}
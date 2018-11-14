namespace UWP_App.Model
{
    public class StatusRapportFaldstamme : StatusRapportBase
    {
        public Faldstamme Faldstamme { get; set; }
        public override StatusRapportTypes RapportType { get => StatusRapportTypes.Faldstamme; }
    }
}
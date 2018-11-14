namespace UWP_App.Model
{
    public interface ICanBeReportedOn
    {
        string Beskrivelse { get; set; }
        StatusValues Status { get; set; }
    }
}
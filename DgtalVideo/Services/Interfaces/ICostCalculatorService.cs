using DgtalVideo.Data.Enums;

namespace DgtalVideo.Services.Interfaces
{
    public interface ICostCalculatorService
    {
        decimal CostCalculator(ServiceType SelectedServices, VolumeOfSourceFiles VolumeOfSourceFiles, Subtitles Subtitles, Urgency Urgency, Format FormatMovie);
    }
}

using DgtalVideo.Data.Enums;
using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;

namespace DgtalVideo.Services
{
    public class CostCalculatorService : ICostCalculatorService
    {
        public decimal CostCalculator(ServiceType SelectedServices, VolumeOfSourceFiles VolumeOfSourceFiles, Subtitles Subtitles, Urgency Urgency, Format FormatMovie)
        {
            decimal basePrice = (decimal)1500;
            decimal serviceType = (decimal)SelectedServices;
            decimal sourses = (decimal)VolumeOfSourceFiles;
            decimal subtitles = (decimal)Subtitles;
            decimal urgency = (decimal)Urgency;
            decimal formatMovie = (decimal)FormatMovie;
            return basePrice + serviceType + sourses + subtitles + urgency + formatMovie;
        }
    }
}

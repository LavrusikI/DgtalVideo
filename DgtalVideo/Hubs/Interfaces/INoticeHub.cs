namespace DgtalVideo.Hubs.Interfaces
{
    public interface INoticeHub
    {
        Task NewMovieAdded(string movieName);
        Task NewContactRequest(string customerName, string mobilePhone);
    }
}

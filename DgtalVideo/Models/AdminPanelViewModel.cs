using DgtalVideo.Data.Enums;
using DgtalVideo.Data.Models;

namespace DgtalVideo.Models
{
    public class AdminPanelViewModel
    {
        public UserRole UserRole { get; set; }
        public int UnreadRequestCount { get; set; }
        public PortfolioViewModel NewPortfolio { get; set; } = new();
        public ReviewsViewModel NewReview { get; set; } = new();
        public PortfolioViewModel? EditingPortfolio { get; set; }

        public List<ReviewsViewModel> Reviews { get; set; } = new();
        public List<PortfolioViewModel> Movies { get; set; } = new();
        public List<ContactFormViewModel> ContactRequests { get; set; } = new();
    }
}

using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DgtalVideo.Controllers
{
    public class CostCalculatorController : Controller
    {
        private readonly ICostCalculatorService _costCalculatorService;

        public CostCalculatorController(ICostCalculatorService costCalculatorService)
        {
            _costCalculatorService = costCalculatorService;
        }

        [HttpGet]
        public IActionResult CostCalculator()
        {
            return View(new CostСalculatorViewModel());
        }
        [HttpPost]
        public IActionResult CostCalculator(CostСalculatorViewModel viewModel)
        {
            viewModel.TotalCost = _costCalculatorService.CostCalculator(
                viewModel.SelectedServices,
                viewModel.VolumeOfSourceFiles,
                viewModel.Subtitles,
                viewModel.Urgency,
                viewModel.FormatMovie);
            return View(viewModel);
        }
    }
}
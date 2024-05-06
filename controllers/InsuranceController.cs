using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceAPI.Models;
using VehicleInsuranceAPI.Services;

namespace VehicleInsuranceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly ICreditScoreService _creditScoreService;

        public InsuranceController(ICreditScoreService creditScoreService)
        {
            _creditScoreService = creditScoreService;
        }

       
    }
}

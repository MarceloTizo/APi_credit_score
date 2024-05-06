using VehicleInsuranceAPI.Models;

namespace VehicleInsuranceAPI.Services
{
    public class CreditScoreService : ICreditScoreService
    {
        private readonly IInsuranceDataService _insuranceDataService;

        public CreditScoreService(IInsuranceDataService insuranceDataService)
        {
            _insuranceDataService = insuranceDataService;
        }

        public decimal CalculateCreditScore(InsuranceData data)
        {
            var matchingRecord = _insuranceDataService.GetMatchingData(data);
            return matchingRecord?.CreditScore ?? 0m; 
        }
    }
}

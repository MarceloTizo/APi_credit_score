using VehicleInsuranceAPI.Models;

namespace VehicleInsuranceAPI.Services
{
    public interface ICreditScoreService
    {
        decimal CalculateCreditScore(InsuranceData data);
    }
}

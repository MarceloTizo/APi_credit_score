using CsvHelper.Configuration;
using VehicleInsuranceAPI.Models;

namespace VehicleInsuranceAPI.Services
{
    public class InsuranceDataMap : ClassMap<InsuranceData>
    {
        public InsuranceDataMap()
        {
            Map(m => m.Age).Name("AGE");
            Map(m => m.Gender).Name("GENDER");
            Map(m => m.DrivingExperience).Name("DRIVING_EXPERIENCE");
            Map(m => m.Education).Name("EDUCATION");
            Map(m => m.Income).Name("INCOME");
            Map(m => m.VehicleYear).Name("VEHICLE_YEAR");
            Map(m => m.VehicleType).Name("VEHICLE_TYPE");
            Map(m => m.AnnualMileage).Name("ANNUAL_MILEAGE").TypeConverter<AnnualMileageConverter>();
            Map(m => m.CreditScore).Name("CREDIT_SCORE").TypeConverter<CreditScoreConverter>();
        }
    }
}

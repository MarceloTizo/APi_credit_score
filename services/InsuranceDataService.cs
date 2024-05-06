using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using VehicleInsuranceAPI.Models;

namespace VehicleInsuranceAPI.Services
{
    public class InsuranceDataService : IInsuranceDataService
    {
        private List<InsuranceData> _insuranceData;

        public InsuranceDataService()
        {
            _insuranceData = ReadInsuranceData();
        }

        private List<InsuranceData> ReadInsuranceData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            };

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "services", "Car_Insurance_Claim.csv");

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<InsuranceDataMap>();
            return csv.GetRecords<InsuranceData>().ToList();
        }

        public InsuranceData? GetMatchingData(InsuranceData data)
        {

            foreach (var record in _insuranceData)
            {

                if (string.Equals(record.Age, data.Age, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(record.Gender, data.Gender, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(record.DrivingExperience, data.DrivingExperience, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(record.Education, data.Education, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(record.Income, data.Income, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(record.VehicleYear, data.VehicleYear, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(record.VehicleType, data.VehicleType, StringComparison.OrdinalIgnoreCase) &&
                    Math.Abs(Convert.ToDouble(record.AnnualMileage) - Convert.ToDouble(data.AnnualMileage)) < 0.01)
                {
                    Console.WriteLine($"Found matching record: {record}");
                    return record;
                }
            }

            Console.WriteLine("No matching record found.");
            return null;
        }
    }

    public interface IInsuranceDataService
    {
        InsuranceData? GetMatchingData(InsuranceData data);
    }
}

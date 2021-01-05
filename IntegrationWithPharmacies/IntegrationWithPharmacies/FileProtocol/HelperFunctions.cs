using System;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class HelperFunctions
    {
        public HelperFunctions() { }
        public bool IsIdEqual(int firstNumber, int secondNumber)
        {
            return (firstNumber == secondNumber);
        }
        public int CompareDates(DateTime startDate, DateTime endDate)
        {
            return (DateTime.Compare(startDate, endDate));
        }
        public DateTime ConvertStringToDate(String date)
        {
            return new DateTime(int.Parse(date.Split("/")[2]), int.Parse(date.Split("/")[1]), int.Parse(date.Split("/")[0]));
        }
        public int GetRandomNumber()
        {
            return new Random().Next(1, 100);
        }
    }
}

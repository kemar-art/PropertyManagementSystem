namespace PMS.UI.Services
{
    public static class StringExtensions
    {
        public static List<Guid> ConvertStringToListOfInt(this string guidString)
        {
            if (string.IsNullOrEmpty(guidString))
            {
                return [];
            }

            string[] intArray = guidString.Split(',');

            List<Guid> intList = [];

            foreach (var intStr in intArray)
            {
                if (Guid.TryParse(intStr.Trim(), out Guid id))
                {
                    intList.Add(id);
                }
            }
            return intList;
        }
    }
}

using System.Collections.Generic;

namespace BikeRentalApp
{
    public class BikeUtility
    {
        public void AddBikeDetails(string model, string brand, int pricePerDay)
        {
            int key = Program.bikeDetails.Count + 1;
            Program.bikeDetails.Add(key, new Bike
            {
                Model = model,
                Brand = brand,
                PricePerDay = pricePerDay
            });
        }

        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> result = new SortedDictionary<string, List<Bike>>();

            foreach (var bike in Program.bikeDetails.Values)
            {
                if (!result.ContainsKey(bike.Brand))
                    result[bike.Brand] = new List<Bike>();

                result[bike.Brand].Add(bike);
            }

            return result;
        }
    }
}

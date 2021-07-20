using System.Collections.Generic;
using Designer.Common.ValueObject;

namespace Designer.Common.Model.Response
{
    public class GenerateAllAvailablePositionsResponseModel
    {
        public List<KeyValuePair<Spot, List<Spot>>> Coordinates { get; set; }

        public GenerateAllAvailablePositionsResponseModel(List<KeyValuePair<Spot, List<Spot>>> coordinates)
        {
            Coordinates = coordinates;
        }
    }
}

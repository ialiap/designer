using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designer.Common.Common.Behavior;
using Designer.Common.Domain;
using Designer.Common.Model.Request;
using Designer.Common.Model.Response;
using Designer.Common.ValueObject;
using Designer.Service.API.Service.Protocol;

namespace Designer.Service.API.Service.Implementation
{
    public class MeshService : IMeshService
    {

        [BindingModelValidation]
        public async Task<GenerateAllAvailablePositionsResponseModel> Generate(GenerateAllAvailablePositionsBindingModel model)
        {

            var result = await GenerateAllAvailablePositions(model.Container, model.Table, model.Chair, model.Accuracy);
            return new GenerateAllAvailablePositionsResponseModel(result);
        }


        private async Task<List<KeyValuePair<Spot, List<Spot>>>> GenerateAllAvailablePositions(Container container,
            SquareTable table, Chair chair, int accuracy)
        {
            int containerY = 0;
            var result = new List<KeyValuePair<Spot, List<Spot>>>();
            table.Parent = container;
            table.Accuracy = accuracy;

            while (containerY < (container.Length - table.Length) )
            {
                int containerX = 0;
                while (containerX < (container.Width - table.Width))
                {
                    table.ResetPosition(containerX, containerY);
                    await table.Visit(chair);
                    result.Add(new KeyValuePair<Spot, List<Spot>>(table.Spot, table.AvailableSpots.Select(x => new Spot(x.X, x.Y)).ToList()));
                    containerX += accuracy;
                }

                containerY += accuracy;
            }

            return result;
        }
    }
}
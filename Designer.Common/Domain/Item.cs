using Designer.Common.ValueObject;

namespace Designer.Common.Domain
{
    public abstract class Item
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int RequiredSpace { get; set; }
        public Spot Spot { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designer.Common.ValueObject;
using Designer.Common.Visitor;

namespace Designer.Common.Domain
{
    public class SquareTable : Item, IAcceptVisitor
    {

        public List<Spot> AvailableSpots { get; set; } = new List<Spot>();
        public Item Parent { get; set; }
        public int Accuracy { get; set; }

        public void ResetPosition(int x, int y)
        {
            if (x == 0) x = Accuracy;
            if (y == 0) y = Accuracy;
            Spot = new Spot(x, y);
            AvailableSpots = new List<Spot>();
        }

        public async Task Visit(Item visitor)
        {

            var line1=Task.Run(()=>
                TraverseHorizontal(
                    this.Spot,
                    new Spot(this.Spot.X + this.Width, this.Spot.Y),
                    visitor,
                    (a, b) => a - b));

            var line2 = Task.Run(() =>
                TraverseVertical(
                    new Spot(this.Spot.X + this.Width, this.Spot.Y),
                    new Spot(this.Spot.X + this.Width, this.Spot.Y + this.Length),
                    visitor,
                    (a, b) => a + b));


            var line3 = Task.Run(() =>
              TraverseHorizontal(
                    new Spot(this.Spot.X, this.Spot.Y + this.Length),
                    new Spot(this.Spot.X + this.Width, this.Spot.Y + this.Length),
                    visitor,
                    (a, b) => a + b
                )
            );

            var line4 = Task.Run(() =>
       TraverseVertical(
                    this.Spot,
                    new Spot(this.Spot.X, this.Spot.Y + this.Length),
                    visitor,
                    (a, b) => a - b)
            );

            var result = await Task.WhenAll(line1, line2, line3, line4);
            result.ToList().ForEach(x=>AvailableSpots.AddRange(x));


        }
        private List<Spot> TraverseHorizontal(Spot start, Spot end, Item item, Func<int, int, int> fn)
        {
            var result = new List<Spot>();
            var i = start.X;

            while (i + item.Width <= end.X)
            {
                var position = fn(start.Y, item.Length);
                if (position > 0 && position <= Parent.Length-item.Length)
                    result.Add(new Spot(i, fn(position > start.Y ? start.Y : position, item.RequiredSpace)));
                i += Accuracy;
            }

            return result;
        }

        private  List<Spot> TraverseVertical(Spot start, Spot end, Item item, Func<int, int, int> fn)
        {
            var result = new List<Spot>();
            var i = start.Y;

            while (i + item.Width <= end.Y)
            {
                var position = fn(start.X, item.Width);
                if (position > 0 && position < Parent.Width-item.Width)
                    result.Add(new Spot(fn(position > start.X ? start.X : position, item.RequiredSpace), i));
                i += Accuracy;
            }

            return result;
        }


    }
}
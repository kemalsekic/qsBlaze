using qsBlaze.Data.UserInfo;

namespace qsBlaze.Data.Choices
{
    public class ColorOptions
    {
        public string Color { get; set; }
        public string DisplayColor { get; set; }

        public ColorOptions(string color, string displayColor)
        {
            Color = color;
            DisplayColor = displayColor;
        }

        ColorOptions value = null;

        ColorOptions[] colorValues = new[]
        {
            new ColorOptions("Green", "Green"),
            new ColorOptions("Yellow", "Gold"),
            new ColorOptions("Red", "Red"),
        };
    }

    public class PointOptions
    {
        public int SprintPoints { get; set; }

        public PointOptions(int sprintPoints)
        {
            SprintPoints = sprintPoints;
        }

        //PointOptions pointVal = null;
        PointOptions[] pointValues = new[]
        {
            new PointOptions(1),
            new PointOptions(2),
            new PointOptions(3),
            new PointOptions(4),
            new PointOptions(5),
            new PointOptions(6),
            new PointOptions(7),
            new PointOptions(8),
            new PointOptions(9),
            new PointOptions(10),
            new PointOptions(11),
            new PointOptions(12),
            new PointOptions(13),
        };

        //public List<PointOptions> GetPointOptions()
        //{
        //    var selectOpts = new List<PointOptions>();

        //    selectOpts.Add(new PointOptions(1));
        //    selectOpts.Add(new PointOptions(2));
        //    selectOpts.Add(new PointOptions(3));
        //    selectOpts.Add(new PointOptions(4));
        //    selectOpts.Add(new PointOptions(5));
        //    selectOpts.Add(new PointOptions(6));
        //    selectOpts.Add(new PointOptions(7));
        //    selectOpts.Add(new PointOptions(8));
        //    selectOpts.Add(new PointOptions(9));
        //    selectOpts.Add(new PointOptions(10));
        //    selectOpts.Add(new PointOptions(11));
        //    selectOpts.Add(new PointOptions(12));
        //    selectOpts.Add(new PointOptions(13));

        //    return selectOpts;
        //}
    }

    public class EditUserSelectOptions
    {
    }
}

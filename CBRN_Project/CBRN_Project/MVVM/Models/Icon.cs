namespace CBRN_Project.MVVM.Models
{
    public class Icon
    {
        public string   Name            { get; private set; }
        public int      Id              { get; set; }
        public float    Personnel       { get; set; }
        public float    BodySurfaceArea { get; set; } = (float)0.9;
        public float BreathingRateValue { get; set; } = (float)0.0150;
        public string   Ipe             { get; set; }

        public static Icon CreateNewIcon(int iconId)
        {
            return new Icon(iconId);
        }

        public Icon(int iconId)
        {
            Id = iconId;
            Name = "Icon " + Id.ToString();
        }
    }
}

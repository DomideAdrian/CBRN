namespace CBRN_Project.MVVM.Models
{
    public class Icon
    {
        public string   Name {
            get
            {
                return "Icon " + Id;
            }
        }
        public int      Id { get; set; }
        public double   Personnel { get; set; }

        public static Icon CreateNewIcon(int iconId)
        {
            return new Icon(iconId);
        }

        public Icon(int iconId)
        {
            Id = iconId - 1;
        }
    }
}

using System.Collections.Generic;

namespace CBRN_Project.MVVM.Models
{
    public class Icon
    {
        #region Fields

        private static uint crrtID = 0;

        #endregion

        #region Properties

        public uint ID          { get; set; }
        public uint Personnel   { get; set; }

        public BreathingRate BreathingRate  { get; set; }
        public double BodySurfaceArea       { get; set; }
        public ProtFactors IPE              { get; set; }
        public ProtFactors Vehicle_Shelter  { get; set; }
        public ProtFactors Prophylaxis      { get; set; }
        public bool Uniform                 { get; set; }

        public List<Challenge> Challenges { get; set; }

        #endregion

        #region Constructors

        public Icon()
        {
            ID = crrtID++;
        }

        #endregion

        #region Methods



        #endregion
    }
}

namespace CBRN_Project.MVVM.Models
{
    public enum ActivityLevel { AtRest, Light, Moderate, Heavy }

    public class BreathingRate
    {
        #region Properties

        public double ChemAg_Ih { get; set; }
        public double BioAg_RadPar_Ih { get; set; }
        public double ChemAg_UnitlessFactor { get; set; }

        #endregion

        #region Constructors

        public BreathingRate()
        {
            this.ChemAg_Ih = 0.015;
            this.BioAg_RadPar_Ih = 0.015;
            this.ChemAg_UnitlessFactor = 1;
        }

        public BreathingRate(ActivityLevel activityLevel)
        {
            switch (activityLevel)
            {
                case ActivityLevel.AtRest:
                    {
                        this.ChemAg_Ih = 0.0075;
                        this.BioAg_RadPar_Ih = 0.0075;
                        this.ChemAg_UnitlessFactor = 0.5;
                    } break;
                case ActivityLevel.Light:
                    {
                        this.ChemAg_Ih = 0.015;
                        this.BioAg_RadPar_Ih = 0.015;
                        this.ChemAg_UnitlessFactor = 1;
                    } break;
                case ActivityLevel.Moderate:
                    {
                        this.ChemAg_Ih = 0.03;
                        this.BioAg_RadPar_Ih = 0.03;
                        this.ChemAg_UnitlessFactor = 2;
                    } break;
                case ActivityLevel.Heavy:
                    {
                        this.ChemAg_Ih = 0.075;
                        this.BioAg_RadPar_Ih = 0.075;
                        this.ChemAg_UnitlessFactor = 5;
                    } break;
            }
        }

        public BreathingRate(double ChemAg_Ih, double BioAg_RadPar_Ih)
        {
            this.ChemAg_Ih = ChemAg_Ih;
            this.BioAg_RadPar_Ih = BioAg_RadPar_Ih;
            this.ChemAg_UnitlessFactor = this.ChemAg_Ih / 0.015;
        }

        #endregion
    }
}

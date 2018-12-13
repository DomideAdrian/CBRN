namespace CBRN_Project.MVVM.Models
{
    public class ProtFactors
    {
        #region Properties

        public double Inhalation { get; set; }
        public double PervVap    { get; set; }
        public double PercLiq    { get; set; }
        public double BetaRad    { get; set; }
        public double GammaRad   { get; set; }
        public double NeutronRad { get; set; }
        public double NucBlast   { get; set; }

        #endregion

        #region Constructors

        public ProtFactors()
        {
            this.Inhalation = 1;
            this.PervVap = 1;
            this.PercLiq = 1;
            this.BetaRad = 1;
            this.GammaRad = 1;
            this.NeutronRad = 1;
            this.NucBlast = 1;
        }

        #endregion
    }
}

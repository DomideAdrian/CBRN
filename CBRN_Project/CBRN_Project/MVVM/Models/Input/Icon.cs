﻿using System.Collections.Generic;

namespace CBRN_Project.MVVM.Models
{
    public class Icon
    {
        #region Properties

        public string Name                  { get; set; }
        public int ID                      { get; set; }
        public float Personnel              { get; set; }
        
        public BreathingRate BreathingRate  { get; set; }
        public float BodySurfaceArea        { get; set; } = (float)0.9;
        public ProtFactors IPE              { get; set; }
        public ProtFactors Vehicle_Shelter  { get; set; }
        public ProtFactors Prophylaxis      { get; set; }
        public bool Uniform                 { get; set; }

        public List<Challenge> Challenges { get; set; }

        #endregion

        #region Constructors

        public Icon(int iconId)
        {
            ID = iconId;
            Name = "Icon " + ID.ToString();
        }

        #endregion

        #region Methods

        public static Icon CreateNewIcon(int iconId)
        {
            return new Icon(iconId);
        }

        #endregion
    }
}

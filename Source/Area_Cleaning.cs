using RimWorld;
using System;
using UnityEngine;

namespace NoCleaningPlease
{
    public class Area_Cleaning : Area
    {
        #region Constructors

        public Area_Cleaning()
        {
        }

        #endregion Constructors

        #region Properties

        public override UnityEngine.Color Color
        {
            get
            {
                return new UnityEngine.Color( 0.3f, 0.9f, 0.9f );
            }
        }

        public override string Label
        {
            get
            {
                return ResourceBank.AreaCleanLabel;
            }
        }

        public override int ListPriority
        {
            get
            {
                return 10001;
            }
        }

        #endregion Properties

        #region Methods

        public override bool AssignableAsAllowed( AllowedAreaMode mode )
        {
            // nothing may be assigned to this area
            return false;
        }

        public override string GetUniqueLoadID()
        {
            return "Area_Cleaning";
        }

        #endregion Methods
    }
}
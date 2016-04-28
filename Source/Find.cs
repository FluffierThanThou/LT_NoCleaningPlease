using RimWorld;
using System;
using Verse;

namespace NoCleaningPlease
{
    public static class Find
    {
        #region Properties

        public static Area_Cleaning AreaCleaning
        {
            get
            {
                return Verse.Find.AreaManager.Get<Area_Cleaning>();
            }
        }

        #endregion Properties
    }
}
using RimWorld;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Verse;

namespace NoCleaningPlease
{
    public class MapComponent_NoCleaningPlease : MapComponent
    {
        #region Fields

        private bool done;

        #endregion Fields

        #region Constructors

        public MapComponent_NoCleaningPlease()
        {
        }

        #endregion Constructors

        #region Methods

        public override void MapComponentUpdate()
        {
            if ( this.done )
            {
                return;
            }
            List<Area> allAreas = Verse.Find.AreaManager.AllAreas;
            if ( !allAreas.Exists( ( Area s ) => s.GetType() == typeof( Area_Cleaning ) ) )
            {
                allAreas.Add( new Area_Cleaning() );
            }
            ListerFilth.RebuildAll();
            Log.Message( "LT-NC: Initialized NoCleaningPlease." );
            done = true;
        }

        #endregion Methods
    }
}
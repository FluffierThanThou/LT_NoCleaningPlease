using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse;

namespace NoCleaningPlease
{
    public static class ListerFilth
    {
        #region Constructors

        static ListerFilth()
        {
            FilthWithinZone = new List<Thing>();
        }

        #endregion Constructors

        #region Properties

        public static List<Thing> FilthWithinZone
        {
            get;
        }

        #endregion Properties

        #region Methods

        public static void Notify_CleaningAreaChanged( IntVec3 c )
        {
            if ( !Find.AreaCleaning[c] )
            {
                for ( int i = FilthWithinZone.Count - 1; i >= 0; i-- )
                {
                    if ( FilthWithinZone[i].Position == c )
                    {
                        FilthWithinZone.RemoveAt( i );
                    }
                }
            }
            else
            {
                foreach ( Thing thing in GridsUtility.GetThingList( c ).Where( ( Thing s ) =>
                {
                    if ( s.def.thingClass == typeof( Filth ) )
                    {
                        return true;
                    }
                    return s.def.thingClass == typeof( RimWorld.Filth );
                } ) )
                {
                    FilthWithinZone.Add( thing );
                }
            }
        }

        public static void Notify_FilthDespawned( NoCleaningPlease.Filth f )
        {
            for ( int i = 0; i < ListerFilth.FilthWithinZone.Count; i++ )
            {
                if ( ListerFilth.FilthWithinZone[i] == f )
                {
                    ListerFilth.FilthWithinZone.RemoveAt( i );
                    return;
                }
            }
        }

        public static void Notify_FilthSpawned( NoCleaningPlease.Filth f )
        {
            if ( NoCleaningPlease.Find.AreaCleaning[f.Position] )
            {
                ListerFilth.FilthWithinZone.Add( f );
            }
        }

        public static void RebuildAll()
        {
            FilthWithinZone.Clear();
            foreach ( IntVec3 allCell in Verse.Find.Map.AllCells )
            {
                Notify_CleaningAreaChanged( allCell );
            }
        }

        #endregion Methods
    }
}
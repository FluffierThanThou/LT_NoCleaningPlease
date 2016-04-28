using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace NoCleaningPlease
{
    internal class WorkGiver_CleanFilth_NoHome : WorkGiver_Scanner
    {
        #region Fields

        private int minTicksSinceThickened = 600;

        #endregion Fields

        #region Constructors

        public WorkGiver_CleanFilth_NoHome()
        {
        }

        #endregion Constructors

        #region Properties

        public override Verse.AI.PathEndMode PathEndMode
        {
            get
            {
                return PathEndMode.OnCell;
            }
        }

        public override ThingRequest PotentialWorkThingRequest
        {
            get
            {
                return ThingRequest.ForGroup( ThingRequestGroup.Filth );
            }
        }

        #endregion Properties

        #region Methods

        public override bool HasJobOnThing( Pawn pawn, Thing t )
        {
            if ( pawn.Faction != Faction.OfColony )
            {
                return false;
            }
            RimWorld.Filth filth = t as RimWorld.Filth;
            if ( filth == null )
            {
                return false;
            }
            if ( !Find.AreaCleaning[filth.Position] || !ReservationUtility.CanReserveAndReach( pawn, t, PathEndMode.ClosestTouch, DangerUtility.NormalMaxDanger( pawn ), 1 ) )
            {
                return false;
            }
            return filth.TicksSinceThickened >= minTicksSinceThickened;
        }

        public override Job JobOnThing( Pawn pawn, Thing t )
        {
            return new Job( JobDefOf.Clean, t );
        }

        public override IEnumerable<Thing> PotentialWorkThingsGlobal( Pawn pawn )
        {
            return ListerFilth.FilthWithinZone;
        }

        #endregion Methods
    }
}
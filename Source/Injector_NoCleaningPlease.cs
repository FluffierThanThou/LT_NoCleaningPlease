using CommunityCoreLibrary;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse;

namespace NoCleaningPlease
{
    public class Injector_NoCleaningPlease : SpecialInjector
    {
        #region Constructors

        public Injector_NoCleaningPlease()
        {
        }

        #endregion Constructors

        #region Methods

        public override bool Inject()
        {
            IEnumerable<ThingDef> allDefs = DefDatabase<ThingDef>.AllDefs;
            try
            {
                foreach ( ThingDef thingDef in
                    from current in allDefs
                    where current.thingClass == typeof( RimWorld.Filth )
                    select current )
                {
                    thingDef.thingClass = typeof( NoCleaningPlease.Filth );
                }
            }
            catch ( Exception exception )
            {
                throw new Exception( string.Concat( "LT-NC: Met error while injecting.\n", exception ) );
            }

            return true;
        }

        #endregion Methods
    }
}
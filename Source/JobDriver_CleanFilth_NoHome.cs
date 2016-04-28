using RimWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Verse;
using Verse.AI;

namespace NoCleaningPlease
{
    public class JobDriver_CleanFilth_NoHome : JobDriver_PlantWork
    {
        #region Fields

        private float cleaningWorkDone;

        #endregion Fields

        #region Constructors

        public JobDriver_CleanFilth_NoHome()
        {
        }

        #endregion Constructors

        #region Methods

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.LookValue<float>( ref this.cleaningWorkDone, "cleaningWorkDone", 0f, false );
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedNullOrForbidden( TargetIndex.A );
            this.FailOn( () => !Find.AreaCleaning[TargetThingA.Position] );
            yield return Toils_Reserve.Reserve( TargetIndex.A, 1 );
            yield return Toils_Goto.GotoThing( TargetIndex.A, PathEndMode.Touch );
            Toil toil = new Toil()
            {
                tickAction = () =>
                {
                    Filth targetThingA = TargetThingA as Filth;
                    if ( targetThingA == null )
                    {
                        return;
                    }
                    cleaningWorkDone = cleaningWorkDone + 1f;
                    if ( cleaningWorkDone <= targetThingA.def.filth.cleaningWorkToReduceThickness )
                    {
                        return;
                    }
                    targetThingA.ThinFilth();
                    if ( !targetThingA.Destroyed )
                    {
                        return;
                    }
                    ReadyForNextToil();
                },
                defaultCompleteMode = ToilCompleteMode.Never
            };
            Toil toil1 = toil;
            toil1.WithEffect( "Clean", TargetIndex.A );
            toil1.WithSustainer( SoundDefOf.Interact_CleanFilth );
            yield return toil1;
        }

        #endregion Methods
    }
}
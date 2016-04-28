using RimWorld;
using System;
using UnityEngine;
using Verse;

namespace NoCleaningPlease
{
    public class Designator_AreaCleaningClear : Designator_AreaCleaning
    {
        #region Constructors

        public Designator_AreaCleaningClear() : base( DesignateMode.Remove )
        {
            this.defaultLabel = ResourceBank.AreaCleaningClear;
            this.defaultDesc = ResourceBank.AreaCleaningClearDesc;
            this.icon = ContentFinder<Texture2D>.Get( "UI/Commands/AreaCleaningDelete", true );
            this.soundDragSustain = SoundDefOf.DesignateDragAreaDelete;
            this.soundDragChanged = SoundDefOf.DesignateDragAreaDeleteChanged;
            this.soundSucceeded = SoundDefOf.DesignateAreaDelete;
        }

        #endregion Constructors
    }
}
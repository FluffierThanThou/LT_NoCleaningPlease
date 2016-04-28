using RimWorld;
using System;
using Verse;

namespace NoCleaningPlease
{
    public abstract class Designator_AreaCleaning : Designator
    {
        #region Fields

        private DesignateMode mode;

        #endregion Fields

        #region Constructors

        public Designator_AreaCleaning( DesignateMode mode )
        {
            this.mode = mode;
            this.soundDragSustain = SoundDefOf.DesignateDragStandard;
            this.soundDragChanged = SoundDefOf.DesignateDragStandardChanged;
            this.useMouseIcon = true;
            this.hotKey = KeyBindingDefOf.Misc7;
        }

        #endregion Constructors

        #region Properties

        public override bool DragDrawMeasurements
        {
            get
            {
                return true;
            }
        }

        public override int DraggableDimensions
        {
            get
            {
                return 2;
            }
        }

        #endregion Properties

        #region Methods

        public override AcceptanceReport CanDesignateCell( IntVec3 c )
        {
            if ( !GenGrid.InBounds( c ) )
            {
                return false;
            }
            bool designated = Find.AreaCleaning[c];
            if ( this.mode == DesignateMode.Remove )
            {
                return designated;
            }
            return !designated;
        }

        public override void DesignateSingleCell( IntVec3 c )
        {
            if ( this.mode == DesignateMode.Add )
                Find.AreaCleaning.Set( c );
            else
                Find.AreaCleaning.Clear( c );
        }

        public override void SelectedUpdate()
        {
            GenUI.RenderMouseoverBracket();
            NoCleaningPlease.Find.AreaCleaning.MarkForDraw();
        }

        #endregion Methods
    }
}
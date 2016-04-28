using RimWorld;
using System;
using UnityEngine;
using Verse;

namespace NoCleaningPlease
{
	public class Designator_AreaCleaningExpand : Designator_AreaCleaning
	{
		public Designator_AreaCleaningExpand() : base(0)
		{
			this.defaultLabel = ResourceBank.AreaCleaningExpand;
			this.defaultDesc = ResourceBank.AreaCleaningExpandDesc;
			this.icon = ContentFinder<Texture2D>.Get("UI/Commands/AreaCleaning", true);
			this.soundDragSustain = SoundDefOf.DesignateDragAreaDelete;
			this.soundDragChanged = SoundDefOf.DesignateDragAreaDeleteChanged;
			this.soundSucceeded = SoundDefOf.DesignateAreaDelete;
		}
	}
}
using System;
using Verse;

namespace NoCleaningPlease
{
	public static class ResourceBank
	{
		public readonly static string AreaCleanLabel;

		public readonly static string AreaCleaningClear;

		public readonly static string AreaCleaningClearDesc;

		public readonly static string AreaCleaningExpand;

		public readonly static string AreaCleaningExpandDesc;

		static ResourceBank()
		{
			ResourceBank.AreaCleanLabel = Translator.Translate("Area_Cleaning");
			ResourceBank.AreaCleaningClear = Translator.Translate("DesignatorAreaCleaningClear");
			ResourceBank.AreaCleaningClearDesc = Translator.Translate("DesignatorAreaCleaningClearDesc");
			ResourceBank.AreaCleaningExpand = Translator.Translate("DesignatorAreaCleaningExpand");
			ResourceBank.AreaCleaningExpandDesc = Translator.Translate("DesignatorAreaCleaningExpandDesc");
		}
	}
}
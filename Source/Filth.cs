using RimWorld;
using System;
using Verse;

namespace NoCleaningPlease
{
    public class Filth : RimWorld.Filth
    {
        #region Constructors

        public Filth()
        {
        }

        #endregion Constructors

        #region Methods

        public override void DeSpawn()
        {
            base.DeSpawn();
            if ( Game.Mode == GameMode.MapPlaying )
            {
                ListerFilth.Notify_FilthDespawned( this );
            }
        }

        public override void SpawnSetup()
        {
            base.SpawnSetup();
            if ( Game.Mode == GameMode.MapPlaying )
            {
                ListerFilth.Notify_FilthSpawned( this );
            }
        }

        #endregion Methods
    }
}
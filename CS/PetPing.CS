using System;
using XRL.Rules;

namespace XRL.World.Parts
{

	[Serializable]
	public class PetPing : IPart
	{

		public override bool WantEvent(int ID, int cascade)
		{
			return base.WantEvent(ID, cascade) || ID == BeforeRenderEvent.ID;
		}


		public override bool HandleEvent(BeforeRenderEvent E)
		{
			if (Stat.RandomCosmetic(1, 1000) <= this.Chance && this.LastTrigger < DateTime.Now.Ticks - (long)this.MinimumTicks)
			{
				this.LastTrigger = DateTime.Now.Ticks;
				this.ParentObject.DilationSplat();
			}
			return base.HandleEvent(E);
		}


		public int Chance = 2;


		public int MinimumTicks = 100000000;


		public long LastTrigger;
	}
}

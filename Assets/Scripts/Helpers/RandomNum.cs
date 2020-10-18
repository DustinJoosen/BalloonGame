using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
	public static class RandomNum
	{
		private static Random rand = new Random();
		public static int GetRandom(int min, int max)
		{
			return rand.Next(min, max);
		}

		public static int GetRandom(int max)
		{
			return GetRandom(0, max);
		}
	}
}

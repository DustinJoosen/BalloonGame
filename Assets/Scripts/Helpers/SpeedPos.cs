using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
	public class SpeedPos
	{
		public float Speed { get; set; }
		public float Pos { get; set; }

		public SpeedPos(float speed, float pos)
		{
			Speed = speed;
			Pos = pos;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
	public class EasedMoving
	{
		public float EaseOut(SpeedPos speedPos)
		{
			Debug.Log("Easing out");

			speedPos.Speed -= speedPos.Speed / 3;
			speedPos.Pos -= speedPos.Speed;

			return speedPos.Pos;
		}

		private SpeedPos RecursiveMovingLeft(SpeedPos speedPos)
		{
			Debug.Log("Doing some recursing");


			if (speedPos.Speed >= 0.01)
				RecursiveMovingLeft(speedPos);

			return speedPos;
		}
	}

}

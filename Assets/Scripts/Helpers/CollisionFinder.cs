using Assets.Scripts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
	public static class CollisionFinder
	{
		public static bool IsColliding(GameObject gameobject1, GameObject gameobject2)
		{
			BasicGameObject g1 = new BasicGameObject(gameobject1);
			BasicGameObject g2 = new BasicGameObject(gameobject2);

			bool lengthCol = false;
			bool widthCol = false;

			for (float i = 0; i < g1.lengthList.Count; i++)
			{
				if (g2.lengthList.Contains(g1.lengthList[(int)i]))
					lengthCol = true;
			}

			for (float i = 0; i < g1.widthList.Count; i++)
			{
				if (g2.widthList.Contains(g1.widthList[(int)i]))
					widthCol = true;
			}

			Debug.Log(lengthCol || widthCol);
			return lengthCol || widthCol;
		}
	}
}

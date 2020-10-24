using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Dtos
{
	class BasicGameObject
	{
		public float Width { get; set; }
		public float Length { get; set; }
		public float xPos { get; set; }
		public float yPos { get; set; }
		public float zPos { get; set; }
		public List<float> widthList { get; set; }
		public List<float> lengthList { get; set; }

		public BasicGameObject(GameObject gameObject)
		{
			this.Width = gameObject.transform.localScale.x;
			this.Length = gameObject.transform.localScale.z;

			this.xPos = gameObject.transform.position.x;
			this.yPos = gameObject.transform.position.y;
			this.zPos = gameObject.transform.position.z;

			this.widthList = this.FillPositions(this.Width);
			this.lengthList = this.FillPositions(this.Length);
		}

		private List<float> FillPositions(float scale)
		{
			List<float> positions = new List<float>();
			for (float i = 0 - scale; i < scale; i++)
			{
				positions.Add(i);
			}

			return positions;
		}
	}
}

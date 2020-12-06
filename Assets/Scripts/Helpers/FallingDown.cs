using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
	public class FallingDown : MonoBehaviour
	{
		private float timeCounter = 0;
		private float speed = 2;
		private float orbit = 2;

		public void FallDown(bool destroy=true)
		{
			timeCounter += Time.deltaTime * speed;

			orbit -= 0.01f;

			float x = Mathf.Cos(timeCounter) * orbit;
			float y = this.transform.position.y - 0.3f;
			float z = Mathf.Sin(timeCounter) * orbit;

			transform.position = new Vector3(this.transform.position.x + x, y, this.transform.position.z + z);

			if (orbit < 0 && destroy)
				Destroy(gameObject);
		}
	}
}

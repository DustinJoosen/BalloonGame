using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
	public class KeyEvent
	{
		public KeyCode Key { get; set; }
		public Delegate Action { get; set; }
		
		private bool isPressing = false;

		public KeyEvent(KeyCode key, Delegate action)
		{
			this.Key = key;
			this.Action = action;
			this.isPressing = false;
		}
		
		public bool CheckIfPressing()
		{
			bool pressing = this.isPressing;

			pressing = Input.GetKeyDown(this.Key) ? true : pressing;
			pressing = Input.GetKeyUp(this.Key) ? false : pressing;

			isPressing = pressing;
			return pressing;
		}
	}
}

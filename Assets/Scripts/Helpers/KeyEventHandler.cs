using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
	public class KeyEventHandler
	{
		public List<KeyEvent> KeyEvents = new List<KeyEvent>();

		public void AddEventHandler(KeyEvent keyEvent)
		{
			KeyEvents.Add(keyEvent);
		}

		//call this method inside of the Update() method
		public void CheckKeyEvents()
		{
			foreach(KeyEvent keyEvent in this.KeyEvents)
			{
				if (keyEvent.CheckIfPressing())
					keyEvent.Action.DynamicInvoke(keyEvent.Key);
			}
		}

	}
}

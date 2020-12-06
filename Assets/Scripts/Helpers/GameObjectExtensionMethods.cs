using Assets.Scripts.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace ExtensionMethods
{
	public static class GameObjectExtensions
	{
		public static GameObject FindGameObjectWithCustomTag(this GameObject gameObject, CustomTag customTag)
		{
			return GameObject.FindGameObjectWithTag(customTag.ToString());
		}
	}

}

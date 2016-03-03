using UnityEngine;

namespace CastleBattle.Armory
{
	public class InvalidWeaponException : UnityException
	{
		public InvalidWeaponException (string message) : base (message)
		{
		}
	}
}

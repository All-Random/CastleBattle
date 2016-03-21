using System;

namespace CastleBattle.Armory
{
	public class InvalidWeaponException : Exception
	{
		public InvalidWeaponException (string message) : base (message)
		{
		}
	}
}

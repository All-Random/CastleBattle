using System;

namespace CastleBattle.Armory
{
	public class NotFoundWeaponException : Exception
	{
		public NotFoundWeaponException (string id) : base (BuildMessage(id))
		{
		}

		private static string BuildMessage (string id)
		{
			return "The weapon with id: " + id + " is not registered at the armory.";
		}
	}
}

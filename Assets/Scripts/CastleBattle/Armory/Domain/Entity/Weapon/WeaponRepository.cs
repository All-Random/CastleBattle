using System;

namespace CastleBattle.Armory
{
	public interface WeaponRepository
	{
		void Save (Weapon weapon);
		Weapon Load (string id);
		void Remove (string id);
	}
}

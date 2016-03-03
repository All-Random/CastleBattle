using System;

namespace CastleBattle.Armory
{
	public interface WeaponRepository
	{
		void Save (Weapon weapon);
		Weapon Load (int id);
		void Remove (int id);
	}
}

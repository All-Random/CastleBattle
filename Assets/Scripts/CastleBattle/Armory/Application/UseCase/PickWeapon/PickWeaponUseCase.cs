using CastleBattle.Armory;

namespace CastleBattle.Armory
{
	public class PickWeaponUseCase
	{
		private WeaponRepository weaponRepository;

		public PickWeaponUseCase (WeaponRepository weaponRepository)
		{
			this.weaponRepository = weaponRepository;
		}

		public PickWeaponResponse execute (PickWeaponRequest pickWeaponRequest) 
		{
			Weapon weapon = weaponRepository.Load (pickWeaponRequest.WeaponId);
			return new PickWeaponResponse (weapon.Id, weapon.Name, weapon.Damage, weapon.ColdDown);
		}
	}
}

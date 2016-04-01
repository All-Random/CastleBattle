using CastleBattle.Armory;

namespace CastleBattle.Armory
{
	public class RegisterWeaponUseCase
	{
		private WeaponRepository weaponRepository;

		public RegisterWeaponUseCase (WeaponRepository weaponRepository)
		{
			this.weaponRepository = weaponRepository;
		}

		public RegisterWeaponResponse execute (RegisterWeaponRequest registerWeaponRequest) 
		{
			Weapon weapon = new Weapon (registerWeaponRequest.Id, registerWeaponRequest.Name, registerWeaponRequest.Damage, registerWeaponRequest.ColdDown);
			weaponRepository.Save (weapon);
			return new RegisterWeaponResponse (weapon.Id);
		}
	}
}
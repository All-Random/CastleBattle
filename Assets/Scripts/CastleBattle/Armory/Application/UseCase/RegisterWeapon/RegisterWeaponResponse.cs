namespace CastleBattle.Armory
{
	public class RegisterWeaponResponse
	{
		private int weaponId;

		public RegisterWeaponResponse (int weaponId)
		{
			this.weaponId = weaponId;
		}

		public int WeaponId {
			get {
				return this.weaponId;
			}
		}
	}
}

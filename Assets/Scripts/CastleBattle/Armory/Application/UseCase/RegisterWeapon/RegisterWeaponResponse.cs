namespace CastleBattle.Armory
{
	public class RegisterWeaponResponse
	{
		private string weaponId;

		public RegisterWeaponResponse (string weaponId)
		{
			this.weaponId = weaponId;
		}

		public string WeaponId {
			get {
				return this.weaponId;
			}
		}
	}
}

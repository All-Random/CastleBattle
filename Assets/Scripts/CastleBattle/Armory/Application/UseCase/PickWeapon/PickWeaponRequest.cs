namespace CastleBattle.Armory
{
	public class PickWeaponRequest
	{
		private string weaponId;

		public PickWeaponRequest (string weaponId)
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

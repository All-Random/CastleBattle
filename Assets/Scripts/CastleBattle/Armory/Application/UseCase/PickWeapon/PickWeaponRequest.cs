namespace CastleBattle.Armory
{
	public class PickWeaponRequest
	{
		private int weaponId;

		public PickWeaponRequest (int weaponId)
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

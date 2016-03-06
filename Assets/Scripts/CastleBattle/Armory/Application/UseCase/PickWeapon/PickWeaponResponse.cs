namespace CastleBattle.Armory
{
	public class PickWeaponResponse
	{
		private string id;
		private string name;
		private float damage;
		private float coldDown;

		public PickWeaponResponse (string id, string name, float damage, float coldDown)
		{
			this.id = id;
			this.name = name;
			this.damage = damage;
			this.coldDown = coldDown;
		}

		public string Id {
			get {
				return this.id;
			}
		}

		public string Name {
			get {
				return this.name;
			}
		}

		public float Damage {
			get {
				return this.damage;
			}
		}

		public float ColdDown {
			get {
				return this.coldDown;
			}
		}
	}
}

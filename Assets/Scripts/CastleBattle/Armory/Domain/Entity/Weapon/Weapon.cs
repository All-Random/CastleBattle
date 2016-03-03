using UnityEngine;

namespace CastleBattle.Armory
{
	public class Weapon
	{
		private int id;
		private string name;
		private float damage;
		private float coldDown;

		public Weapon (int id, string name, float damage, float coldDown)
		{
			this.Id = id;
			this.Name = name;
			this.Damage = damage;
			this.ColdDown = coldDown;
		}

		public int Id {
			get {
				return this.id;
			}
			private set {
				if (value < 0) {
					throw new InvalidWeaponException ("The weapon should be positive");
				}
				id = value;
			}
		}

		public string Name {
			get {
				return this.name;
			}
			private set {
				if (string.IsNullOrEmpty (value)) {
					throw new InvalidWeaponException ("The weapon name can't be null or empty");
				}
				name = value;
			}
		}

		public float Damage {
			get {
				return this.damage;
			}
			private set {
				if (value < 0) {
					throw new InvalidWeaponException ("The weapon damage should be positive");
				}
				damage = value;
			}
		}

		public float ColdDown {
			get {
				return this.coldDown;
			}
			private set {
				if (value < 0) {
					throw new InvalidWeaponException ("The weapon coldDown should be positive");
				}
				coldDown = value;
			}
		}
	}
}

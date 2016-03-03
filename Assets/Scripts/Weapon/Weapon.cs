using UnityEngine;
using System.Collections;

namespace Scripts.Weapon
{
	public interface Weapon
	{
		bool Fire (GameObject target);

		ArrayList GetTargetsInRange ();

		float GetRange ();

		void SetRange (float range);

		float GetDamage ();

		void SetDamage (float damage);
	}
}
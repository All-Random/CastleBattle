using UnityEngine;
using System.Collections;

public interface Weapon
{
	bool Fire(GameObject target);
	ArrayList GetTargetsInRange();
	float GetRange ();
	void SetRange(float range);
	float GetDamage ();
	void SetDamage(float damage);
}
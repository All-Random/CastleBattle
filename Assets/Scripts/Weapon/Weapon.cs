using UnityEngine;
using System.Collections;

public interface Weapon
{
	bool Fire(GameObject target);
	ArrayList GetTargetsInRange();
}
using UnityEngine;
using System.Collections;

public class RayCastWeapon : MonoBehaviour, Weapon
{
	public float damage = 0;
	public float range = 0;
	public float timeBetweenHits = 0;

	protected GameObject currentTarget = null;
	protected ArrayList targets = new ArrayList ();

	public bool Fire (GameObject target)
	{
		currentTarget = target;
		InvokeRepeating ("DoDamage", 0, timeBetweenHits);
		return true;
	}

	private void DoDamage ()
	{
		if (currentTarget == null) {
			CancelInvoke ("DoDamage");
			return;
		}

		if (currentTarget.GetComponent<UnitManager> () != null) {	// if the hit object has the UnitManager script on it, call to deal damage
			currentTarget.GetComponent<UnitManager> ().ApplyDamage (damage);
		}
	}

	public ArrayList GetTargetsInRange ()
	{
		return targets;
	}

	void FixedUpdate ()
	{
		if (targets.Count == 0) {
			CheckRayCastForHits (Physics2D.RaycastAll (transform.position, Vector2.left, range));
			CheckRayCastForHits (Physics2D.RaycastAll (transform.position, Vector2.right, range));
		}
	}

	private void CheckRayCastForHits(RaycastHit2D[] raycastHits) 
	{
		foreach (RaycastHit2D raycastHit in raycastHits) {
			Collider2D collision = raycastHit.collider;
			if (collision.isTrigger || collision.gameObject.layer != 8) // if is not a unit ignore it
				continue;

			if (transform.tag == collision.transform.tag)	// if the player is of the same team ignore it
				continue;

			targets.Add (collision.gameObject);
		}
	}
}




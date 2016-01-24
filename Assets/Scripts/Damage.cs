using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
	public float damageAmount = 10.0f;
	public float continuousTimeBetweenHits = 0;

	private float savedTime = 0;
	private ArrayList targets;

	void Start()
	{
		targets = new ArrayList();
	}

	public void Fire(GameObject target)
	{
		if (Time.time - savedTime >= continuousTimeBetweenHits) {
			savedTime = Time.time;
			if (target.GetComponent<Health> () != null) {	// if the hit object has the Health script on it, deal damage
				target.GetComponent<Health> ().ApplyDamage (damageAmount);
			}
		}
	}

	public ArrayList GetTargets () {
		return targets;
	}

	void OnTriggerEnter2D (Collider2D collision)						// used for things like bullets, which are triggers.  
	{
		if (collision.isTrigger || collision.gameObject.layer != 8) // if is not a unit ignore it
			return;

		if (transform.parent.gameObject.tag == collision.gameObject.transform.parent.gameObject.tag)	// if the player is of the same team ignore it
				return;
		
		targets.Add(collision.gameObject);
	}
}
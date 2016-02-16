using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
	public float damageAmount = 10.0f;
	public float continuousTimeBetweenHits = 0;
	public float range = 1f;

	private ArrayList targets;
	private CircleCollider2D rangeDetector;
	private GameObject currentTarget;

	void Start ()
	{
		targets = new ArrayList (); 
		rangeDetector = gameObject.AddComponent <CircleCollider2D>();
		rangeDetector.radius = range;
		rangeDetector.isTrigger = true;
	}

	public void Fire (GameObject target)
	{
		currentTarget = target;
		InvokeRepeating ("DoDamage", 0, continuousTimeBetweenHits);
	}

	private void DoDamage ()
	{
		if (currentTarget == null) {
			CancelInvoke ("DoDamage");
			return;
		}

		if (currentTarget.GetComponent<Health> () != null) {	// if the hit object has the Health script on it, deal damage
			currentTarget.GetComponent<Health> ().ApplyDamage (damageAmount);
		}
	}

	public ArrayList GetTargets ()
	{
		return targets;
	}

	void OnTriggerEnter2D (Collider2D collision)						// used for things like bullets, which are triggers.  
	{
		if (collision.isTrigger || collision.gameObject.layer != 8) // if is not a unit ignore it
			return;

		if (transform.parent.gameObject.tag == collision.gameObject.transform.parent.gameObject.tag)	// if the player is of the same team ignore it
				return;
		
		targets.Add (collision.gameObject);
	}
}
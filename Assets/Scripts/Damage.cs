using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
	
	public float damageAmount = 10.0f;

	public float continuousTimeBetweenHits = 0;

	public GameObject explosionPrefab;

	private float savedTime = 0;
	private Move moveScript;
	private ArrayList targets;
	private GameObject target;

	void Start()
	{
		moveScript = gameObject.GetComponent<Move> ();
		targets = new ArrayList();
	}

	void Update()
	{
		if (targets.Count > 0) {
			moveScript.StopMove ();
			if (ValidTarget ()) {
				AttackTarget ();
			}
		} else {
			moveScript.ResumeMove();
		}
	}

	private bool ValidTarget () {
		ArrayList tempTargets = (ArrayList) targets.Clone();
		foreach (GameObject g in tempTargets) {
			if (g != null && g.GetComponent<Health> ().isAlive) {
				target = g;
				return true;
			} else {
				targets.Remove (g);
			}
		}
		return false;
	}

	private void AttackTarget() {
		if (Time.time - savedTime >= continuousTimeBetweenHits) {
			savedTime = Time.time;
			if (target.GetComponent<Health> () != null) {	// if the hit object has the Health script on it, deal damage
				target.GetComponent<Health> ().ApplyDamage (damageAmount);

				if (explosionPrefab != null) {
					Instantiate (explosionPrefab, transform.position, transform.rotation);
				}
			}
		}
	}



	void OnTriggerEnter2D (Collider2D collision)						// used for things like bullets, which are triggers.  
	{
//		if (this.tag == "PlayerBullet" && collision.gameObject.tag == "Player")	// if the player got hit with it's own bullets, ignore it
//				return;
		
		if (collision.isTrigger || collision.gameObject.layer != 8)
			return;

		targets.Add(collision.gameObject);
		moveScript.StopMove();

	}
}
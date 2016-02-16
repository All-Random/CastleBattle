using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour {

	Damage damage;
	Health health;
	Move move;
	GameObject target;

	// Use this for initialization
	void Start () {
		damage = gameObject.GetComponentInChildren<Damage> ();
		health = gameObject.GetComponentInChildren<Health> ();
		move = gameObject.GetComponentInChildren<Move> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;

		if (target == null) {
			if (AcquireTarget ()) {
				damage.Fire (target);
			} else {
				move.DoMove (deltaTime);
			} 
		}
	}

	void LateUpdate()
	{
		if (!health.IsAlive ()) {
			Destroy (gameObject);
		}
	}

	private bool AcquireTarget () {
		ArrayList targets = damage.GetTargets ();
		ArrayList tempTargets = (ArrayList) targets.Clone();
		foreach (GameObject g in tempTargets) {
			if (g != null && g.GetComponent<Health> ().IsAlive()) {
				target = g;
				return true;
			} else {
				targets.Remove (g);
			}
		}
		return false;
	}
}

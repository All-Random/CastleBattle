using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour {

	private Weapon weapon;
	private Health health;
	private Move move;

	private GameObject currentTarget;

	// Use this for initialization
	void Start () {
		weapon = gameObject.GetComponent<Weapon> ();
		health = gameObject.GetComponent<Health> ();
		move = gameObject.GetComponent<Move> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;

		if (currentTarget == null) {
			if (SelectTarget ()) {
				weapon.Fire (currentTarget);
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

	private bool SelectTarget () {
		ArrayList targets = weapon.GetTargetsInRange ();
		ArrayList tempTargets = (ArrayList) targets.Clone();
		foreach (GameObject g in tempTargets) {
			if (g != null && g.GetComponent<Health> ().IsAlive()) {
				currentTarget = g;
				return true;
			} else {
				targets.Remove (g);
			}
		}
		return false;
	}

	public void ApplyDamage(float amount)
	{
		if (null != health) {
			health.ApplyDamage (amount);
		} else {
			Debug.LogError ("No health script, can't apply damage");
		}
	}
}

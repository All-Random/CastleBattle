using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour {

	Weapon weapon;
	Health health;
	GameObject target;

	// Use this for initialization
	void Start () {
		weapon = gameObject.GetComponent<Weapon> ();
		health = gameObject.GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}

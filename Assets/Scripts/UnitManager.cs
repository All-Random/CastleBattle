using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Weapon;
using UnityEngine.UI;


public class UnitManager : MonoBehaviour {

	public Weapon weapon { get; private set;}
	public Health health { get; private set;}
	public float unionRange = 0.5f;
	private Move move;

	private GameObject currentTarget;
	[SerializeField]
	private int unitCount = 1;

	private bool alreadyJoined = false;
	private int teamDirection;

	// Use this for initialization
	void Start () {
		weapon = gameObject.GetComponent<Weapon> ();
		health = gameObject.GetComponent<Health> ();
		move = gameObject.GetComponent<Move> ();
		move.initialSpeed *= (float)teamDirection;
		weapon.SetRange(weapon.GetRange() * (float)teamDirection);
		unionRange *= (float)teamDirection;
	}
	
	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;

		CheckRayCastForHits (Physics2D.RaycastAll (transform.position, Vector2.right, unionRange));

		if (currentTarget == null) {
			if (SelectTarget ()) {
				weapon.Fire (currentTarget);
			} else {
				move.DoMove (deltaTime);
			} 
		}

		this.UpdateUnitCount ();
	}

	void LateUpdate()
	{
		if (!health.IsAlive () || alreadyJoined) {
			Destroy (gameObject);
		}
	}

	private void UpdateUnitCount() {
		gameObject.GetComponentInChildren<Text> () .text = unitCount.ToString();
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
			unitCount = health.unitsActualHealthPoints.Count;
		} else {
			Debug.LogError ("No health script, can't apply damage");
		}
	}

	private void CheckRayCastForHits(RaycastHit2D[] raycastHits) 
	{
		foreach (RaycastHit2D raycastHit in raycastHits) {
			Collider2D collision = raycastHit.collider;
			if (collision.isTrigger || collision.gameObject.layer != 8 || transform.GetInstanceID() == collision.transform.GetInstanceID()) // if is not a unit ignore it
				continue;

			if (transform.tag == collision.transform.tag && transform.name == collision.transform.name) {// if the player is of the same team ignore it
				UnitManager joinTargetUManager = collision.gameObject.GetComponent<UnitManager> ();
				if (joinTargetUManager.alreadyJoined)
					continue;
				joinTargetUManager.Join (gameObject);
				alreadyJoined = true;
				break;
			}

			//targets.Add (collision.gameObject);
		}
	}
		
	public void Join(GameObject unit) {
		UnitManager unitManager = unit.GetComponent<UnitManager> ();
		weapon.SetDamage(weapon.GetDamage() + unitManager.weapon.GetDamage ());
		health.maxHealthPoints = unitManager.health.maxHealthPoints;
		ArrayList unitsActualHealthPoints = (ArrayList)unitManager.health.unitsActualHealthPoints.Clone();
		foreach (float unitActualHealthPoints in unitsActualHealthPoints) {
			health.RegisterUnitActualHealth (unitActualHealthPoints);
		}
		unitCount = health.unitsActualHealthPoints.Count;
	}

	public void SetTeamDirection(int teamDirection) {
		this.teamDirection = teamDirection;
	}
}

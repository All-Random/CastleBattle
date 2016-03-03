using UnityEngine;
using System.Collections;
using CastleBattle.Armory;

public class SpawnManager : MonoBehaviour {

	public GameObject ranged;
	public GameObject mele;

	public enum TeamDirection {Right = 1, Left = -1}

	public TeamDirection teamDirection;

	// Use this for initialization
	void Start () {
		//gameObject.AddComponent (System.Type.GetType(weaponImplName));
		InvokeRepeating ("SpawnMele", 0, 0.2f);
		InvokeRepeating ("SpawnRanged", 0, 0.3f);
		Weapon a = new Weapon (0, "Sword", 0, 0);
		Debug.Log (a.Name, this);
		print (Application.persistentDataPath);
		WeaponRepositoryImp weaponRepo = new WeaponRepositoryImp ();
		weaponRepo.Save (a);
		Weapon b = weaponRepo.Load (0);
		Debug.Log (b.Name);
	}

	void SpawnRanged() 
	{
		SpawnUnit (ranged);
	}

	void SpawnMele() 
	{
		SpawnUnit (mele);
	}

	private void SpawnUnit(GameObject unitPrefab)
	{
		GameObject newUnit = Instantiate (unitPrefab);
		newUnit.GetComponent<UnitManager> ().SetTeamDirection ((int)teamDirection);
		newUnit.tag = gameObject.tag;
		newUnit.transform.position = transform.position;
		TeamColored (newUnit);
	}

	void TeamColored(GameObject unit) {
		if(teamDirection == TeamDirection.Left) unit.GetComponent<SpriteRenderer> ().color = Color.red;
	}
}


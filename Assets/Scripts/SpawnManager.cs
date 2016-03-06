using UnityEngine;
using System.Collections;
using CastleBattle.Armory;

public class SpawnManager : MonoBehaviour {

	public GameObject ranged;
	public GameObject mele;

	public enum TeamDirection {Right = 1, Left = -1}

	public TeamDirection teamDirection;

	private WeaponRepository weaponRepository;

	// Use this for initialization
	void Start () {
		//gameObject.AddComponent (System.Type.GetType(weaponImplName));
		InvokeRepeating ("SpawnMele", 0, 0.2f);
		InvokeRepeating ("SpawnRanged", 0, 0.3f);
		/*Weapon a = new Weapon ("1", "Bow", 0, 0);
		Debug.Log (a.Name, this);
		print (Application.persistentDataPath);*/
		weaponRepository = gameObject.AddComponent<WeaponRepositoryImp>();
		//weaponRepository.Save (a);
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

	void Update ()
	{
		
		/*Weapon b = weaponRepository.Load ("0");
		Debug.Log (b.Name);*/
		Weapon c = weaponRepository.Load ("1");
		Debug.Log (c.Name);
	}
}


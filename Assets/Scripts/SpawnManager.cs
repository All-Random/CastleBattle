using UnityEngine;
using System.Collections;

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
		newUnit.GetComponent<Move> ().initialSpeed *= (float)teamDirection;
		newUnit.tag = gameObject.tag;
		newUnit.transform.position = transform.position;
	}
}


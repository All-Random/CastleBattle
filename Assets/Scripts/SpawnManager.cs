using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject sword;
	public GameObject bow;
	public GameObject body;
	public GameObject baseEntity;
	public int teamDirection;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnMele", 0, 4);
		InvokeRepeating ("SpawnRanged", 0, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnRanged() {
		GameObject a = Instantiate (baseEntity);
		a.transform.position = gameObject.transform.position;
		GameObject b = Instantiate (body);
		b.GetComponent<Move> ().initialSpeed = (1 * teamDirection);
		b.transform.parent = a.transform;
		b.transform.position = a.transform.position;
		GameObject c = Instantiate (bow);
		c.transform.parent = a.transform;
		c.transform.position = a.transform.position;
		a.tag = gameObject.tag;
	}

	void SpawnMele() {
		GameObject a = Instantiate (baseEntity);
		a.transform.position = gameObject.transform.position;
		GameObject b = Instantiate (body);
		b.GetComponent<Move> ().initialSpeed = (2 * teamDirection);
		b.transform.parent = a.transform;
		b.transform.position = a.transform.position;
		GameObject c = Instantiate (sword);
		c.transform.parent = a.transform;
		c.transform.position = a.transform.position;
		a.tag = gameObject.tag;
	}
}

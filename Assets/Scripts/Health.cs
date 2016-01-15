using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float healthPoints = 1f;

	public bool isAlive = true;	

	public GameObject explosionPrefab;
	

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (healthPoints <= 0) {				// if the object is 'dead'
			isAlive = false;
		}
	}

	void LateUpdate()
	{
		if (!isAlive) {
			if (explosionPrefab!=null) {
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}
			Destroy (gameObject);
		}
	}
	
	public void ApplyDamage(float amount)
	{	
		healthPoints = healthPoints - amount;	
	}
	
	public void ApplyHeal(float amount)
	{
		healthPoints = healthPoints + amount;
	}
}

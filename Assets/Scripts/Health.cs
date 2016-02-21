using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float healthPoints = 1f;
	
	private bool alive = true;	

	private void CheckIfAlive () 
	{
		if (healthPoints <= 0) {
			alive = false;
		}
	}
	
	public bool ApplyDamage(float amount)
	{	
		ModifyHealth (amount * -1);
		return IsAlive ();
	}
	
	public void ApplyHeal(float amount)
	{
		ModifyHealth (amount);
	}

	private void ModifyHealth(float amount)
	{
		if (alive) {
			healthPoints = healthPoints + amount;
			CheckIfAlive ();
		}
	}

	public bool IsAlive()
	{
		return alive;
	}
}

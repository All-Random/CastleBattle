using UnityEngine;
using System.Collections;
using System.Linq;

public class Health : MonoBehaviour {
	
	public float maxHealthPoints = 1f;

	public ArrayList unitsActualHealthPoints { get; private set; }

	private bool alive = true;

	public void Start () {
		unitsActualHealthPoints = new ArrayList();
		if (alive) {
			unitsActualHealthPoints.Add(maxHealthPoints);
		}
	}

	private void CheckIfAlive () 
	{
		var query = from float a in unitsActualHealthPoints
		            where a > 0
		            select a;

		unitsActualHealthPoints = new ArrayList(query.ToList ());
		alive = unitsActualHealthPoints.Count > 0;
	}
	
	public void ApplyDamage(float amount)
	{	
		ModifyHealth (amount * -1);
	}
	
	public void ApplyHeal(float amount)
	{
		ModifyHealth (amount);
	}

	private void ModifyHealth(float amount)
	{
		if (alive) {
			unitsActualHealthPoints[0] = Mathf.Max(Mathf.Min( (float)unitsActualHealthPoints[0] + amount, maxHealthPoints),0);
			CheckIfAlive ();
		}
	}

	public bool IsAlive()
	{
		return alive;
	}

	public void RegisterUnitActualHealth(float unitActualHealth) {
		unitsActualHealthPoints.Add (unitActualHealth);
	}
}

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
		amount *= -1;
		while (amount != 0) {
			if (alive) {
				ModifyHealth (ref amount);
			} else {
				break;
			}
		}
	}
	
	public void ApplyHeal(float amount)
	{
		if (alive) {
			ModifyHealth (ref amount);
		}
	}

	private void ModifyHealth(ref float amount)
	{
		unitsActualHealthPoints [0] = Mathf.Min ((float)unitsActualHealthPoints [0] + amount, maxHealthPoints);
		amount = ((float)unitsActualHealthPoints [0]) < 0 ? (float)unitsActualHealthPoints [0] : 0;
		CheckIfAlive ();
	}

	public bool IsAlive()
	{
		return alive;
	}

	public void RegisterUnitActualHealth(float unitActualHealth) {
		unitsActualHealthPoints.Add (unitActualHealth);
	}
}

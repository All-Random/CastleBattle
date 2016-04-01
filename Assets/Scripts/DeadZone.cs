using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
	public void OnCollisionEnter2D (Collision2D collision)
	{
		DestroyObject (collision.gameObject);
	}
}

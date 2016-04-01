using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float initialSpeed = 0;

	private float speed;

	void Start () {
		speed = initialSpeed;
	}

	public void DoMove (float deltaTime) {
		gameObject.transform.Translate (Vector3.right * speed * deltaTime);
	}
}

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float initialSpeed = 1;


	private bool isMoving;
	private float speed;

	// Use this for initialization
	void Start () {
		speed = initialSpeed;
		isMoving = true;
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	public void StopMove(){
		if (isMoving) {
			speed = 0f;
			isMoving = false;
		}
	}

	public void ResumeMove() {
		if (!isMoving) {
			speed = initialSpeed;
			isMoving = true;
		}
	}
}

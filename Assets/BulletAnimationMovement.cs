using UnityEngine;
using System.Collections;

public class BulletAnimationMovement : MonoBehaviour {

	public GameObject target;

	private float speed = 0.5f;
	private float minDist = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null || Vector3.Distance (transform.position, target.transform.position) < minDist) {
			Destroy (gameObject);
		} else {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		}
	}
}

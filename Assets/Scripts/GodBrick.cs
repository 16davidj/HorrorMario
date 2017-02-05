using UnityEngine;
using System.Collections;

public class GodBrick : MonoBehaviour {

	private float reboundForce = 10;

	private Vector3 targetPosition;
	private Vector3 defaultPosition;
	private Transform brick;
	private bool hit = false;
	private float accumTime;

	// Use this for initialization
	void Start () {
		brick = this.GetComponent<Transform>();
	}	

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			other.attachedRigidbody.AddForce (Vector3.down * reboundForce, ForceMode.VelocityChange);

			defaultPosition = brick.position;
			targetPosition = new Vector3(brick.position.x, brick.position.y + 0.2f, brick.position.z);
			hit = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(hit == true) {
			brick.position = targetPosition;
			accumTime += Time.deltaTime;
				
			if(accumTime >= 0.1) {
				brick.position = defaultPosition;
				hit = false;
				accumTime = 0;
			}
		}
	}
}

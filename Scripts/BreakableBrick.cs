using UnityEngine;
using System.Collections;

public class BreakableBrick : MonoBehaviour {

	private float reboundForce = 10;
	private Transform brick;
	private ParticleSystem rubble;

	private bool willDestroy = false;
	private float accumTime;

	// Use this for initialization
	void Start () {
		brick = this.GetComponent<Transform> ();
		rubble = this.GetComponent<ParticleSystem>();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.attachedRigidbody.AddForce (Vector3.down * reboundForce, ForceMode.VelocityChange);
			rubble.Play ();

			brick.GetComponent<MeshRenderer>().enabled = false;
			SetAllCollidersStatus(false);
			willDestroy = true;
		}
	}

	void SetAllCollidersStatus (bool active) {
		foreach(Collider c in GetComponents<Collider> ()) {
			c.enabled = active;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (willDestroy == true) {
			accumTime += Time.deltaTime;

			if(accumTime >= 1.5){
				Destroy (brick.gameObject);
			}
		}
	}
}

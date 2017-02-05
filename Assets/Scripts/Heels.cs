using UnityEngine;
using System.Collections;

public class Heels: MonoBehaviour {
	private Transform power;
	private float accumPos;
	public Watermelon watermelon;

	// Use this for initialization
	void Start () {
		power = this.GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if (accumPos <= 1) {
			Vector3 temp = power.position;
			temp.y += 0.02f;
			power.position = temp;
			accumPos += 0.02f;
		}
	}

	void OnTriggerEnter(Collider other)	{
		if (other.tag == "Player") {
			Destroy (power.gameObject);
			if (!watermelon.speedBoosted) {
				watermelon.xForce += 500;
				watermelon.speedLimit *= 2;
				watermelon.speedBoosted = true;
			}
		}
	}

}

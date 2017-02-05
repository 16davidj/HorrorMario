using UnityEngine;
using System.Collections;

public class PowerUpTransform : MonoBehaviour {
	private Transform power;

	private float accumPos;
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
}

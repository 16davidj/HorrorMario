using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	private Transform Coin;
	private GameManager manager;

	// Use this for initialization
	void Start () {
		Coin = this.GetComponent<Transform> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameManager.coins += 1;
			Destroy (Coin.gameObject);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

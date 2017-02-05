using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	private Transform Coin;
	private GameManager manager;
	private float accumPos;
	public AudioSource coinSound;

	// Use this for initialization
	void Start () {
		Coin = this.GetComponent<Transform> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameManager.coins += 1;
			Destroy (Coin.gameObject);
			coinSound.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (accumPos <= 0.75) {
			Vector3 temp = Coin.position;
			temp.y += 0.5f;
			Coin.position = temp;
			accumPos += 0.5f;
		}
	}
}

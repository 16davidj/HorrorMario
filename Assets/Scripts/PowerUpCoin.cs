using UnityEngine;
using System.Collections;

public class PowerUpCoin : MonoBehaviour {
	private Transform mystery;
	private GameObject brick;
	private GameObject coin;
	
	private float reboundForce = 8;
	// Use this for initialization
	void Start () {
		mystery = this.GetComponent<Transform> ();
		brick = GameObject.FindGameObjectWithTag ("YungBrick");
		coin = GameObject.FindGameObjectWithTag ("Cube24");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			other.attachedRigidbody.AddForce (Vector3.down * reboundForce, ForceMode.VelocityChange);
			Instantiate (brick, mystery.transform.position, Quaternion.identity);
			Destroy (mystery.gameObject);
			Instantiate (coin, mystery.transform.position, Quaternion.identity);
		}
	}
	
}

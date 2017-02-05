using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	public GameObject mystery;
	public GameObject brick;
	public GameObject powerup;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnTriggerEnter()
	{
		Instantiate (brick, mystery.transform.position, Quaternion.identity);
		Destroy (mystery);
		Instantiate (powerup, mystery.transform.position, Quaternion.identity);
	}

}

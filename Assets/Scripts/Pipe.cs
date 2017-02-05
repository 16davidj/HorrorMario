using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	public GameObject PipeOpening;
	private GameObject Player;
	public float MoveSpeed = 0f;
	public AudioSource pipeSound;

	//Level to be loaded
	public string ToBeLoaded = " ";

	private bool AnimatePipe = false;
	private float heldDownTime = 0;
	private float AnimateTime = 0;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerStay(Collider other) {

		if(other.tag == "Player"){
			Player = other.gameObject;

			if(Input.GetKey (KeyCode.DownArrow)){
				heldDownTime += Time.deltaTime;

				if(heldDownTime >= 0.5){
					Player.GetComponent<SphereCollider>().enabled = false;
					Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
					pipeSound.Play();
					AnimatePipe = true;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (AnimatePipe == true) {
			Vector3 temp = Player.transform.position;
			temp.x = PipeOpening.transform.position.x;
			temp.y -= MoveSpeed * Time.deltaTime;
			Player.transform.position = temp;
			AnimateTime += Time.deltaTime;

			Debug.Log (AnimateTime);

			if(AnimateTime >= 1) {
				AnimatePipe = false;
				Debug.Log ("Loading levels");
				Application.LoadLevel (ToBeLoaded);
			}
		}
	}
}

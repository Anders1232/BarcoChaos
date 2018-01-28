using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {
	private Message.Crew crewMember;
	private Animator spriteAnim;
	public bool isHappy;
	public float happyDuration;
	public float happyCounter;
	public bool isAngry;
	public float angryDuration;
	public float angryCounter;
	public SessionScore score;
	// Use this for initialization
	void Start () {
		crewMember = GetComponentInChildren<BalloonController> ().crewMember;
		spriteAnim = GetComponentInChildren<Animator> ();
		score = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SessionScore>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isHappy) {
			happyCounter += Time.deltaTime;
			if (happyCounter > happyDuration) {
				spriteAnim.SetBool ("Happy", false);
				isHappy = false;
			}
		}
		if (isAngry) {
			angryCounter += Time.deltaTime;
			if (angryCounter > angryDuration) {
				spriteAnim.SetBool ("Angry", false);
				isAngry = false;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
//		SceneManager.LoadScene ("game_over");
		if (col.gameObject.tag == "Message") {
			Message msg = col.gameObject.GetComponent<Message> ();
			if (crewMember != msg.origin) {
				if (crewMember != msg.destiny) {
					spriteAnim.SetBool ("Angry", true);
					isAngry = true;
					angryCounter = 0f;
					score.WrongDestiny();
				} else {
					spriteAnim.SetBool ("Happy", true);
					isHappy = true;
					happyCounter = 0f;
					score.CorrectDestiny ();
				}
			}
			Destroy (col.gameObject);
		}
	}
}

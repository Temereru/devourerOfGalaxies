using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	
	private GameController gamecontroller;
	void Start()
	{
		GameObject GameControllerObject = GameObject.FindWithTag ("GameController");
		gamecontroller = GameControllerObject.GetComponent <GameController>();
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			gamecontroller.AsteroidInstantiation();
		}
		Destroy(other.gameObject);
	}
}

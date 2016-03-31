using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public GameObject asteroid;
	public Canvas lossCanvas;
	public Vector2 boundary;

	private Vector3 position;
	private Quaternion rotation;
	void Start () 
	{
		for (int i = 0; i < 100; i++) 
		{
			AsteroidInstantiation();
		}
	}
	
	public void Update()
	{
		if (Input.GetButton ("Cancel"))
		{
			Application.Quit();
		}
	}
	
	public void AsteroidInstantiation()
	{
		position.x = Random.Range(-boundary.x/2,boundary.x/2);
		position.y = Random.Range(-boundary.y/2,boundary.y/2);
		position.z = 0;
		Vector2 cameraPoint = Camera.main.WorldToViewportPoint(position);
		//Debug.Log ("ViewPort " + i + " is: " + cameraPoint);
		while(cameraPoint.x > 0 && cameraPoint.x < 1)
		{
			position.x = Random.Range(-boundary.x/2,boundary.x/2);
			cameraPoint = Camera.main.WorldToViewportPoint(position);
		}
		while(cameraPoint.y > 0 && cameraPoint.y < 1)
		{
			position.y = Random.Range(-boundary.y/2,boundary.y/2);
			cameraPoint = Camera.main.WorldToViewportPoint(position);
		}
		//rotation = Random.rotation;
		rotation = Quaternion.Euler(0,0,Random.Range (0,360));
		//Quaternion rotation2 = new Quaternion(rotation.x,0,rotation.z,rotation.w);
		//Instantiate(asteroid,position,rotation2);
		Instantiate(asteroid,position,rotation);
	}

	public void Restart()
	{
		Time.timeScale = 1.0f;
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void Exit()
	{
		Application.Quit();
	}
	

}

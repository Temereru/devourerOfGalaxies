using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
	
	
	
	public float speed;
	public float mass;
	public Boundary boundary;
	public bool pause;
	
	private float size;
	private Vector2 worldTouchPoint;
	private Vector2 endPos;
	private ScoreController scorecontroller;
	private bool firstRun;
	
	void Awake ()
	{
		pause = false;
		size = mass / 100;
		firstRun = true;
		transform.localScale = new Vector3 (size, size,1);
		scorecontroller = this.gameObject.GetComponent <ScoreController>();
		scorecontroller.setScoreText(mass);
	}
	
	void Update()
	{
		if(firstRun == true)
		{
			scorecontroller.setScoreText(mass);
			firstRun = false;
		}
		if (pause == false) 
		{
			if (Input.GetButton ("Fire1")) 
				{ 
					//returnes true if left mouse button or a touch is pressed
					Vector2 touchPoint = Input.mousePosition;
					worldTouchPoint = Camera.main.ScreenToWorldPoint (touchPoint);
					transform.position = Vector2.MoveTowards (transform.position, worldTouchPoint, speed);
					rigidbody2D.position = new Vector2 
					(
					Mathf.Clamp (rigidbody2D.position.x, boundary.xMin + size / 2, boundary.xMax - size / 2),  
					Mathf.Clamp (rigidbody2D.position.y, boundary.yMin + size / 2, boundary.yMax - size / 2)
					);
				} 
		}
		
	}
	
	public void setSize(float addedMass)
	{
		mass += addedMass;
		size = mass / 100;
		transform.localScale = new Vector3 (size, size,1);
		scorecontroller.setScoreText(mass);
	}

	public void setPause(bool p)
	{
		pause = p;
	}
	
	public float getMass()
	{
		return mass;
	}
	
	
	
	
}

using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
	
	
	public float mass;
	public float speed;
	private float size;
	private float resizer;
	private float sqrdResizer;
	private float preMass;
	// Use this for initialization
	void Awake() 
	{
		preMass = Random.Range (1, 100);
		resizer =  Random.Range(0.0f,1.0f);
		sqrdResizer = resizer * resizer;
		mass = preMass * sqrdResizer;
		if(mass < 1)
		{
			mass = 1;
		}
		size = mass / 100;
		//speed = Random.Range (0.04f,0.1f);
		transform.localScale = new Vector3 (size, size, 1);
		rigidbody2D.velocity = transform.up * speed;
	}
	
	public float getMass()
	{
		return mass;
	}
	
}

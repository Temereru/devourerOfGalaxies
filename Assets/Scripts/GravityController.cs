using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GravityController : MonoBehaviour 
{
	private PlayerController playerController;
	private AsteroidController asteroidController;
	private GameController gamecontroller;
	private GameObject PlayerControllerObject;
	private GameObject AsteroidControllerObject;
	
	public float enemyMass;
	public float playerMass;
	public Canvas lossCanvas;
	public Canvas winCanvas;
	
	private bool hit;
	
	void Start()
	{
		PlayerControllerObject = GameObject.FindWithTag ("Player");		
		GameObject GameControllerObject = GameObject.FindWithTag ("GameController");
		gamecontroller = GameControllerObject.GetComponent <GameController>();
		/* getting player controller */
		if (PlayerControllerObject != null)
		{
			playerController = PlayerControllerObject.GetComponent <PlayerController>();
		}
		if (playerController == null)
		{
			Debug.Log ("Cannot find 'PlayerController' script");
		}
		/* getting asteroid controller */
		
		playerMass = playerController.getMass ();
		if(playerMass == 0)
		{
			Debug.Log("there is no Player mass");
		}
		hit = false;
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Background" || other.tag == "Boundary")
		{
			return;
		}
		else if(other.tag == "Enemy")
		{
			Debug.Log ("pull");
			AsteroidControllerObject = other.gameObject;
			if (AsteroidControllerObject != null)
			{
				asteroidController = AsteroidControllerObject.GetComponent <AsteroidController>();
			}
			if (asteroidController == null)
			{
				Debug.Log ("Cannot find 'AsteroidController' script");
			}
			enemyMass = asteroidController.getMass ();
			if(enemyMass == 0)
			{
				Debug.Log ("there is no enemy Mass");
			}
			if (playerMass >= enemyMass) 
			{
				//Vector3 direction = (other.transform.position - transform.parent.position);
				//AsteroidControllerObject.rigidbody2D.constantForce.force = direction;	
				AsteroidControllerObject.transform.position = Vector2.MoveTowards(other.transform.position, transform.position, 0.0035f);
				Debug.Log (Vector2.Distance(other.transform.position,transform.position));
				Debug.Log ((other.transform.localScale.x)/2 + (transform.localScale.x)/2);
				//Debug.Log ("direction = " + direction);	
			}
			else
			{
				//PlayerControllerObject.rigidbody2D.constantForce.force = direction;
				PlayerControllerObject.transform.position = Vector2.MoveTowards(transform.position, other.transform.position, 0.0035f);
				Debug.Log (Vector2.Distance(other.transform.position,transform.position));
				Debug.Log (other.transform.localScale.x/2 + transform.localScale.x/2);
				//Debug.Log ("direction = " + direction);
			}
		}
		
	}
	public void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Background" || other.tag == "Boundary")
		{
			return;
		}
		else if(other.tag == "Enemy" && hit == false)
		{
			Debug.Log ("pull");
			AsteroidControllerObject = other.gameObject;
			if (AsteroidControllerObject != null)
			{
				asteroidController = AsteroidControllerObject.GetComponent <AsteroidController>();
			}
			if (asteroidController == null)
			{
				Debug.Log ("Cannot find 'AsteroidController' script");
			}
			enemyMass = asteroidController.getMass ();
			if(enemyMass == 0)
			{
				Debug.Log ("there is no enemy Mass");
			}
			if (playerMass >= enemyMass) 
			{
				//Vector3 direction = (other.transform.position - transform.parent.position);
				//AsteroidControllerObject.rigidbody2D.constantForce.force = direction;	
				AsteroidControllerObject.transform.position = Vector2.MoveTowards(other.transform.position, transform.position, 0.0035f);
				//Debug.Log (Vector2.Distance(other.transform.position,transform.position));
				if(other.transform.localScale.x/2 + transform.localScale.x/2 >= Vector2.Distance(other.transform.position,transform.position))
				{
					Destroy (other.gameObject);
					playerController.setSize(enemyMass/4);
					playerMass = playerController.getMass ();
					gamecontroller.AsteroidInstantiation();
					if(playerMass >= 100)
					{
						Time.timeScale = 0.0f;
						playerController.setPause(true);
						Instantiate(winCanvas, PlayerControllerObject.transform.position, Quaternion.Euler(0.0f,0.0f,0.0f));
						GameObject scoreText = GameObject.FindWithTag ("scoreText");
						GameObject restartButton = GameObject.FindWithTag ("restartButton");
						GameObject quitButton = GameObject.FindWithTag ("quitButton");
						Text scoreTextText = scoreText.GetComponent <Text>();
						playerMass = playerController.getMass ();
						scoreTextText.text = "Your Score is: " + playerMass.ToString("n2");
						Button restartButtonButton = restartButton.GetComponent <Button>();
						Button quitButtonButton = quitButton.GetComponent <Button>();
						restartButtonButton.onClick.AddListener(gamecontroller.Restart);
						quitButtonButton.onClick.AddListener(gamecontroller.Exit);
						hit = true;
					}
				}
				//Debug.Log ("direction = " + direction);	
			}
			else
			{
				//PlayerControllerObject.rigidbody2D.constantForce.force = direction;
				PlayerControllerObject.transform.position = Vector2.MoveTowards(transform.position, other.transform.position, 0.0035f);
				//Debug.Log (Vector2.Distance(other.transform.position,transform.position));
				if(other.transform.localScale.x/2 + transform.localScale.x/2 >= Vector2.Distance(other.transform.position,transform.position))
				{
					hit = true;
					Time.timeScale = 0.0f;
					playerController.setPause(true);
					Instantiate(lossCanvas, PlayerControllerObject.transform.position, Quaternion.Euler(0.0f,0.0f,0.0f));
					GameObject scoreText = GameObject.FindWithTag ("scoreText");
					GameObject restartButton = GameObject.FindWithTag ("restartButton");
					GameObject quitButton = GameObject.FindWithTag ("quitButton");
					Text scoreTextText = scoreText.GetComponent <Text>();
					playerMass = playerController.getMass ();
					scoreTextText.text = "Your Score is: " + playerMass.ToString("n2");
					Button restartButtonButton = restartButton.GetComponent <Button>();
					Button quitButtonButton = quitButton.GetComponent <Button>();
					restartButtonButton.onClick.AddListener(gamecontroller.Restart);
					quitButtonButton.onClick.AddListener(gamecontroller.Exit);
				}
				//Debug.Log ("direction = " + direction);
			}
		}
	}
	
	
	public void OnTriggerExit2D(Collider2D other)
	{
	}
	
	
}

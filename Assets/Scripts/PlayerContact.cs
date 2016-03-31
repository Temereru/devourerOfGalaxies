using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerContact : MonoBehaviour 
{

	private PlayerController playerController;
	private AsteroidController asteroidController;
	private GameController gamecontroller;
	private GameObject PlayerControllerObject;

	public float enemyMass;
	public float playerMass;
	public Canvas lossCanvas;
	public Canvas winCanvas;
	void Start()
	{
		PlayerControllerObject = GameObject.FindWithTag ("Player");
		GameObject AsteroidControllerObject = gameObject;
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
		if (AsteroidControllerObject != null)
		{
			asteroidController = AsteroidControllerObject.GetComponent <AsteroidController>();
		}
		if (asteroidController == null)
		{
			Debug.Log ("Cannot find 'AsteroidController' script");
		}
		enemyMass = asteroidController.getMass ();
		playerMass = playerController.getMass ();
		if(enemyMass == 0)
		{
			Debug.Log ("there is no enemy Mass");
		}
		if(playerMass == 0)
		{
			Debug.Log("there is no Player mass");
		}
	}

/*	public void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.tag == "Background" || other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "eGravity")
		{
			//Debug.Log (other.tag);
			return;
		}
		if(other.tag == "Player")
		{
			Debug.Log ("should have contact");
			playerMass = playerController.getMass ();
		}
		if (playerMass >= enemyMass) 
		{
			Destroy (gameObject);
			playerController.setSize(enemyMass/4);
			playerMass = playerController.getMass ();
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
			}
			gamecontroller.AsteroidInstantiation();
		} 
		else 
		{	
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
			//Destroy(other.gameObject);
		}	
		
	
	}
/*	public void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Background" || other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "eGravity")
		{
			//Debug.Log (other.tag);
			return;
		}
		if(other.tag == "Player")
		{
			Debug.Log ("should have contact");
			playerMass = playerController.getMass ();
		}
		if (playerMass >= enemyMass) 
		{
			Destroy (gameObject);
			playerController.setSize(enemyMass/4);
			playerMass = playerController.getMass ();
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
			}
			gamecontroller.AsteroidInstantiation();
		} 
		else 
		{	
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
			//Destroy(other.gameObject);
		}	
	} */

	
	
}

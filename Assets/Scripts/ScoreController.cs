using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
	
	
	public Text scoreText;
	void Start () 
	{
		scoreText.text = "Mass: 0";
	}
	
	public void setScoreText(float score)
	{
		scoreText.text = "Mass: " + score.ToString("n2");
	}
}

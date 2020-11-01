using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	public GameObject youfinishText;
	public GameObject RestartButton;
	public GameObject MenuButton; 
	void Awake()                                    //check if only one GameManager is running 
	{ 
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != null)
			Destroy(gameObject);				   //destroy if an instance is already running
	}

	public void Win()
	{
		youfinishText.SetActive(true);				//set visibility to true after crossing finish line 
		RestartButton.SetActive(true);
		MenuButton.SetActive(true);
		Time.timeScale = 0.5f;						//slowmotion after crossing the line
	}

}

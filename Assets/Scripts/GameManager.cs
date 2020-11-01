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
	public float resetDelay;
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != null)
			Destroy(gameObject);
	}

	public void Win()
	{
		youfinishText.SetActive(true);
		RestartButton.SetActive(true);
		MenuButton.SetActive(true);
	}

}

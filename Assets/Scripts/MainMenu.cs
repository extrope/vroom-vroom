using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void ReturnMenu()
	{
		Time.timeScale = 1f;                        //revert timescale back to one after finishing race
		SceneManager.LoadScene("Menu");            //go to main menu after pushing the button
	}
}

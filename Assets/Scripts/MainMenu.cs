﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void ReturnMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}
}

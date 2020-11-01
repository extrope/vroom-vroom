using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
		Time.timeScale = 1f;                 //revert timescale back to one after finishing race
		SceneManager.LoadScene("Race");      //restart race after pushing the button
    }
}

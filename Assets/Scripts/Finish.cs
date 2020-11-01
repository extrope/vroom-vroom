using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
	void OnTriggerEnter()
    {
		GameManager.instance.Win();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class Extensions {
	public static T GetOnlyComponent<T>(this GameObject gameObject) {
		return AssertPlus.OnlyOne(gameObject.GetComponents<T>());
	}
	
	public static GameObject GetParent(this GameObject gameObject) {
		return gameObject.transform.parent.gameObject;
	}
	
	public static int GetChildCount(this GameObject gameObject) {
		return gameObject.transform.childCount;
	}
	
	public static IEnumerable<GameObject> GetChildren(this GameObject gameObject) {
		foreach (Transform childTransform in gameObject.transform) {
			yield return childTransform.gameObject;
		}
	}
	
	public static GameObject GetChild(this GameObject gameObject, string name) {
		foreach (var child in gameObject.GetChildren()) {
			if (name == child.name) {
				return child;
			}
		}
		return null;
	}
	
	public static GameObject GetDescendant(this GameObject gameObject, params string[] path) {
		foreach (var name in path) {
			gameObject = gameObject.GetChild(name);
		}
		return gameObject;
	}
}

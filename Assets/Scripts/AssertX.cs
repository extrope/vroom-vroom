using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class AssertPlus {
	public static T OnlyOne<T>(T[] array) {
		Assert.IsTrue(array.Length == 1, "There were none or multiple values.");
		return array[0];
	}
	
	public static T AreEqual<T>(T first, IEnumerator<T> others) {
		Utils.ForEach(others, other => Assert.AreEqual(first, other));
		return first;
	}
	
	public static T AreEqual<T>(T first, IEnumerable<T> others) {
		return AssertPlus.AreEqual(first, others.GetEnumerator());
	}
	
	public static T AreEqual<T>(IEnumerator<T> values) {
		(var first, var rest) = Utils.FirstRest(values);
		AssertPlus.AreEqual(first, rest);
		return first;
	}
	
	public static T AreEqual<T>(IEnumerable<T> values) {
		return AssertPlus.AreEqual(values.GetEnumerator());
	}
}

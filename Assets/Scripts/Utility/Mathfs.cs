using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathfs : MonoBehaviour
{
	/// <summary>Exponential interpolation, the multiplicative version of lerp, useful for values such as scaling or zooming</summary>
	/// <param name="a">The start value</param>
	/// <param name="b">The end value</param>
	/// <param name="t">The t-value from 0 to 1 representing position along the lerp</param>
	public static float Eerp(float a, float b, float t) => Mathf.Pow(a, 1 - t) * Mathf.Pow(b, t);

	/// <summary>Inverse exponential interpolation, the multiplicative version of InverseLerp, useful for values such as scaling or zooming</summary>
	/// <param name="a">The start value</param>
	/// <param name="b">The end value</param>
	/// <param name="v">A value between a and b. Note: values outside this range are still valid, and will be extrapolated</param>
	public static float InverseEerp(float a, float b, float v) => Mathf.Log(a / v) / Mathf.Log(a / b);
}

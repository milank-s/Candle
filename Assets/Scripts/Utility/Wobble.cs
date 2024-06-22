using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WobbleValue {
	[HideInInspector]
	public float value = 0f, velocity = 0f, dampingFactor = 0f, acceleration = 0f;
	[Header("Parameters")]
    public float stiffness = 160f;
    public float damping = 10f;
}

[System.Serializable]
public class WobbleValue2 {
    [Header("Parameters")]
    public WobbleValue wobbleValueX;
    public WobbleValue wobbleValueY;
    public WobbleValue2(){
        wobbleValueX = new WobbleValue();
        wobbleValueY = new WobbleValue();
    }
}

[System.Serializable]
public class WobbleValue3 {
    [Header("Parameters")]
    public WobbleValue wobbleValueX;
    public WobbleValue wobbleValueY;
    public WobbleValue wobbleValueZ;
    public WobbleValue3(){
        wobbleValueX = new WobbleValue();
        wobbleValueY = new WobbleValue();
        wobbleValueZ = new WobbleValue();
    }
}

public class Wobble : MonoBehaviour
{
    /// <summary>
	/// Make WobbleValue.value follow a float like a spring. Should be called in Fixed Update.
	/// </summary>
	/// <param name="wobbleValue_">WobbleValue that follows.</param>
	/// <param name="targetValue_">Target Value.</param>
	/// <returns>the updated value</returns>
    public static float WobbleFollow(WobbleValue wobbleValue_, float targetValue_) {

        wobbleValue_.dampingFactor = Mathf.Max (0, 1 - wobbleValue_.damping * Time.fixedDeltaTime);
        wobbleValue_.acceleration = (targetValue_ - wobbleValue_.value) * wobbleValue_.stiffness * Time.fixedDeltaTime;
        wobbleValue_.velocity = wobbleValue_.velocity * wobbleValue_.dampingFactor + wobbleValue_.acceleration;
        wobbleValue_.value += wobbleValue_.velocity * Time.fixedDeltaTime;

        if (Mathf.Abs (wobbleValue_.value - targetValue_) < 0.001f && Mathf.Abs (wobbleValue_.velocity) < 0.001f) {
            wobbleValue_.value = targetValue_;
            wobbleValue_.velocity = 0f;
        }
       
        return wobbleValue_.value;
    }

    /// <summary>
    /// Make WobbleValue2.values follow a Vector2 like a spring. Should be called in Fixed Update.
    /// </summary>
    /// <param name="wobbleValue2_">WobbleValue2 that follows</param>
    /// <param name="targetVector2_">Target Vector2</param>
    /// <returns></returns>
    public static Vector2 WobbleFollow(WobbleValue2 wobbleValue2_, Vector2 targetVector2_) {
        WobbleFollow(wobbleValue2_.wobbleValueX, targetVector2_.x);
        WobbleFollow(wobbleValue2_.wobbleValueY, targetVector2_.y);

        return new Vector2(
            wobbleValue2_.wobbleValueX.value, 
            wobbleValue2_.wobbleValueY.value);
    }

    /// <summary>
    /// Make WobbleValue3.values follow a Vector3 like a spring. Should be called in Fixed Update.
    /// </summary>
    /// <param name="wobbleValue3_">WobbleValue3 that follows</param>
    /// <param name="targetVector3_">Target Vector3</param>
    /// <returns></returns>
    public static Vector3 WobbleFollow(WobbleValue3 wobbleValue3_, Vector3 targetVector3_) {
        WobbleFollow(wobbleValue3_.wobbleValueX, targetVector3_.x);
        WobbleFollow(wobbleValue3_.wobbleValueY, targetVector3_.y);
        WobbleFollow(wobbleValue3_.wobbleValueZ, targetVector3_.z);

        return new Vector3(
            wobbleValue3_.wobbleValueX.value, 
            wobbleValue3_.wobbleValueY.value, 
            wobbleValue3_.wobbleValueZ.value);
    }
}

using System;
using UnityEngine;
using Random = System.Random;

public class MathExtra : MonoBehaviour
{
    public static Vector3 Round( Vector3 vector3, int decimalPlaces = 1)
    {
        float multiplier = 1;
        for (int i = 0; i < decimalPlaces; i++)
        {
            multiplier *= 10f;
        }
        return new Vector3(
            Mathf.Round(vector3.x * multiplier) / multiplier,
            Mathf.Round(vector3.y * multiplier) / multiplier,
            Mathf.Round(vector3.z * multiplier) / multiplier);
    }

    public static float RoundQuater(double value)
    {
        var result = Math.Round (value * 4, MidpointRounding.ToEven) / 4;
        return (float)result;
    }

}

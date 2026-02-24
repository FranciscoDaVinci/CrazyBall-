using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersChecksPoint : MonoBehaviour
{
    public Vector3 scale;
    public float radius;
    public Vector3 position;

    public ParametersChecksPoint(Vector3 scale, float radius, Vector3 position)
    {
        this.scale = scale;
        this.radius = radius;
        this.position = position;
    }
}

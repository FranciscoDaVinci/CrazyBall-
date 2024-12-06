using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersChecksPoint : MonoBehaviour
{
    public object[] checkPointParameters;

    public ParametersChecksPoint(params object[] cp)
    {
        checkPointParameters = cp; 
    }
}

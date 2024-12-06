using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    List<ParametersChecksPoint> _checkPoints = new List<ParametersChecksPoint>();

    public void SetPoints(params object[] points)
    {
        var checkPoint = new ParametersChecksPoint(points);
        _checkPoints.Add(checkPoint);
    }
    
    public bool HaveReferences()
    {
        return _checkPoints.Count > 0;
    }

    public ParametersChecksPoint GoBack()
    {
        var c = _checkPoints[_checkPoints.Count - 1];
        _checkPoints.RemoveAt(_checkPoints.Count - 1);
        return c;
    }
}

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class CaboSplines : MonoBehaviour
{
    [Header("Referencia")]
    public SplineContainer splineContainer;
    public Transform pinoDinamico;
    
    [Header("Configurações")]
    public int indexPoint = 1;
    

    // Update is called once per frame
    void Update()
    {
        if (splineContainer != null && pinoDinamico != null)
        {
            UpdateSplinePoint();
        }
    }

    void UpdateSplinePoint()
    {
        Spline spline = splineContainer.Spline;
        
        BezierKnot movePoint = spline[indexPoint];
        
        Vector3 localPosition = splineContainer.transform.InverseTransformPoint(pinoDinamico.position);

        movePoint.Position = localPosition;
        
        Vector3 localDirection = splineContainer.transform.InverseTransformDirection(pinoDinamico.forward);
        movePoint.TangentIn = localDirection * -2.0f;
        movePoint.TangentOut = Vector3.zero;

        float3 startPosition = movePoint.TangentIn;
        float3 endPosition = movePoint.TangentOut;
        float3 splineTanget = (endPosition - startPosition) * 1.5f;
        
        
        spline[indexPoint] = movePoint;
        movePoint.TangentIn = splineTanget;

    }
}

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SplineBehavior : MonoBehaviour
{
    [Header("Referencia")]
    public SplineContainer splineContainer;
    public Transform pinoDinamico;
    public Transform pointReference;
    public Transform pointStatic;
    
    [Header("Configurações")]
    public int indexPoint = 0;
    private int indexPointStatic = 1;

    [Tooltip("Curva do cabo spline")]
    public float rigidezCabo = 0.5f;
    
    public Vector3 offset = new Vector3(0, 0, -1);
    

    // Update is called once per frame
    void Update()
    {
        if (splineContainer != null && pinoDinamico != null)
        {
            UpdateSplinePoint(pointReference);
            //UpdateSplinePointwhenDropped(pointStatic);
        }
    }

    void UpdateSplinePointwhenDropped(Transform t)
    {
        Spline spline = splineContainer.Spline;
        BezierKnot noKnot = spline[indexPointStatic];

        noKnot.Position = splineContainer.transform.InverseTransformPoint(t.position);
        noKnot.Rotation = Quaternion.Inverse(splineContainer.transform.rotation) * t.rotation;
        
        Vector3 point = noKnot.Position;
        Vector3 tangentLocal = splineContainer.transform.InverseTransformDirection(point);

        noKnot.TangentIn = tangentLocal * rigidezCabo;
        noKnot.TangentOut = Vector3.zero;
        
        spline[indexPointStatic] = noKnot;
    }
    

    void UpdateSplinePoint(Transform t)
    {
        Spline spline = splineContainer.Spline;
        BezierKnot noKnot = spline[indexPoint];
      
        noKnot.Position = splineContainer.transform.InverseTransformPoint(t.position);
        noKnot.Rotation = Quaternion.Inverse(splineContainer.transform.rotation) * t.rotation;

        Vector3 worldDirection = t.TransformDirection(offset);
        Vector3 tangenteLocal = splineContainer.transform.InverseTransformDirection(worldDirection);

        noKnot.TangentIn = tangenteLocal * rigidezCabo;
        noKnot.TangentOut = Vector3.zero;
        
        spline[indexPoint] = noKnot;

        /*Vector3 localPosition = splineContainer.transform.InverseTransformPoint(pinoDinamico.position);

        noKnot.Position = localPosition;

        Vector3 localDirection = splineContainer.transform.InverseTransformDirection(pinoDinamico.forward);
        noKnot.TangentIn = localDirection * -2.0f;
        noKnot.TangentOut = Vector3.zero;

        float3 startPosition = noKnot.TangentIn;
        float3 endPosition = noKnot.TangentOut;
        float3 splineTanget = (endPosition - startPosition) * 1.5f;


        spline[indexPoint] = noKnot;
        noKnot.TangentIn = splineTanget;
    */
    }
}


/*
 Posição Inicial para Spline
    Spline point ou Knob [0]
 1. Determina a psoição do cabo com pino
    faz o set start position para o spline point [0]
    com isso, é pego o spline mesh point transform e o location da SceneRed (que é algo para indicar aonde o spline point deve seguir) 
    com isso faz o inverse transform location do transform do spline com a locaiton da SceneRed para indicar o set start position da spline point 0
    (flag update mesh ativado)            
 
 2. Determina a tangente do cabo posicionado no pino
    set start tanget para o spline point [0]
    pega a location da start position e end position do spline point [0] (end position - start position)
    com este resultado é multiplicado por um float "curva" (entre 1.0-3.0)
    (flag update mesh ativado)
 */

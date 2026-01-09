using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class SplineBehavior : MonoBehaviour
{
    [Header("Referencia para cada Object")] 
    public SplineContainer splineContainer;
    
    // Transform's para seguir o spline junto com pino
    public Transform pinoDinamico;  // lugar que o spline point[0] seguirá o pino
    public Transform cableToFollow; // lugar que o spline point[1] seguirá para o cabo não ficar deformado
    
    // Confere se está pego ou não o Pino
    private bool isGrabbed;
    private bool activeLerp = true;

    //Indices de cada spline point deve iniciar 
    private int indexPoint = 0;
    private int indexPointToFollow = 1;
    
    // Relacionado ao material cabo da spline
    [Header("Curva do cabo Spline")] 
    public float rigidezCabo = 0.5f;
    
    [Header("Suavização do Lerp")]
    [SerializeField]
    private float velocidadeLerp = 10f;
    
    
    // Função colocada no Evento de Select Entered do PinoBehavior, porque é lá que ocorre o Grab
    // pre-condicao: nenhum
    // pos-condicao: retorna que esta sendo pego
    public void onGrab()
    {
        isGrabbed = true;
        //Debug.Log("pego");
    }

    // Função colocada no Evento de Select Exited do PinoBehavior, porque é lá que ocorre o Drop
    // pre-condicao: nenhum
    // pos-condicao: retorna que foi solto
    public void onDrop()
    {
        isGrabbed = false;
        //Debug.Log("solto");
    }

    
    // Função principal para atualizar o spline enquanto interage com a bateria
    // pre-condicao: index definido para qual parte do spline moverá, Transform para o cabo seguir o pino,
    //               e o booleano é importante para definir se o cabo irá mover suavemente ou não 
    // pos-condicao: retorna o movimento suave do pino quando pego e quando solto
    void UpdateSplinePoint(int index, Transform t, bool lerp)
    {
        Spline spline = splineContainer.Spline;

        if (index >= spline.Knots.Count()) return; // condição para indicar se o index existe ou não
        
        BezierKnot noKnot = spline[index];
        
        Vector3 localPosition = splineContainer.transform.InverseTransformPoint(t.position);
        noKnot.Position = localPosition;

        Vector3 worldTangentPos = t.forward;
        Vector3 localDirectionTangent = splineContainer.transform.InverseTransformDirection(worldTangentPos *-Math.Abs(rigidezCabo));
        
        if (lerp)
        {
            float lerpStep = Time.deltaTime * velocidadeLerp;
            noKnot.Position = Vector3.Lerp(noKnot.Position, localPosition, lerpStep);
            noKnot.TangentIn = Vector3.Lerp(noKnot.TangentIn, localDirectionTangent, lerpStep);
        }
        else
        {
            noKnot.Position = localPosition;
            noKnot.TangentIn = localDirectionTangent;
        }
        
        noKnot.TangentOut = Vector3.zero;
        spline[index] = noKnot;
    }
    
    // Função atualizada a cada frame para que o spline esteja se movendo naturalmente
    void Update()
    {
        // Condição inicial para ver se ambos Spline e o Transform do pino existem
        if (splineContainer != null && pinoDinamico != null)
        {
            // caso existir, fará o update do spline point (Knot) [0] para o transform do Pino para seguir,
            // e não ativa o lerp
            UpdateSplinePoint(indexPoint, pinoDinamico, !activeLerp);

            // Condição para caso seja pego
            if (isGrabbed)
            {
                // caso existir, fará o update do spline point (Knot) [1] para o gameObject ao lado para nao ficar deformado o cabo
                // o lerp é ativado para ir suavemente ao lado
                UpdateSplinePoint(indexPointToFollow, cableToFollow, activeLerp);
            }
        }
    }
    
}
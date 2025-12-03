using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;


public class MenuUI : MonoBehaviour
{
    [SerializeField] private TeleportationProvider provider;
    [SerializeField] private Transform destino;



    public void Teleport()
    {
        if (provider != null && destino != null) 
        {
            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = destino.position,
                destinationRotation = destino.rotation,
                matchOrientation = MatchOrientation.TargetUpAndForward
            };
            provider.QueueTeleportRequest(request);
        }
    }


public void Sair()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
        
        //isso será para o editor, que faz a função de desativar o playmode do editor e voltar ao editor normalmente
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

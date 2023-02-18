using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHide : PlayerInputActionPossibility, IInputAbility, IPunObservable
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private SkinnedMeshRenderer playerSkinnedRenderer;
    [SerializeField] private Material playerMaterial;
    private Material thisPlayerMaterial;
    private bool executeHideActions;
    private float materialHideTime = 1;
    private float currentHideActionTime;
    private string hideMaterialPropertyName = "Vector1_bad362c3d9cd4b628db70be4da5de212";

    private protected override void OnStart()
    {
        thisPlayerMaterial = new Material(playerMaterial);
        thisPlayerMaterial.SetFloat(hideMaterialPropertyName, 1);

        foreach(MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material = thisPlayerMaterial;
        }
        playerSkinnedRenderer.material = thisPlayerMaterial;
    }

    private void Update()
    {
        if (executeHideActions)
        {
            currentHideActionTime += Time.deltaTime;

            if (currentHideActionTime <= 1.1f)
            {
                materialHideTime -= Time.deltaTime;
                if (materialHideTime <= 0)
                {
                    materialHideTime = 0;
                }
                thisPlayerMaterial.SetFloat(hideMaterialPropertyName, materialHideTime);
            }
            else if (currentHideActionTime >= 6f)
            {
                materialHideTime += Time.deltaTime;
                if (materialHideTime >= 1)
                {
                    materialHideTime = 1;
                }
                thisPlayerMaterial.SetFloat(hideMaterialPropertyName, materialHideTime);
            }

            if (currentHideActionTime >= 7.1f)
            {
                executeHideActions = false;
                currentHideActionTime = 0;
            }
        }
    }

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        if (CanActionExecute)
        {
            executeHideActions = true;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(executeHideActions);
        }
        else if (stream.IsReading)
        {
            executeHideActions = (bool)stream.ReceiveNext();
        }
    }
}

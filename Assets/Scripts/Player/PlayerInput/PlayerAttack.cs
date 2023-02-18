using System.Collections;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : PlayerInputActionPossibility, IInputAbility, IOnEventCallback
{
    [SerializeField] private TrailRenderer swordTrail;
    [SerializeField] private Rigidbody bulletRigidbody;
    [SerializeField] private Transform transformForDuraction;
    [SerializeField] private Transform bulletStartTransform;
    [SerializeField] private float bulletSpeed;

    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    private string attackParameterName = "Attack";

    private protected override void OnStart()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        bulletRigidbody.gameObject.transform.SetParent(null);
        bulletRigidbody.gameObject.transform.position = new Vector3(0, -3, 0);
    }

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        if (CanActionExecute)
        {
            playerAnimator.SetTrigger(attackParameterName);

            StartCoroutine(ThrowBullet());
        }
    }

    private IEnumerator ThrowBullet()
    {
        yield return new WaitForSeconds(0.4f);

        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.angularVelocity = Vector3.zero;
        bulletRigidbody.transform.SetPositionAndRotation(
            bulletStartTransform.position, bulletStartTransform.rotation);
        swordTrail.Clear();

        Vector3 duraction = (transform.position - transformForDuraction.position).normalized;
        bulletRigidbody.AddForce(duraction * bulletSpeed + playerRigidbody.velocity,
            ForceMode.Impulse);
        
        PhotonNetwork.AddCallbackTarget(this);

        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        SendOptions sendOptions = new SendOptions { Reliability = true };
        PhotonNetwork.RaiseEvent(42, true, raiseEventOptions, sendOptions);
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 42)
        {
            swordTrail.Clear();
        }
    }
}

using Photon.Pun;
using UnityEngine;

public class PlayerInputActions : MonoBehaviour
{
    [SerializeField] private MonoBehaviour playerJekr;
    [SerializeField] private MonoBehaviour playerAttack;
    [SerializeField] private MonoBehaviour playerMove;
    [SerializeField] private MonoBehaviour playerHide;
    [SerializeField] private MonoBehaviour playerInventory;
    [SerializeField] private MonoBehaviour playerSave;
    [SerializeField] private MonoBehaviour playerLoad;
    private PlayerInputControls inputControls;

    private void Start()
    {
        if (PhotonView.Get(gameObject).IsMine)
        {
            inputControls = new PlayerInputControls();
            inputControls.Keyboard.Enable();
            if (playerJekr is IInputAbility)
            {
                inputControls.Keyboard.Jerk.started += (playerJekr as IInputAbility).ExecuteInputAbility;
            }
            if (playerAttack is IInputAbility)
            {
                inputControls.Keyboard.Attack.started += (playerAttack as IInputAbility).ExecuteInputAbility;
            }
            if (playerMove is IInputAbility)
            {
                inputControls.Keyboard.Move.started += (playerMove as IInputAbility).ExecuteInputAbility;
                inputControls.Keyboard.Move.performed += (playerMove as IInputAbility).ExecuteInputAbility;
                inputControls.Keyboard.Move.canceled += (playerMove as IInputAbility).ExecuteInputAbility;
            }
            if (playerHide is IInputAbility)
            {
                inputControls.Keyboard.Hide.started += (playerHide as IInputAbility).ExecuteInputAbility;
            }
            if (playerInventory is IInputAbility)
            {
                inputControls.Keyboard.Inventory.started += (playerInventory as IInputAbility).ExecuteInputAbility;
            }

            if (playerSave is IInputAbility)
            {
                inputControls.Keyboard.Save.started += (playerSave as IInputAbility).ExecuteInputAbility;
            }
            if (playerLoad is IInputAbility)
            {
                inputControls.Keyboard.Load.started += (playerLoad as IInputAbility).ExecuteInputAbility;
            }
        }
    }
}

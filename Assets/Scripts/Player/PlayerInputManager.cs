using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerInputManager : MonoBehaviour
{
    // Variables
    private InputActions inputActions;
    private InputActions.PlayerOnFootActions playerOnFootActions;

    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    /*private PlayerWeaponFollowLook playerWeaponFollowLook;*/
    private PlayerStatistics playerStatistics;
    private PlayerActions playerActions;

    public WeaponManager weaponManager;

    private void Awake()
    {
        inputActions = new();
        playerOnFootActions = inputActions.PlayerOnFoot;

        playerMovement = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();
        /*playerWeaponFollowLook = GetComponent<PlayerWeaponFollowLook>();*/
        playerStatistics = GetComponent<PlayerStatistics>();
        playerActions = GetComponent<PlayerActions>();


        playerOnFootActions.Vault.performed += ctx => playerMovement.Vault();
        playerOnFootActions.Prone.performed += ctx => playerMovement.Prone();
        playerOnFootActions.Jump.performed += ctx => playerMovement.Jump();
        playerOnFootActions.Crouch.performed += ctx => playerMovement.Crouch();
        playerOnFootActions.Sprint.performed += ctx => playerMovement.Sprint();

        //playerOnFootActions.ADS. += ctx => weaponManager.Shoot();
        playerOnFootActions.Attack.performed += ctx => weaponManager.Shoot();
        playerOnFootActions.Reload.performed += ctx => weaponManager.Reload();

    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Will tell the playerMovement to move using the value from the movement action on MyInputActions
        playerMovement.ProcessMove(playerOnFootActions.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        // Will tell the PlayerLook to move using the camera and character controller using the value from the Look action on MyInputActions
        playerLook.ProcessLook(playerOnFootActions.Look.ReadValue<Vector2>());

        // ADS Code

        /*// Will tell the PlayerWeaponFollowLook to move using the camera and character controller using the value from the Look action on MyInputActions
        playerWeaponFollowLook.ProcessFollowLookWithWeapon(playerOnFootActions.Look.ReadValue<Vector2>());*/
    }

    void OnEnable()
    {
        playerOnFootActions.Enable();
    }

    void OnDisable()
    {
        playerOnFootActions.Disable();
    }

    // Functions
}

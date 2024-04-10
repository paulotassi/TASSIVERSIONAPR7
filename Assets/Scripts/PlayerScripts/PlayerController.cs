using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private InputHandler inputHandlerScript;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float RotateSpeed;

    //Dash Settings
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 1f;
    [SerializeField] private float dashCooldown = 1f;
    bool isDashing;
    bool canDash;

    //Dash Settings
    [SerializeField] private float rushSpeed = 8000f;
    [SerializeField] private float rushDuration = 2f;
    [SerializeField] private float rushCooldown = 10f;
    bool isRushing;
    bool canRush;

    public PlayerWeapon weapon;


    [SerializeField] private Camera playerCam;
    [SerializeField] private Rigidbody rb;
    private void Awake()
    {
        inputHandlerScript = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        canDash = true;
        canRush = true;
        mainCamera = Camera.main;
    }

    void Update()
    {

        var targetVector = new Vector3(inputHandlerScript.InputVector.x, 0, inputHandlerScript.InputVector.y);

        //Move in Direction Aiming

        var movementVector = MoveTowardTarget(targetVector);


        //Rotate in mouse direction

        Aim();


        //Dash Control

        if (isDashing||isRushing)
        {
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            return;
        } 
         if (isDashing == false && isRushing == false) 
        {
            gameObject.GetComponent<TrailRenderer>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

        /*if (Input.GetKeyDown(KeyCode.V) && canRush)
        {
            StartCoroutine(BullRush());
            Debug.Log("rush pressed");
        }*/

        //Weapon Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot();
        }

    }

    //Followed Bartha Szabolcs guide for aiming
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;


            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }

    public (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }



    public Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MoveSpeed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, playerCam.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        MoveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        MoveSpeed = 5f;
        isDashing = false;


        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private IEnumerator BullRush()
    {
        canRush = false;
        isRushing = true;
        rb.velocity = Vector3.forward * rushSpeed;
        yield return new WaitForSeconds(rushDuration);
        rb.velocity = Vector3.zero;
        isRushing = false;


        yield return new WaitForSeconds(rushCooldown);
        canRush = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public InputHandler inputHandlerScript;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 mouseOffset;
    [SerializeField] private Vector3 playerDirect;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Vector3 goalDirection;       
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Vector3 lookRot;
    [SerializeField] private Vector3 debugVector;
    [SerializeField] private Vector3 testPlayerDirect;
    [SerializeField] private Vector3 wessonX;
    

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        inputHandlerScript = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            targetPos = hit.point;
            targetPos.y = transform.position.y;
        }

       testPlayerDirect = new Vector3(0,0,0);

       var TemporaryTransformTest = new Vector3 (transform.position.x, transform.position.y, transform.position.z).normalized;
        playerDirect = new Vector3(inputHandlerScript.InputVector.x, 0, inputHandlerScript.InputVector.y).normalized;
        testPlayerDirect = Quaternion.Euler(-90, 45, 0) * playerDirect;
       // playerDirect = new Vector3(TemporaryTransformTest.x+inputHandlerScript.InputVector.x, 0, TemporaryTransformTest.z + inputHandlerScript.InputVector.y);


        lookRot = targetPos - transform.position;
        lookRot.Normalize();
        //lookRot.y = 0;


        transform.rotation = Quaternion.LookRotation(lookRot, Vector3.up);
        


        // Walk animation direction
        mouseOffset = (new Vector2(targetPos.x, targetPos.z) - new Vector2(transform.position.x, transform.position.z)).normalized;
        wessonX = new Vector3(testPlayerDirect.x - lookRot.x, 0, testPlayerDirect.z - lookRot.y).normalized;
        animator.SetFloat("x", wessonX.x);
        animator.SetFloat("y", wessonX.z);
        /* if (Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y))
         {
             animator.SetFloat("y", mouseOffset.x * playerDirect.x);
             animator.SetFloat("x", mouseOffset.y * playerDirect.z);
         }
         else
         {
             animator.SetFloat("x", mouseOffset.x * playerDirect.x);
             animator.SetFloat("y", mouseOffset.y * playerDirect.z);
         }*/
        //GizmoDebug
        //OnDrawGizmosSelected();


        /*if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            debugVector = lookRot;
            Gizmos.color = Color.yellow;
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            debugVector = playerDirect;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            debugVector = mouseOffset;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            debugVector = lookRot;
        }*/

    }
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        //mouse vector
        //debugVector = debugVector.normalized * 5f;
        //Debug.Log(debugVector);
        //Gizmos.DrawRay(transform.position, debugVector);
        Gizmos.DrawRay(transform.position, lookRot);
        Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, mouseOffset);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, wessonX);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, testPlayerDirect * 5f);
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public InputHandler inputHandlerScript;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 playerDirect;
    [SerializeField] private Vector3 mpos;   
    [SerializeField] private LayerMask groundMask;


    

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        inputHandlerScript = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horiz, 0, vert);
        movement = movement.normalized;




        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            mpos = hit.point - transform.position;
            mpos.y = 0f;
            mpos.Normalize();
            transform.forward = mpos;
        }

        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);


        animator.SetFloat("x", velocityX, 0.1f, Time.deltaTime);
        animator.SetFloat("y", velocityZ, 0.1f, Time.deltaTime);
        
    }
    void OnDrawGizmosSelected()
    {
      


    }

}

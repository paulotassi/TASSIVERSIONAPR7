using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private InputHandler inputHandlerScript;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 mouseOffset;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Vector3 goalDirection;       
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            targetPos = hit.point;
            targetPos.y = transform.position.y;
        }

        Vector3 lookRot = targetPos - transform.position;
        //lookRot.y = 0;

        transform.rotation = Quaternion.LookRotation(lookRot, Vector3.up);


        // Walk animation direction
        mouseOffset = (new Vector2(targetPos.x, targetPos.z) - new Vector2(transform.position.x, transform.position.z)).normalized;
        animator.SetFloat("x", mouseOffset.x);
        animator.SetFloat("y", mouseOffset.y);
    }
}

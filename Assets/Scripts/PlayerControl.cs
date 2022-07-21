using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private Camera cameraa;
    private bool isMove;
    public Animator animator;
    private Vector3 destination;
    private NavMeshAgent agent;  // �߰�

    private void Awake()
    {
        cameraa = Camera.main;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();  // �߰�
        agent.updateRotation = false;  // �߰�
    }

    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);  //�߰�
        destination = dest;
        isMove = true;
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.05f)
            {
                isMove = false;
                return;
            }
            var dir = destination - transform.position;
            transform.forward = dir;   // ����
            transform.position += dir.normalized * Time.deltaTime * 5f;

            animator.SetFloat("Vertical", dir.x * 30);
            animator.SetFloat("WalkSpeed", 3f);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraa.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        LookMoveDirection();  // ����
    }

    private void LookMoveDirection()  // ����
    {
        if (isMove)
        {
            // if (Vector3.Distance(destination, transform.position) <= 0.1f)
            if (agent.velocity.magnitude == 0.0f)  // ����
            {
                isMove = false;
                return;
            }

            // var dir = destination - transform.position;
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;  // ����
            transform.forward = dir;
            animator.SetFloat("Vertical", dir.x * 30);
            animator.SetFloat("WalkSpeed", 3f);
        }
    }
}

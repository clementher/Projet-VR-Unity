using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEnemy : MonoBehaviour
{
    public float moveForce = 0f;
    private Rigidbody rbody;
    public Vector3 moveDir;
    public LayerMask isWall;
    public float maxDistWall = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent <Rigidbody>();
        moveDir = ChooseDir();
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = moveDir * moveForce;

        if (Physics.Raycast(transform.position, transform.forward, maxDistWall, isWall))
        {
            moveDir = ChooseDir();
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }

    Vector3 ChooseDir()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 3);

        Vector3 temp = new Vector3();

        switch (i)
        {
            case 0:
                temp = transform.forward;
                break;
            case 1:
                temp = -transform.forward;
                break;
            case 2:
                temp = transform.right;
                break;
            case 3:
                temp = -transform.right;
                break;
        }

        return temp;
    }
}

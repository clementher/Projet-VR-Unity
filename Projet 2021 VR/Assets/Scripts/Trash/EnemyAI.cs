using UnityEngine;
using System.Collections;
public class EnemyAI : MonoBehaviour
{
    // Fix a range how early u want your enemy detect the obstacle.
    public int range;
    public float speed;
    private bool isThereAnyThing = false;
    // Specify the target for the enemy.
    public GameObject target;
    public float rotationSpeed;
    private RaycastHit hit;
    public LayerMask isWall;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //Look At Somthly Towards the Target if there is nothing in front.
        if (!isThereAnyThing)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
        // Enemy translate in forward direction.
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //Checking for any Obstacle in front.
        // Two rays left and right to the object to detect the obstacle.
        Transform leftRay = transform;
        Transform rightRay = transform;
        //Use Phyics.RayCast to detect the obstacle
        if (Physics.Raycast(leftRay.position + transform.right, transform.forward, out hit, range, isWall) || Physics.Raycast(rightRay.position - transform.right, transform.forward, out hit, range, isWall))
        {
            Debug.Log("EH SALUT");
            if (hit.collider.gameObject.layer == 8)
            {
                isThereAnyThing = true;
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
            }
        }
        // Now Two More RayCast At The End of Object to detect that object has already pass the obsatacle.
        // Just making this boolean variable false it means there is nothing in front of object.
        if (Physics.Raycast(transform.position - transform.forward, transform.right, out hit, 5, isWall) || Physics.Raycast(transform.position -transform.forward, -transform.right, out hit, 5, isWall))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                isThereAnyThing = false;
            }
        }
        // Use to debug the Physics.RayCast.
        Debug.DrawRay(transform.position + transform.right, transform.forward * 20, Color.red);
        Debug.DrawRay(transform.position - transform.right, transform.forward * 20, Color.red);
        Debug.DrawRay(transform.position - transform.forward, -transform.right * 20, Color.yellow);
        Debug.DrawRay(transform.position - transform.forward, transform.right * 20, Color.yellow);
    }
}
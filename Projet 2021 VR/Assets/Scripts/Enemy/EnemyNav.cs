using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public GameObject player;
    public Vector3 target1, target2;
    public float distanceToTrigger;
    private NavMeshAgent nav;
    private Vector3 target, targetTemp;
    private bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < distanceToTrigger)
        {
            isTrigger = true;
        }else
        {
            isTrigger = false;
        }
        if (isTrigger == true)
        {
            target = player.transform.position - transform.position;
            float angle = (Vector3.Angle(target, transform.forward));

            if (angle >= -70 && angle <= 70)
            {
                nav.SetDestination(player.transform.position);
            }else
            {
                isTrigger = false;
            }
        } else
        {
            if (transform.position == target1)
            {
                targetTemp = target2;
                nav.SetDestination(target2);
            } else if (transform.position == target2)
            {
                targetTemp = target1;
                nav.SetDestination(target1);
            }else
            {
                nav.SetDestination(targetTemp);
            }
        }
    }
}

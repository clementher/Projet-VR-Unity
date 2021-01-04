using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    Transform target;
    float fireRate = 1f;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    float turnSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        Debug.Log("OSSECOUR CA RENTRE PAS DEDANS");
        // fireRate += Time.deltaTime;
        //Vector3 dir = target.position - transform.position;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        if (other.gameObject.tag == "Obstacles")
        {
            Debug.Log("CA TOUCHE LE MUR");
            fireRate = 0;
        }

        else
        if (fireRate >= 1f)
        {
            Debug.Log("JE SUIS LA");
            //if (Physics.Raycast(transform.position, transform.forward, out hit, range, isWall))
            //{
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("CA TOUCHE LE JOUEUR");
                Shoot();
            }
            //}
        }
    }

    void Shoot()
    {
        Debug.LogAssertion(fireRate);
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        fireRate = 0f;
        Debug.Log("OSSECOUR CA TIRE PAS");
    }

    void Update()
    {
        fireRate += Time.deltaTime;
    }
}

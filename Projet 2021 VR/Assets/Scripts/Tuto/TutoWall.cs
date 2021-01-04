using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoWall : MonoBehaviour
{

    public Material middleMaterial;
    public Material okMaterial;
    int count = 0;

    void Start()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ammo")
        {
            switch (count)
            {
                case 0:
                    gameObject.GetComponent<MeshRenderer>().material = middleMaterial;
                    count++;
                    break;

                case 1:
                    gameObject.GetComponent<MeshRenderer>().material = okMaterial;
                    break;

                default:
                    break;
            }
        }
    }
}

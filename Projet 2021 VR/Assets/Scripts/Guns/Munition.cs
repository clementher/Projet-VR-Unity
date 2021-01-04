using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour
{
    public float damage = 10f;

    void Start()
    {
        StartCoroutine(Coroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        Target target = col.transform.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

}

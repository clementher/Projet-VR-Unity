using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAnimation : MonoBehaviour
{
    public ParticleSystem GrabEffect;

    public OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;


    void Update()
    {
        if (OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()))
        {
            Grab();
        }
    }

    void Grab()
    {
        GrabEffect.Play();
    }
}

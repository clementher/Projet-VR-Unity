using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;

    public GameObject fire;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;

    // Test Value Real Fire

    [Header("Prefab References")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;


    void Update()
    {
        Debug.DrawRay(fire.transform.position, fire.transform.forward, Color.red, 2);

        if (OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        if (muzzleFlashPrefab)
        {
            FlashAndEject();
        }

        if (bulletPrefab)
        {
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        }
    }

    void FlashAndEject()
    {
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        Destroy(tempFlash, destroyTimer);
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;

        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);

        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        Destroy(tempCasing, destroyTimer);
    }
}

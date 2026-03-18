using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("References")]
    public Animator gunAnimator;
    public Camera fpsCamera;
    public AudioSource gunAudio;
    public AudioClip gunfireClip;

    public ParticleSystem muzzleFlashPrefab; // assign prefab from Project
    public Transform muzzlePoint;            // empty at barrel tip

    [Header("Gun Settings")]
    public float shootRange = 1000f;
    public float damage = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Play gun animation
        if (gunAnimator != null)
            gunAnimator.SetTrigger("Shoot");

        // Play gun sound
        if (gunAudio != null && gunfireClip != null)
            gunAudio.PlayOneShot(gunfireClip);

        // Spawn a new muzzle flash instance
        if (muzzleFlashPrefab != null && muzzlePoint != null)
        {
            ParticleSystem flash = Instantiate(
                muzzleFlashPrefab,
                muzzlePoint.position,
                muzzlePoint.rotation
            );

            // Random scale
            float randomScale = Random.Range(1f, 2f);
            flash.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

            flash.Play();

            // Destroy after it finishes
            Destroy(flash.gameObject, flash.main.duration + flash.main.startLifetime.constantMax);
        }

        // Raycast for hits
        if (fpsCamera != null)
        {
            Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, shootRange))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                    target.TakeDamage(damage);
            }
        }
    }
}
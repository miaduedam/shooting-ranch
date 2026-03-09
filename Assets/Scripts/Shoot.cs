using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("References")]
    public Animator gunAnimator;
    public Camera fpsCamera;
    public AudioSource gunAudio;    // Add this: reference to AudioSource on the gun
    public AudioClip gunfireClip;   // Add this: your MP3 clip

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
        // Debug ray to visualize shooting
        Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * shootRange, Color.red, 2f);
        Debug.Log("Raycast from: " + fpsCamera.transform.position);

        // Play gun animation
        if (gunAnimator != null)
        {
            gunAnimator.SetTrigger("Shoot");
        }

        // Play gun sound
        if (gunAudio != null && gunfireClip != null)
        {
            gunAudio.PlayOneShot(gunfireClip);
        }

        // Raycast to detect hits
        if (fpsCamera != null)
        {
            Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, shootRange))
            {
                Debug.Log("Hit: " + hit.collider.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
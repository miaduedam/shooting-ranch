using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("References")]
    public Animator gunAnimator;    // Drag your Gun's Animator here
    public Camera fpsCamera;        // Drag your Main Camera here
    public float shootRange = 100f; // Distance the gun can shoot

    [Header("Optional Effects")]
    public ParticleSystem muzzleFlash; // Optional muzzle flash
    public AudioSource gunSound;       // Optional gunshot sound

    void Update()
    {
        // Check for left-click every frame
        if (Input.GetMouseButtonDown(0)) // 0 = left mouse button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 1️⃣ Play gun shoot animation
        if (gunAnimator != null)
        {
            gunAnimator.SetTrigger("Shoot");
        }

        // 2️⃣ Play muzzle flash
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // 3️⃣ Play gun sound
        if (gunSound != null)
        {
            gunSound.Play();
        }

        // 4️⃣ Raycast to detect hits
        if (fpsCamera != null)
        {
            Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, shootRange))
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
        }
    }
}
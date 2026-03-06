using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("References")]
    public Animator gunAnimator;
    public Camera fpsCamera;

    [Header("Gun Settings")]
    public float shootRange = 100f;
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
        {
            gunAnimator.SetTrigger("Shoot");
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
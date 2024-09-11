using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float chargeSpeed = 10f;
    private float chargeTime = 0f;
    private bool isCharging = false;
    

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0f; // Reset charge time
            isCharging = true;
        }

        // If Fire1 is held down, increase charge time
        if (Input.GetButton("Fire1") && isCharging)
        {
            chargeTime += Time.deltaTime * chargeSpeed;
            
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            // Spawn bullet when Fire1 is released
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();

            float speed = Mathf.Clamp(chargeTime,0f, 3f);
            bulletComp.bulletSpeed = speed;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballPrefab;
    private float cannonBallLifetime = 2f;
    private float cannonBallSpeed = 10f;

    private void Start()
    {
        StartCoroutine(CannonShots());
    }

    private IEnumerator CannonShots()
    {
        while(true)
        {
            Shoot();
            float randomIntervalForShoot = Random.Range(1f, 3f);
            yield return new WaitForSeconds(randomIntervalForShoot);
        }
    }

    private void Shoot()
    {
        GameObject cannonBall = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * cannonBallSpeed;
        Destroy(cannonBall, cannonBallLifetime);
    }
}

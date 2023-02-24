using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody2D playerRigidBody;
    [SerializeField]
    private Transform objectShoot;
    [SerializeField]
    private GameObject bullet;

    [Header("Configurations")]
    [SerializeField]
    private ScriptableInformationsPlayer informationsPlayer;
    [SerializeField]
    private KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField]
    private float timeRestartRecoilForce;

    private float recoilForce;

    private void Start()
    {
        recoilForce = informationsPlayer.recoilForce;
    }

    private void Update()
    {
        ShootAction();
    }

    private void ShootAction()
    {
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector3 mouseDirection = mousePosition - transform.position;
        // mouseDirection.z = 0f;
        // mouseDirection = -mouseDirection.normalized;
        Vector3 distanceShoot = objectShoot.position - transform.position;
        distanceShoot.z = 0f;

        Vector3 forceToAdd = distanceShoot.normalized;

        if (Input.GetKeyDown(shootKey))
        {
            playerRigidBody.AddForce(-forceToAdd * recoilForce, ForceMode2D.Impulse);

            GameObject bulletClone = Instantiate(bullet, objectShoot.position, Quaternion.identity);
            bulletClone.transform.forward = objectShoot.forward;
            bulletClone.GetComponent<Rigidbody2D>().AddForce(forceToAdd * informationsPlayer.shootForce, ForceMode2D.Impulse);
        }
    }

    public void SetRecoilForcePowerUp(float recoilForcePowerUp)
    {
        recoilForce = recoilForcePowerUp;
        Invoke(nameof(RestartRecoilForce), timeRestartRecoilForce);
    }

    private void RestartRecoilForce()
    {
        recoilForce = informationsPlayer.recoilForce;
    }
}
using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private const float InvokeFrequency = 0.5f;
    [SerializeField]private Transform target;
    public float range = 10f;
    public float turningSpeed = 10f;

    public Transform TurretRotation;

    private string enemyTag = "Enemy";

    public Animator anim;

    //Bullet
    public GameObject bulletObject;
    public Transform shootPoint;
    public float shootRate = 1f; 
    private float shootCountDown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, InvokeFrequency);//repeat tracking the update target
        anim = gameObject.GetComponent<Animator>();
        isAttackAnim(false);
    }

    private void isAttackAnim(bool isAttack)
    {
        anim.SetBool("isAttack", isAttack);
    }


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        //lock on the target
        Vector3 dir = target.position - transform.position;//find the distance direction between 2 position
        Quaternion Rotationlook = Quaternion.LookRotation(dir); //use the distance direction to rotate
        Vector3 rotation = Quaternion.Lerp(TurretRotation.rotation, Rotationlook, Time.deltaTime*turningSpeed).eulerAngles;
        TurretRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        

    }

    void UpdateTarget() //tracking target
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance && enemy.GetComponent<Enemy>().IsAlive)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            isAttackAnim(true);
        }
        else
        {
            target = null;
            isAttackAnim(false);
        }

        if (shootCountDown <= 0f) //Thx Krones25
        {
            ShootEnemy();
            shootCountDown = 1f / shootRate; //Number of bullet in a second
        }

        shootCountDown -= InvokeFrequency;
    }

    private void ShootEnemy()
    {
        GameObject bulletGObject = (GameObject) Instantiate(bulletObject, shootPoint.position, shootPoint.rotation);
        Bullet bullet = bulletGObject.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Chase(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);//Create a sphere range of the tower
    }
}

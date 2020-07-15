using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("General")]
    public float range = 10f;
    public float turningSpeed = 10f;

    [Header("Using Bullet(deafault)")]
    public GameObject bulletObject;
    public float shootRate = 1f; 
    private float shootCountDown = 0f;

    [Header("Using Beam")]
    public bool useBeam = false;

    public int damOverTime = 10;
    public float slowPercentage = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;


    [Header("Not touchable")]
    public Transform TurretRotation;
    public Animator anim;
    public Transform shootPoint;
    private const float InvokeFrequency = 0.5f;
    [SerializeField] private Transform target;
    private Enemy targetEnemy;
    private string enemyTag = "Enemy";
    private string enemyFlyTag = "FlyEnemy";
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
            if(useBeam)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }
        LockOnTarget();

        if (useBeam)
        {
            Beam();
        }
        else
        {
            if (shootCountDown <= 0f) //Thx Krones25
            {
                ShootEnemy();
                shootCountDown = 1f / shootRate; //Number of bullet in a second
            }

            shootCountDown -= Time.deltaTime;
        }
    }

    void Beam()
    {
        targetEnemy.takeDamage(damOverTime * Time.deltaTime);
        
        targetEnemy.Slow(slowPercentage);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, shootPoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = shootPoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;//find the distance direction between 2 position
        Quaternion Rotationlook = Quaternion.LookRotation(dir); //use the distance direction to rotate
        Vector3 rotation = Quaternion.Lerp(TurretRotation.rotation, Rotationlook, Time.deltaTime * turningSpeed).eulerAngles;
        TurretRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void UpdateTarget() //tracking target
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] enemiesFly = GameObject.FindGameObjectsWithTag(enemyFlyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        if (this.tag == "Anti Air")
        {
            foreach (GameObject enemy in enemiesFly)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < shortestDistance && enemy.GetComponent<Enemy>().IsAlive)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < shortestDistance && enemy.GetComponent<Enemy>().IsAlive)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }
        
        

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            isAttackAnim(true);
        }
        else
        {
            target = null;
            isAttackAnim(false);
        }

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

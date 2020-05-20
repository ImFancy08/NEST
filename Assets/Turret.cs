using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]private Transform target;
    public float range = 10f, turningSpeed = 10f;

    public Transform TurretRotation;

    public string enemyTag = "Enemy";
    
    //Bullet
    public GameObject bulletObject;
    public Transform shootPoint;
    public float shootRate = 1f, shootCountDown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);//repeat tracking the update target
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
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        
        if(shootCountDown<0f)
        {
            ShootEnemy();
            shootRate = 1f / shootRate; //Number of bullet in a second
        }

        shootCountDown -= Time.deltaTime;
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

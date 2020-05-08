using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int numberofEnemy;
    public void OnTriggerEnter(Collider other)
    {
        
    }

    //private void awake()
    //{
    //    int indexscene = scenemanager.getactivescene().buildindex;

    //}
    private void Update()
    {
        DestroyOnHit();
        
    }
   

    public void DestroyOnHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.LogError("Hit");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Destroy(gameObject);
                numberofEnemy--;
            }
        }
    }    
}

using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    public static CameraManager CamManager;

    [SerializeField] private float panSpeed = 30f;
    [SerializeField] private float panBorderThickness = 1f;

    [SerializeField] private float scrollSpeed = 5f;
    private int srollOffset = 1000;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    public Vector2 panLimit;

    private void Awake()
    {
        this.enabled = true;
    }
    private void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        Vector3 pos = transform.position;
        //Move forward
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        //Move back
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        //Move left
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        //Move right
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x + 30);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y - 40); 

        float scrollMouse = Input.GetAxis("Mouse ScrollWheel");
        
        pos.y -= scrollMouse * srollOffset *scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;


    }
}

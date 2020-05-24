using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float panSpeed = 30f;
    [SerializeField] private float panBorderThick = 1f;

    [SerializeField] private float scrollSpeed = 5f;
    private int srollOffset = 1000;
    private float minY = 10f;
    private float maxY = 80;

    private bool checkMovement = true;

    private void Start()
    {
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            checkMovement = !checkMovement;
        }

        if (!checkMovement)
        {
            return;
        }

        //Move forward
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThick)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        //Move back
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThick)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        //Move left
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThick)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        //Move right
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThick)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scrollMouse = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scrollMouse);

        Vector3 pos = transform.position;

        pos.y -= scrollMouse * srollOffset *scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;


    }
}

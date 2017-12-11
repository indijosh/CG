using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float speed;
    public float scrollSpeed;
    private float targetScrollHeight;
    public GameObject cameraGameObject;

    private GameObject mainGameControllerGameObject;

    // Use this for initialization
    void Start()
    {
        scrollSpeed = 100;

    }

    // Update is called once per frame
    void Update()
    {
        scrollSpeed = 10 * (this.transform.position.y + 1);
        speed = 1 * ((this.transform.position.y + 1));
        if (speed > 100)
        {
            speed = 100;
        }
        if (speed < 10)
        {
            speed = 10;
        }
        if (Input.GetKey(KeyCode.LeftShift))
            speed = speed * 2;
        if (Input.GetKey("w"))
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey("s"))
            this.transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (Input.GetKey("a"))
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (Input.GetKey("d"))
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey("e"))
            this.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        if (Input.GetKey("q"))
            this.transform.RotateAround(transform.position, -transform.up, Time.deltaTime * 90f);
        var scrollDirection = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDirection < 0f && this.transform.position.y < 120f)
        {
            this.transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
            if (this.transform.position.y > 120)
            {
                this.transform.position = new Vector3(transform.position.x, 120, transform.position.z);
            }
            if (cameraGameObject.transform.eulerAngles.x < 89)
            {
                float cameraRotation = (this.transform.position.y * 0.375f) + 45;
                cameraGameObject.transform.localEulerAngles = new Vector3(cameraRotation, 0, 0);
            }
        }
        if (scrollDirection > 0f && this.transform.position.y > 0f)
        {
            this.transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
            if (this.transform.position.y < 0)
            {
                this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            if (cameraGameObject.transform.eulerAngles.x > 0)
            {
                float cameraRotation = (this.transform.position.y * 0.375f) + 45;
                cameraGameObject.transform.localEulerAngles = new Vector3(cameraRotation, 0, 0);
            }
        }
    }
}

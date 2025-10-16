using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Rigidbody rb;
    public float sensitivity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    transform.Rotate(new Vector3(0, 1, 0) * sensitivity);
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.Rotate(new Vector3(0, -1, 0) * sensitivity);
        //}
        float inputX = Input.GetAxis("Mouse X") * sensitivity;
        float inputY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up * inputX);
    }
}

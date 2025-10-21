using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Mouse X") * sensitivity;
        float inputY = Input.GetAxisRaw("Mouse Y") * sensitivity;

        yRotation += inputX;
        xRotation -= inputY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}

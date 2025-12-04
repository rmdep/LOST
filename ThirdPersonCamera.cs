using UnityEngine;

public class ThirdPersonFollowCamera : MonoBehaviour
{
    public Transform target;              // Player
    public float distance = 4f;           // Jarak kamera
    public float height = 2f;             // Tinggi kamera
    public float sensitivityX = 150f;     // Mouse sens horizontal
    public float sensitivityY = 120f;     // Mouse sens vertical

    public float minY = -30f;             // Batas kamera ke bawah
    public float maxY = 60f;              // Batas kamera ke atas

    private float rotX;                   // Vertical rotation
    private float rotY;                   // Horizontal rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Ambil rotasi awal camera
        Vector3 e = transform.eulerAngles;
        rotX = e.x;
        rotY = target.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!target) return;

        // Input mouse (kamera muter, player ga)
        rotX -= Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, minY, maxY);

        // Rotasi kamera mengelilingi player
        Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);

        // Hitung posisi kamera di belakang player
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        Vector3 finalPos = target.position + Vector3.up * height + offset;

        transform.position = finalPos;
        transform.LookAt(target.position + Vector3.up * height);
    }
}

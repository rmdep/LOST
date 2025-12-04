using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJalan : MonoBehaviour
{
    // Variabel untuk mengakses komponen CharacterController
    public CharacterController controller;

    // Kecepatan pergerakan karakter
    public float movementSpeed = 5.0f;

    // Tinggi lompatan
    public float jumpHeight = 3.0f;

    // Gravitasi yang memengaruhi karakter
    public float gravity = -9.81f;

    // Transform untuk mengecek apakah karakter berada di tanah
    public Transform groundCheck;

    // Jarak dari groundCheck ke tanah untuk menentukan apakah karakter dianggap di tanah atau tidak
    public float groundDistance = 0.4f;

    // LayerMask yang menentukan jenis permukaan yang dianggap sebagai tanah
    public LayerMask groundMask;

    // Variabel untuk menyimpan kecepatan vertikal karakter
    Vector3 velocity;

    // Status apakah karakter berada di tanah atau tidak
    bool isGrounded;

    void Update()
    {
        // Memeriksa apakah karakter berada di tanah
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Jika karakter berada di tanah dan sedang jatuh, reset kecepatan vertikalnya
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Nilai kecil agar tetap menempel di tanah
        }

        // Mendapatkan input dari pemain
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Menghitung arah gerak berdasarkan transform karakter
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Menggerakkan karakter berdasarkan input
        controller.Move(move * movementSpeed * Time.deltaTime);

        // Lompat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Menerapkan gravitasi
        velocity.y += gravity * Time.deltaTime;

        // Menerapkan kecepatan vertikal (jatuh)
        controller.Move(velocity * Time.deltaTime);
    }
}

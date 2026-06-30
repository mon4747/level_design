using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement25D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 7f;
    public float turnSpeed = 15f;

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // บล็อกไม่ให้ตัวละครล้ม (หมุนเฉพาะแกน Y เพื่อหันหน้า)
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // --- ควบคุมแกน X ด้วยปุ่ม S และ W ---
        if (Input.GetKey(KeyCode.S))
        {
            moveX = 1f; // S ไปแกน X (บวก)
        }
        else if (Input.GetKey(KeyCode.W))
        {
            moveX = -1f; // W ไปทางตรงข้าม S (แกน X ลบ)
        }

        // --- ควบคุมแกน Z ด้วยปุ่ม D และ A ---
        if (Input.GetKey(KeyCode.D))
        {
            moveZ = 1f; // D ไปแกน Z (บวก)
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveZ = -1f; // A ไปทางตรงข้าม D (แกน Z ลบ)
        }

        // รวมทิศทางและทำ Normalize เพื่อให้เวลาเดินเฉียงแล้วความเร็วไม่เพิ่มขึ้น
        movement = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // ขยับ Rigidbody ตามแกนที่คำนวณจากปุ่มกด
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        // หมุนหน้าตัวละครไปทิศทางที่เดินอัตโนมัติ
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
        }
    }
}
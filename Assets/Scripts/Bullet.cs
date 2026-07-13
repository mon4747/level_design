using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Movement")]
    public float speed = 20f;

    [Header("Destroy Settings")]
    [Tooltip("ระยะเวลา (วินาที) ที่กระสุนจะอยู่ในเกมก่อนที่จะทำลายตัวเอง")]
    public float lifetime = 3f;

    void Start()
    {
        // สั่งทำลายตัวเองล่วงหน้าทันทีที่กระสุนถูกสร้างขึ้นมา
        // ฟังก์ชัน Destroy สามารถใส่พารามิเตอร์ตัวที่สองเพื่อเป็น "เวลานับถอยหลัง" ได้ครับ
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // ให้กระสุนพุ่งไปข้างหน้าตลอดเวลา
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // (เสริม) ถ้ากระสุนวิ่งไปชนสิ่งกีดขวางอื่น ให้ทำลายตัวเองทันที ไม่ต้องรอจนหมดเวลา
    void OnTriggerEnter(Collider other)
    {
        // สามารถเพิ่มเงื่อนไขเช็ค Tag ได้ เช่น if (other.CompareTag("Enemy"))
        Destroy(gameObject);
    }
}
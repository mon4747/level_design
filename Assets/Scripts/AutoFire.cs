using UnityEngine;

public class AutoFire : MonoBehaviour
{
    [Header("Fire Settings")]
    [Tooltip("ตัวกระสุน (Prefab) ที่ต้องการจะยิง")]
    public GameObject bulletPrefab;

    [Tooltip("จุดที่กระสุนจะออกจากปืน (สร้าง Empty Object ไปวางไว้ที่ปลายกระบอกปืนแล้วลากมาใส่)")]
    public Transform firePoint;

    [Tooltip("ความถี่ในการยิง (นัดต่อวินาที) เช่น ตั้งไว้ 5 คือใน 1 วินาทีจะยิง 5 นัด")]
    public float fireRate = 5f;

    private float nextTimeToFire = 0f;

    void Update()
    {
        // ยิงอัตโนมัติตามความถี่ที่กำหนด (Time.time คือเวลาปัจจุบันของเกม)
        if (Time.time >= nextTimeToFire)
        {
            // คำนวณเวลาที่จะยิงนัดถัดไป
            nextTimeToFire = Time.time + (1f / fireRate);

            Fire();
        }
    }

    void Fire()
    {
        if (bulletPrefab == null || firePoint == null) return;

        // สร้างกระสุนออกมาตามตำแหน่งและทิศทางของปลายกระบอกปืน
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
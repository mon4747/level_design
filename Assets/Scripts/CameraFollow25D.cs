using UnityEngine;

public class CameraFollow25D : MonoBehaviour
{
    [Header("Target")]
    public Transform target; // ลากตัวละคร (Player) มาใส่ตรงนี้

    [Header("Settings")]
    public Vector3 offset = new Vector3(0f, 5f, -10f); // ระยะห่างของกล้อง (X, Y, Z)
    public float smoothSpeed = 5f; // ความลื่นไหลในการเลื่อนตาม (ยิ่งมากยิ่งตามไว)

    void LateUpdate()
    {
        if (target == null) return;

        // 1. คำนวณตำแหน่งที่กล้องควรจะไปอยู่ โดยอิงจากตำแหน่งของผู้เล่น + ระยะห่าง
        Vector3 targetPosition = target.position + offset;

        // 2. ใช้ Vector3.Lerp เพื่อให้กล้องเลื่อนตามอย่างนุ่มนวล (Smooth)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // 3. ย้ายตำแหน่งกล้องไปจุดนั้น
        transform.position = smoothedPosition;
    }
}
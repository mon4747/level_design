using UnityEngine;

public class WaypointPlatform : MonoBehaviour
{
    [Header("Platform Points")]
    [Tooltip("ลาก Empty Object ที่เป็นจุดเริ่มต้นมาใส่ตรงนี้")]
    public Transform startPoint;

    [Tooltip("ลาก Empty Object ที่เป็นจุดปลายทางมาใส่ตรงนี้")]
    public Transform endPoint;

    [Header("Settings")]
    public float speed = 2f;

    private Transform targetPoint;

    void Start()
    {
        if (startPoint == null || endPoint == null)
        {
            Debug.LogError("กรุณาใส่ Start Point และ End Point ใน Inspector ด้วยครับ!");
            return;
        }

        // เริ่มต้นให้ลิฟต์อยู่ที่จุด Start และตั้งเป้าหมายถัดไปเป็น End
        transform.position = startPoint.position;
        targetPoint = endPoint;
    }

    void Update()
    {
        if (startPoint == null || endPoint == null) return;

        // เลื่อนลิฟต์ไปยังจุดหมาย (Target)
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // ถ้าลิฟต์วิ่งไปถึงจุดหมายแล้ว ให้สลับเป้าหมาย
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
        {
            // ถ้าเป้าหมายเดิมคือ End ให้เปลี่ยนเป็น Start / ถ้าเป็น Start ให้เปลี่ยนเป็น End
            targetPoint = (targetPoint == endPoint) ? startPoint : endPoint;
        }
    }
}
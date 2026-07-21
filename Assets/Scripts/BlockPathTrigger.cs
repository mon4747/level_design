using UnityEngine;

public class BlockPathTrigger : MonoBehaviour
{
    [Header("ใส่โมเดลหินที่ต้องการให้ปรากฏ")]
    public GameObject rockModel; // ลากโมเดลหินมาใส่ที่ช่องนี้ใน Inspector

    [Header("ตั้งค่าให้ทำงานครั้งเดียว")]
    public bool destroyTriggerAfterUse = true; // ลบ Trigger ทิ้งหลังทำงานเสร็จเพื่อไม่ให้รันซ้ำ

    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่าคนที่เดินผ่านคือ Player หรือไม่ (ต้องตั้ง Tag ของตัวละครเป็น "Player" ด้วย)
        if (other.CompareTag("Player"))
        {
            if (rockModel != null)
            {
                rockModel.SetActive(true); // เปิดการแสดงผลโมเดลหิน
            }

            // ทำลายตัว Trigger ทิ้งเพื่อประหยัดทรัพยากรและไม่ให้ทำงานซ้ำ
            if (destroyTriggerAfterUse)
            {
                Destroy(gameObject);
            }
        }
    }
}
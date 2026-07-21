using UnityEngine;

public class ItemCollectible : MonoBehaviour
{
    [Header("ตั้งค่าไอเทม")]
    public GameObject collectEffect; // (Optional) Prefab เอฟเฟกต์ตอนเก็บ เช่น ประกายแสง/ควัน
    public AudioClip collectSound;   // (Optional) เสียงตอนเก็บไอเทม

    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่าคนที่เดินมาชนคือผู้เล่นหรือไม่ (ตั้ง Tag ตัวละครเป็น "Player")
        if (other.CompareTag("Player"))
        {
            OnCollect(other.gameObject);
        }
    }

    private void OnCollect(GameObject player)
    {
        // 1. (Optional) สร้าง เอฟเฟกต์ เล่นเสียง ตรงตำแหน่งไอเทม
        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }

        if (collectSound != null)
        {
            // เล่นเสียงที่ตำแหน่งไอเทม (เปิดเสียงแม้ไอเทมจะถูก Destroy ไปแล้ว)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        // 2. ใส่ Logic การเพิ่มค่าต่างๆ ตรงนี้ได้ เช่น เพิ่มคะแนน, เพิ่มไอเทมใน Inventory
        // Example: player.GetComponent<PlayerScore>().AddScore(1);

        Debug.Log("เก็บไอเทมเรียบร้อย: " + gameObject.name);

        // 3. ทำลายไอเทมชิ้นนี้ทิ้ง
        Destroy(gameObject);
    }
}
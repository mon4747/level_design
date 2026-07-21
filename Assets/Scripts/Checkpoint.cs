using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่าผู้เล่นเดินผ่าน
        if (other.CompareTag("Player"))
        {
            PlayerRespawn player = other.GetComponent<PlayerRespawn>();
            if (player != null)
            {
                // ส่งตำแหน่งของ Checkpoint นี้ไปบันทึกที่ผู้เล่น
                player.UpdateCheckpoint(transform.position);
            }
        }
    }
}
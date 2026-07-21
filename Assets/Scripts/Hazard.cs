using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ถ้าผู้เล่นเดินมาโดนสิ่งนี้
        if (other.CompareTag("Player"))
        {
            PlayerRespawn player = other.GetComponent<PlayerRespawn>();
            if (player != null)
            {
                player.Die(); // สั่งให้ผู้เล่นตายทันที
            }
        }
    }
}
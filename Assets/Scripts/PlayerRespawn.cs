using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 currentCheckpoint;
    private CharacterController characterController; // กรณีใช้ CharacterController

    private void Start()
    {
        // กำหนดจุดเกิดแรกเริ่ม เป็นตำแหน่งตอนเริ่มเกม
        currentCheckpoint = transform.position;
        characterController = GetComponent<CharacterController>();
    }

    // ฟังก์ชันสำหรับอัปเดตจุดเกิดใหม่
    public void UpdateCheckpoint(Vector3 newPosition)
    {
        currentCheckpoint = newPosition;
        Debug.Log("บันทึก Checkpoint ใหม่เรียบร้อย!");
    }

    // ฟังก์ชันสั่งตาย แล้วย้ายกลับจุดเกิด
    public void Die()
    {
        Debug.Log("ผู้เล่นตาย! ย้ายกลับไป Checkpoint ล่าสุด");

        // หากใช้ CharacterController ต้องปิดก่อนย้ายตำแหน่ง เพื่อไม่ให้ติด Physics
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        // ย้ายตำแหน่งตัวละคร
        transform.position = currentCheckpoint;

        // เปิด CharacterController กลับมาทำงานปกติ
        if (characterController != null)
        {
            characterController.enabled = true;
        }
    }
}
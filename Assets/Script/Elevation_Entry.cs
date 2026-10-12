using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevation_Entry : MonoBehaviour
{
    // Thay vì mảng Collider2D, hãy dùng GameObject để tham chiếu dễ hơn
    public GameObject stairsObject;
    public GameObject boundaryObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 1. Vô hiệu hóa tất cả collider trên object cầu thang
            if (stairsObject != null)
            {
                // Lấy TẤT CẢ các component Collider2D trên stairsObject
                Collider2D[] allStairsColliders = stairsObject.GetComponents<Collider2D>();

                // Duyệt qua từng collider và tắt nó đi
                foreach (Collider2D stair in allStairsColliders)
                {
                    stair.enabled = false;
                }
            }

            // 2. Kích hoạt tất cả collider trên object ranh giới
            if (boundaryObject != null)
            {
                // Lấy TẤT CẢ các component Collider2D trên boundaryObject
                Collider2D[] allBoundaryColliders = boundaryObject.GetComponents<Collider2D>();

                // Duyệt qua từng collider và bật nó lên
                foreach (Collider2D boundary in allBoundaryColliders)
                {
                    boundary.enabled = true;
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 25;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Tự hủy sau một khoảng thời gian
        Destroy(gameObject, lifetime);
    }

    private void OnEnable()
    {
        // Di chuyển đạn theo hướng lên (trục Y) với tốc độ đã định
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra va chạm với đối tượng có tag "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemyController = collision.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
            }
            
            Destroy(gameObject);            // Hủy đạn
        }
        
        // Hủy đạn nếu va chạm với bất kỳ đối tượng nào khác (tùy chỉnh nếu cần)
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

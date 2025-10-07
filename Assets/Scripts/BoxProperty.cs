using UnityEngine;

public class BoxProperty : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Hazard")) || (collision.CompareTag("SlowZone"))) 
        {
            Destroy(gameObject);
        }
    }
}

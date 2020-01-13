using UnityEngine;

public class ExplosionBlock : MonoBehaviour
{
    public GameObject explosive;
    public float radius = 15.0F;
    public float power = 35.0F;
    public Vector3 explosionPos;
    public Vector3 offset = new Vector3(0, 0, 0);

    private void Start()
    {
        explosionPos = explosive.transform.position + offset;

        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.tag == "Obstacle")
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F, ForceMode.Impulse);
            }
        }
        
    }
}

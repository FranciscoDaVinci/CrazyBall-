using UnityEngine;

public class SpikeLaunch : MonoBehaviour
{
    [SerializeField] float force = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ball_Normal") || collision.transform.CompareTag("Ball_Fast"))
        {
            Rigidbody rb = collision.transform.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 randomDir = new Vector3(
                    Random.Range(-1f, 1f),
                    Random.Range(0.8f, 1.2f),
                    Random.Range(-1f, 1f)
                );

                randomDir.Normalize();

                rb.velocity = Vector3.zero;
                rb.AddForce(randomDir * force, ForceMode.Impulse);
            }
        }
    }
}

using UnityEngine;

public class Thruster : MonoBehaviour
{
    float thrust = 100;
    Rigidbody thruster;

    private void Start()
    {
        thruster = gameObject.GetComponent<Rigidbody>();
    }
    public void Thrust(float signalThrust)
    {
        thruster.AddForce(transform.up * thrust * signalThrust);
    }
}

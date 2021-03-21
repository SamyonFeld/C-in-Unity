using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Stabilizer stabilizer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxis("Vertical") > 0)
        {
            stabilizer.leftFrontThruster.Thrust(1f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            stabilizer.leftFrontThruster.Thrust(0f);
        }
    }
}

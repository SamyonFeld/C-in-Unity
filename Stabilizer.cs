using UnityEngine;
using System;

public class Stabilizer : MonoBehaviour
{
    public GameObject drone;

    //public GameObject _leftFrontThruster;             // Задумывалось управление каждым отдельным двигателем, но префаб рассыпался при добавлении Rigidbody для отделтных элементов.
    //public GameObject _rightFrontThruster;
    //public GameObject _leftRearThruster;
    //public GameObject _rightRearThruster;

    public Thruster leftFrontThruster;
    //public Thruster rightFrontThruster;
    //public Thruster leftRearThruster;
    //public Thruster rightRearThruster;

    private float speedY = 0;
    private bool isStoped = true;
    private float targetHeight;
    public float TargetHeight { get; set; }

    private float signal;

    // Start is called before the first frame update
    void Start()
    {
        targetHeight = drone.transform.position.y;
    }

    private void FixedUpdate()
    {
        speedY = drone.GetComponent<Rigidbody>().velocity.y;
        if (Input.GetAxis("Vertical") == 0 && (speedY > 0.1f || speedY < -0.1)) // Сначала остановка
        {
            leftFrontThruster.Thrust(-Math.Sign(speedY));
            isStoped = true;
        }
        else if (Input.GetAxis("Vertical") == 0) // Затем переход на удержание.
        {
            if(isStoped)
            {
                targetHeight = drone.transform.position.y;
                isStoped = false;
                Debug.Log($"{targetHeight:f2}");
            }
            signal = targetHeight + 0.5f - drone.transform.position.y - speedY * 0.5f;
            leftFrontThruster.Thrust(signal);
        }
        
        //rightFrontThruster.Thrust(targetHeight - drone.transform.position.y);
        //leftRearThruster.Thrust(targetHeight - drone.transform.position.y);
        //rightRearThruster.Thrust(targetHeight - drone.transform.position.y);
    }
}

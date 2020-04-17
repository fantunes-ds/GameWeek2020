using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody m_rb;
    [SerializeField] private float m_speed = 10.0f;
    [SerializeField] private float m_maxSpeed = 5.0f;
    [SerializeField] private GameObject m_playerObject;

    [SerializeField] private Transform[] m_wheels;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetSpeed() < m_maxSpeed)
        {
            m_rb.AddForce(transform.forward * Input.GetAxis("Vertical") * m_speed);
            m_rb.AddForce(transform.right * Input.GetAxis("Horizontal") * m_speed);
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.3f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f)
        m_playerObject.transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Vertical") * -1.0f, Input.GetAxis("Horizontal")) * Mathf.Rad2Deg + 90.0f, 0);

        AnimateWheels();
    }

    float GetSpeed()
    {
        return Mathf.Abs(m_rb.velocity.x) + Mathf.Abs(m_rb.velocity.y) + Mathf.Abs(m_rb.velocity.z);
    }

    void AnimateWheels()
    {
        if (m_wheels.Length < 2)
        {
            Debug.Log("Not enough wheels were added for anymation, aborting");
            return; 
        }

        float inputSpeed = Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"));
        if (inputSpeed > 1)
            inputSpeed = 1;
        Quaternion q = m_wheels[0].rotation;
        float rotAngle = q.eulerAngles.x + GetSpeed() * inputSpeed;

        if (rotAngle > 180 && rotAngle < 270)
            rotAngle = -210;
        else if (rotAngle < 180 && rotAngle > 90)
            rotAngle = 210;

        q = m_wheels[0].localRotation;
        q.eulerAngles = new Vector3(rotAngle, 0.1f, 0.1f);
        m_wheels[0].localRotation = q;
 
        q = m_wheels[1].localRotation;
        q.eulerAngles = new Vector3(rotAngle, 0.1f, 0.1f);
        m_wheels[1].localRotation = q;
    }

}

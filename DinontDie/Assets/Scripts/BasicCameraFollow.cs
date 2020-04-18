using UnityEngine;
using System.Collections;

public class BasicCameraFollow : MonoBehaviour 
{

	private Vector3 startingPosition;
	public Transform followTarget;
	private Vector3 targetPos;
	public float moveSpeed;


    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;


    void Start()
	{
		startingPosition = transform.position;
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update () 
	{
		if(followTarget != null)
		{
			//targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
			//Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			//transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
		}

        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }


    }
    public void TriggerShake(float value)
    {
        Debug.Log("shake");
        shakeDuration = value;
    }
}


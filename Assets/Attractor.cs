using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
	
	const float G = 667.4f;
	
	public float tick;
	
	public Rigidbody rb;

	private float r;

    private int desc;

    void Update()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();

        desc = 1;
        r = 1;
        foreach (Attractor attractor in attractors)
        {
            if (attractor != this)
            {
                r = r + Attract(attractor);
            }
        }
        tick = tick + 0.0000001f / r;

    }
	float Attract (Attractor objToAttract)
	{
		Rigidbody rbToAttract = objToAttract.rb;
		
		Vector3 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;
		
		float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
		Vector3 force = direction.normalized * forceMagnitude;
		
		rbToAttract.AddForce(force);
        return Mathf.Abs(forceMagnitude);
	}
	
}

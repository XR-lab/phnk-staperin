using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RayGun : MonoBehaviour
{

	public Material targetMaterial;
	
	void Update ()
	{
		targetMaterial.SetVector("_RayPosition", transform.position);
		targetMaterial.SetVector("_RayDirection", transform.forward);
		Debug.DrawRay(transform.position, transform.forward, Color.magenta);
	}
}

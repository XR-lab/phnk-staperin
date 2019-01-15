using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class ArmRotation : MonoBehaviour
{
	private Hand _hand;
	private Slider _slider;

	private void Awake()
	{
		_slider = GetComponent<Slider>();
	}

	private void Start()
	{
		_hand = GetHand();
	}

	private void Update()
	{
		float x = _hand.transform.rotation.x;
		x = Mathf.InverseLerp(-0.7f, 0.7f, x);
		_slider.value = x;
	}

	private Hand GetHand()
	{
		Transform hand = transform;
		while (hand.GetComponent<Hand>() == null)
		{
			hand = hand.parent;

			if (hand.parent == null || hand == null)
			{
				Debug.LogWarning(this + " is not attached to a VR Hand");
				break;
			}
		}
		return hand.GetComponent<Hand>();
	}
}
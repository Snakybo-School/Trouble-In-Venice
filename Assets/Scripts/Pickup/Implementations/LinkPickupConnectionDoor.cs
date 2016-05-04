﻿using UnityEngine;
using System.Collections;
using System;

public class LinkPickupConnectionDoor : LinkPickupConnection
{
	[SerializeField] private bool startOpen;

	private EntityNodeTracker nodeTracker;
	private new Renderer renderer;

	protected void Awake()
	{
		nodeTracker = GetComponent<EntityNodeTracker>();
		renderer = GetComponent<Renderer>();
		
		nodeTracker.CurrentNode.Active = startOpen;
		renderer.enabled = !startOpen;
	}

	protected void OnValidate()
	{
		GetComponent<Renderer>().enabled = !startOpen;
	}

	public override void OnPickup()
	{
		nodeTracker.CurrentNode.Active = !nodeTracker.CurrentNode.Active;		
		renderer.enabled = !renderer.enabled;
	}
}
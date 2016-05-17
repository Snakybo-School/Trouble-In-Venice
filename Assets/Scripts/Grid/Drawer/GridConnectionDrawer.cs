﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Proeve
{
	public class GridConnectionDrawer : MonoBehaviour
	{
		public class Entry
		{
			public GridNode Start { private set; get; }
			public GridNode End { private set; get; }

			public int StartIndex { set; get; }
			public int EndIndex { set; get; }

			public Vector3 StartPosition
			{
				get
				{
					return Start.Position;
				}
			}

			public Vector3 EndPosition
			{
				get
				{
					return Start.Position + (End.Position - Start.Position);
				}
			}

			public Entry(GridNode _start, GridNode _end)
			{
				Start = _start;
				End = _end;
			}
		}

		private List<Entry> entries;
		private GridNode node;

		protected void Awake()
		{
			node = GetComponent<GridNode>();
			entries = new List<Entry>();

			foreach(GridNode connection in node.Connections)
			{
				Entry entry = new Entry(node, connection);
				GridConnectionDrawerUtils.RegisterEntry(entry);

				entries.Add(entry);
			}
		}

		protected void OnEnable()
		{
			foreach(Entry entry in entries)
			{
				if(node.HasConnection(entry.End))
				{
					GridConnectionDrawerUtils.Start(entry);
				}
			}

			node.onBlockadeAddedEvent += OnBlockadeAdded;
			node.onBlockadeRemovedEvent += OnBlockadeRemoved;
		}

		protected void OnDisable()
		{
			foreach(Entry entry in entries)
			{
				if(node.HasConnection(entry.End))
				{
					GridConnectionDrawerUtils.End(entry);
				}
			}

			node.onBlockadeAddedEvent -= OnBlockadeAdded;
			node.onBlockadeRemovedEvent -= OnBlockadeRemoved;
		}

		private void OnBlockadeRemoved(GridNode to)
		{
			Entry entry = FindEntry(to);
			if(entry != null)
			{
				GridConnectionDrawerUtils.Restore(entry);
			}
		}

		private void OnBlockadeAdded(GridNode to)
		{
			Entry entry = FindEntry(to);
			if(entry != null)
			{
				GridConnectionDrawerUtils.Interrupt(entry);
			}
		}

		private Entry FindEntry(GridNode to)
		{
			foreach(Entry entry in entries)
			{
				if(entry.End == to)
				{
					return entry;
				}
			}

			return null;
		}
	}
}

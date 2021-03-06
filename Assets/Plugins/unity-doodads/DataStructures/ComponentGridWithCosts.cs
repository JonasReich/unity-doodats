﻿//-------------------------------------------
// (c) 2017 - Jonas Reich
//-------------------------------------------

using System;
using UnityEngine;

namespace Doodads
{
	/// <summary>
	/// ComponentGrid that stores entry cost information of all tiles
	/// </summary>
	[Serializable]
	public class ComponentGridWithCosts<T> : ComponentGrid<T>, IGridWithCosts<T> where T : Component, IGridTileWithEntryCosts
	{
		public ComponentGridWithCosts(int columnCount, int rowCount, T prefab, Transform root) : base(columnCount, rowCount, prefab, root)
		{
		}

		public int GetCosts(XY A, XY B)
		{
			return this[B.x, B.y].EntryCosts;
		}
	}

	public interface IGridTileWithEntryCosts
	{
		int EntryCosts { get; }
	}
}

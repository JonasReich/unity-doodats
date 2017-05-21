//-------------------------------------------
// (c) 2017 - Jonas Reich
//-------------------------------------------

using System.Collections.Generic;
using UnityDoodats;
using UnityEngine;

namespace UnityDoodats
{
	public interface IGrid<T> : IEnumerable<T>
	{
		int Width { get; }
		int Height { get; }
		int ItemCount { get; }

		T this[int x, int y] { get; set; }
		T this[XY pos] { get; set; }

		void Remove(T item);

		XY GetPosition(T item);
		bool Contains(T item);

		void Swap(T A, T B);
		void Swap(XY A, XY B);

		T[] AdjacentItems(T item);
		XY[] AdjacentTiles(XY pos);

		T[] OrthogonalItems(T item);
		XY[] OrthogonalTiles(XY pos);

		bool IsValid(XY pos);
		void Clear();
	}

	public interface IGridWithCosts<T> : IGrid<T>
	{
		int GetCosts(XY A, XY B);
	}
}

﻿using UnityEngine;
using System;

namespace Utils
{
	/// <summary>
	/// A TypeDropDownAttribute. Creates a nice dropdown list containing all types inheriting from the given type.
	/// </summary>
	public class TypeDropdownAttribute : PropertyAttribute
	{
		public Type BaseType { private set; get; }

		public TypeDropdownAttribute(Type _baseType)
		{
			BaseType = _baseType;
		}
	}
}

﻿using UnityEngine;
using System.Collections;
using Utils;

namespace Proeve
{
	public class ChallengeComplete : ChallengeBase 
	{
		public override bool getStar()
		{
			return true;
		}

		public virtual string getString()
		{
			return "Complete the level.";
		}
	}
}
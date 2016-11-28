using UnityEngine;
using System.Collections;

public class ActionMaster {
	public enum Action { EndTurn, Tidy, Reset, GameOver };

	private int bowl = 1;
	private int currentScore = 0;

	public Action Bowl (int pins)
	{
		if (pins == 10) {
			if ((19 <= bowl) && (bowl <= 20)) {
				bowl++;
				return Action.Reset;
			} else if (bowl >= 21) {
				return Action.GameOver;
			} else {
				bowl += (bowl % 2 == 0) ? 1 : 2;
				currentScore = 0;
				return Action.EndTurn;
			}
		}

		if (pins < 10) {
			if (bowl % 2 == 1) {
				currentScore = pins;
				bowl += 1;
				return Action.Tidy;
			} else {
				if ((currentScore + pins == 10) && (bowl != 20)) {
					return Action.EndTurn;
				} else {
					if (currentScore == 0) {
						return Action.Tidy;
					} else if ((currentScore + pins < 10) && (bowl == 20)) {
						return Action.GameOver;
					} else {
						return Action.Reset;
					}
				}
			}
		}

		throw new UnityException("Unknown action for " + pins + " pins");
	}
}

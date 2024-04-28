using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer { //the interface that is inherited by the player objs (Human or AI)
	void turn();
	bool skipStatus {
		get;
		set;
	}
    
	void addCards(Card other);
	string getName();
	bool Equals(IPlayer other);
	int getCardsLeft();
}
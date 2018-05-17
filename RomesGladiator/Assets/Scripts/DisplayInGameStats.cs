using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInGameStats : MonoBehaviour {

    public Character character;
    public Text goldTextLabel;
    public Text nameTextLabel;
    public Text classTextLabel;
    public Text raceTextLabel;
    public Text rankTextLabel;

	// Use this for initialization
	void Start () {
        goldTextLabel.text = character.gold.ToString();
        nameTextLabel.text = character.Name;
        classTextLabel.text = character.Class;
        raceTextLabel.text = character.Race;
        rankTextLabel.text = character.SocialRank;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

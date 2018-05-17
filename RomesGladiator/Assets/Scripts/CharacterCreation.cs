using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    public Character player;
    Skills skills = new Skills();
    List<string> story = new List<string>();
    Text[] backStoryText = new Text[6];
    Toggle[] toggleArray = new Toggle[11];

    #region Variables
    string playerName = "";
    string playerSex = "";
    int playerAge = 0;
    string playerRace = "";
    string playerClass = "";
    string playerSocialRank = "";
    float playerHeight = 0f;
    string playerWeight = "";
    int skillsLeft = 3;
    #endregion

    #region Toggles
    public Toggle arcoToggle;
    public Toggle athlToggle;
    public Toggle beastToggle;
    public Toggle deceToggle;
    public Toggle insiToggle;
    public Toggle intiToggle;
    public Toggle mediToggle;
    public Toggle percToggle;
    public Toggle perfToggle;
    public Toggle persToggle;
    public Toggle survToggle;
    #endregion

    #region Pointvariables
    int pointsLeft;
    int STR;
    int DEX;
    int CON;
    int INT;
    int WIS;
    int CHA;
    #endregion

    #region InputFeilds
    public InputField characterName;
    public InputField characterAge;
    #endregion

    #region Sliders
    public Slider characterHeight;
    #endregion

    #region Dropdown
    public Dropdown characterRace;
    public Dropdown characterClass;
    public Dropdown characterSocialRank;
    public Dropdown characterWeight;
    #endregion

    #region TextFeilds
    public Text pointLeftLabel;
    public Text strStatLabel;
    public Text dexStatLabel;
    public Text conStatLabel;
    public Text intStatLabel;
    public Text wisStatLabel;
    public Text chaStatLabel;
    public Text characterBackStoryLine;
    public Text characterBackStoryName;
    public Text characterBackStoryAgeLine;
    public Text characterBackStoryAge;
    public Text characterBackStoryRaceLine;
    public Text characterBackStoryRace;
    public Text characterBackStorySocialRankLine;
    public Text characterBackStorySocialRank;
    public Text characterBackStoryClassLine;
    public Text characterBackStoryClass;
    public Text characterBackStoryLastLine;
    public Text DisplaySkillInfo;
    public Text murmilloClassInfoDis;
    public Text retiariusClassInfoDis;
    public Text secutorClassInfoDis;
    public Text homplomachusClassInfoDis;
    public Text thraexClassInfoDis;
    #endregion

    #region Buttons
    public Button sexMaleBtn;
    public Button sexFemaleBtn;
    public Button strDownBtn;
    public Button strUpBtn;
    public Button dexDownBtn;
    public Button dexUpBtn;
    public Button conDownBtn;
    public Button conUpBtn;
    public Button intDownBtn;
    public Button intUpBtn;
    public Button wisDownBtn;
    public Button wisUpBtn;
    public Button chaDownBtn;
    public Button chaUpBtn;
    #endregion

    void Start()
    {
        pointsLeft = 10;
        STR = 5;
        DEX = 5;
        CON = 5;
        INT = 5;
        WIS = 5;
        CHA = 5;

        backStoryText[0] = characterBackStoryLine;
        backStoryText[1] = characterBackStoryAgeLine;
        backStoryText[2] = characterBackStoryRaceLine;
        backStoryText[3] = characterBackStorySocialRankLine;
        backStoryText[4] = characterBackStoryClassLine;
        backStoryText[5] = characterBackStoryLastLine;

        toggleArray[0] = arcoToggle;
        toggleArray[1] = athlToggle;
        toggleArray[2] = beastToggle;
        toggleArray[3] = deceToggle;
        toggleArray[4] = insiToggle;
        toggleArray[5] = intiToggle;
        toggleArray[6] = mediToggle;
        toggleArray[7] = percToggle;
        toggleArray[8] = perfToggle;
        toggleArray[9] = persToggle;
        toggleArray[10] = survToggle;

        characterBackStoryRace.text = characterRace.captionText.text;
        characterBackStorySocialRank.text = characterSocialRank.captionText.text;
        characterBackStoryClass.text = characterClass.captionText.text;
        CurrentStats();
        ReadTextFile();
        DisplayBackStory();

    }

    public void SetPlayerName()
    {
        playerName = characterName.text;
    }

    public void SetPlayerSexMale()
    {
        playerSex = "Male";
    }

    public void SetPlayerSexFemale()
    {
        playerSex = "Female";
    }

    public void SetPlayerAge()
    {
        string tempAgeString = characterAge.text;
        int tempAge;
        tempAge = int.Parse(tempAgeString);
        playerAge = tempAge;
    }

    public void SetPlayerRace()
    {
        int tempRace = characterRace.value;
        switch (tempRace)
        {
            case 1:
                playerRace = "Roman";
                break;
            case 2:
                playerRace = "Carthaginian";
                break;
            case 3:
                playerRace = "Syrian";
                break;
            case 4:
                playerRace = "Perusian";
                break;
            case 5:
                playerRace = "Illyrian";
                break;
            case 6:
                playerRace = "Gaul";
                break;
            case 7:
                playerRace = "Britannian";
                break;
        }
    }

    public void SetPlayerClass()
    {
        int tempClass = characterClass.value;
        switch (tempClass)
        {
            case 1:
                playerClass = "Murmillo";
                break;
            case 2:
                playerClass = "Retiarius";
                break;
            case 3:
                playerClass = "Secutor";
                break;
            case 4:
                playerClass = "Homplomachus";
                break;
            case 5:
                playerClass = "Thraex";
                break;
        }
    }

    public void SetPlayerSocialRank()
    {
        int tempRank = characterSocialRank.value;
        switch (tempRank)
        {
            case 1:
                playerSocialRank = "Senatores";
                break;
            case 2:
                playerSocialRank = "Magnus";
                break;
            case 3:
                playerSocialRank = "Equites";
                break;
            case 4:
                playerSocialRank = "Plebeian";
                break;
            case 5:
                playerSocialRank = "Servorum";
                break;
        }
    }

    public void SetPlayerHeight()
    {
        playerHeight = characterHeight.value;
    }

    public void SetPlayerWeight()
    {
        playerWeight = characterWeight.name;
    }

    void CurrentStats()
    {
        pointLeftLabel.text = pointsLeft.ToString();
        strStatLabel.text = STR.ToString();
        dexStatLabel.text = DEX.ToString();
        conStatLabel.text = CON.ToString();
        intStatLabel.text = INT.ToString();
        wisStatLabel.text = WIS.ToString();
        chaStatLabel.text = CHA.ToString();
    }

    public void StrengthDown()
    {
        if (STR != 0)
        {
            STR--;
            pointsLeft++;
            CurrentStats();
        }
    }

    public void StrengthUp()
    {
        if (pointsLeft != 0)
        {
            STR++;
            pointsLeft--;
            CurrentStats();
        }
    }

    public void DexterityDown()
    {
        if (DEX != 0)
        {
            DEX--;
            pointsLeft++;
            CurrentStats();
        }
    }

    public void DexterityUp()
    {
        if (pointsLeft != 0)
        {
            DEX++;
            pointsLeft--;
            CurrentStats();
        }
    }

    public void ConsitutionDown()
    {
        if (CON != 0)
        {
            CON--;
            pointsLeft++;
            CurrentStats();
        }
    }

    public void ConsitutionUp()
    {
        if (pointsLeft != 0)
        {
            CON++;
            pointsLeft--;
            CurrentStats();
        }
    }

    public void IntelligenceDown()
    {
        if (INT != 0)
        {
            INT--;
            pointsLeft++;
            CurrentStats();
        }
    }

    public void IntelligenceUp()
    {
        if (pointsLeft != 0)
        {
            INT++;
            pointsLeft--;
            CurrentStats();
        }
    }

    public void WisdomDown()
    {
        if (WIS != 0)
        {
            WIS--;
            pointsLeft++;
            CurrentStats();
        }
    }

    public void WisdomUp()
    {
        if (pointsLeft != 0)
        {
            WIS++;
            pointsLeft--;
            CurrentStats();
        }
    }

    public void CharismaDown()
    {
        if (CHA != 0)
        {
            CHA--;
            pointsLeft++;
            CurrentStats();
        }
    }

    public void CharismaUp()
    {
        if (pointsLeft != 0)
        {
            CHA++;
            pointsLeft--;
            CurrentStats();
        }
    }

    public void ReadTextFile()
    {
        string line;

        StreamReader textReader = new StreamReader(@"F:\Unity Assessment\RomesGladiator\Assets\TextFiles\CharacterCreationBackStory.txt");

        while ((line = textReader.ReadLine()) != null)
        {
            story.Add(line);
        }

        textReader.Close();
    }

    public void DisplayBackStory()
    {
        int test = story.Count;

        for (int i = 0; i < test; i++)
        {
            backStoryText[i].text = story[i];
        }
    }

    public void DisplayCharacterName()
    {
        characterBackStoryName.text = characterName.text;
    }

    public void DisplayCharacterAge()
    {
        characterBackStoryAge.text = characterAge.text;
    }

    public void DisplayCharacterRace()
    {
        characterBackStoryRace.text = characterRace.captionText.text;
    }

    public void DisplayCharacterSocialRank()
    {
        characterBackStorySocialRank.text = characterSocialRank.captionText.text;
    }

    public void DisplayCharacterClass()
    {
        characterBackStoryClass.text = characterClass.captionText.text;
    }

    public void DisplayAcrobaticsInfo()
    {
        DisplaySkillInfo.text = "Dodging, Balance and(+1 DEX).";
    }

    public void HideAcrobaticsInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayAthleticsInfo()
    {
        DisplaySkillInfo.text = "Increases your speed and Swimming.";
    }

    public void HideAthleticsInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayBeastHandlingInfo()
    {
        DisplaySkillInfo.text = "Gives You bounes attack damange againest animals.";
    }

    public void HideBeastHandlingInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayDeceptionInfo()
    {
        DisplaySkillInfo.text = "Lieing to people and (+1 CHA).";
    }

    public void HideDeceptionInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayInsightInfo()
    {
        DisplaySkillInfo.text = "Finding out the truth and (+1 WIS).";
    }

    public void HideInsightInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayIntimidationInfo()
    {
        DisplaySkillInfo.text = "Decreases enenmy attack and might cause them to give up early.";
    }

    public void HideIntimidationInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayMedicineInfo()
    {
        DisplaySkillInfo.text = "Heal faster when your are not in a fight.";
    }

    public void HideMedicineInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayPerceptionInfo()
    {
        DisplaySkillInfo.text = "Gives a 5% bounes to Armor, Damage, Speed.";
    }

    public void HidePerceptionInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayPerfomanceInfo()
    {
        DisplaySkillInfo.text = "At the end of a fight can get the crowd fired up and earn more rep and gold.";
    }

    public void HidePerfomanceInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplayPersuasionInfo()
    {
        DisplaySkillInfo.text = "Convince someone and (+1 CHA).";
    }

    public void HidePersuasionInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void DisplaySurvivalInfo()
    {
        DisplaySkillInfo.text = "Increases HP by 1 and Increases your chance of a killing blow.";
    }

    public void HideSurvivalInfo()
    {
        DisplaySkillInfo.text = "";
    }

    public void ShowClassInfo()
    {
        murmilloClassInfoDis.text = "A Murmillo was a heavily armoured gladiators Murmillones were typically paired with Thracian, but occasionally with the similar hoplomachus or a Retiarius.";
        retiariusClassInfoDis.text = "A Retiarius was a Roman gladiator who fought with equipment styled on that of a fisherman.";
        secutorClassInfoDis.text = "A Secutor was armed similarly to the Murmillo gladiator and was specially trained to fight a retiarius";
        homplomachusClassInfoDis.text = "A Hoplomachus armed to resemble a Greek hoplite";
        thraexClassInfoDis.text = "A Thraex was armed in the Thracian style with small rectangular, square or circular shield called a parmula";
    }

    public void AcrobaticsChosen()
    {
        if (arcoToggle.isOn && skillsLeft != 0)
        {
            skills.Acrobatics = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!arcoToggle.isOn && skillsLeft != 3)
        {
            skills.Acrobatics = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void AthleticsChosen()
    {
        if (athlToggle.isOn && skillsLeft != 0)
        {
            skills.Athletics = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!athlToggle.isOn && skillsLeft != 3)
        {
            skills.Athletics = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void BeastHandingChosen()
    {
        if (beastToggle.isOn && skillsLeft != 0)
        {
            skills.BeastHandling = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!beastToggle.isOn && skillsLeft != 3)
        {
            skills.BeastHandling = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void DeceptionChosen()
    {
        if (deceToggle.isOn && skillsLeft != 0)
        {
            skills.Deception = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!deceToggle.isOn && skillsLeft != 3)
        {
            skills.Deception = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void InsightChosen()
    {
        if (insiToggle.isOn && skillsLeft != 0)
        {
            skills.Insight = 3;
            CheckToggle();
            skillsLeft--;
            Debug.Log(skillsLeft);
        }

        if (!insiToggle.isOn && skillsLeft != 3)
        {
            skills.Insight = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void IntimidationChosen()
    {
        if (intiToggle.isOn && skillsLeft != 0)
        {
            skills.Intimidation = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!intiToggle.isOn && skillsLeft != 3)
        {
            skills.Intimidation = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
        if (skillsLeft == 0)
        {
            CheckToggle();
        }
    }

    public void MedicineChosen()
    {
        if (mediToggle.isOn && skillsLeft != 0)
        {
            skills.Medicine = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!mediToggle.isOn && skillsLeft != 3)
        {
            skills.Medicine = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void PerceptionChosen()
    {
        if (percToggle.isOn && skillsLeft != 0)
        {
            skills.Perception = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!percToggle.isOn && skillsLeft != 3)
        {
            skills.Perception = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void PerfomanceChosen()
    {
        if (perfToggle.isOn && skillsLeft != 0)
        {
            skills.Perfomance = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!perfToggle.isOn && skillsLeft != 3)
        {
            skills.Perfomance = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void PersusaionChosen()
    {
        if (persToggle.isOn && skillsLeft != 0)
        {
            skills.Persuasion = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!persToggle.isOn && skillsLeft != 3)
        {
            skills.Persuasion = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void SurvivalChosen()
    {
        if (survToggle.isOn && skillsLeft != 0)
        {
            skills.Survival = 3;
            skillsLeft--;
            CheckToggle();
            Debug.Log(skillsLeft);
        }

        if (!survToggle.isOn && skillsLeft != 3)
        {
            skills.Survival = 0;
            skillsLeft++;
            CheckToggle();
            Debug.Log(skillsLeft);
        }
    }

    public void CheckToggle()
    {
        if (skillsLeft == 0)
        {
            for (int iii = 0; iii < toggleArray.Length; iii++)
            {
                if (!toggleArray[iii].isOn)
                {
                    //  toggleArray[i].enabled = false;
                    toggleArray[iii].interactable = false;
                }
            }
        }
        else if (skillsLeft != 0)
        {
            for (int jjj = 0; jjj < toggleArray.Length; jjj++)
            {
                if (!toggleArray[jjj].interactable)
                {
                    toggleArray[jjj].interactable = true;
                }
            }
        }
    }

    public void SaveCharacterInfo()
    {
        if (characterRace.value == 0)
        {
            playerRace = "Roman";
        }
        if (characterSocialRank.value == 0)
        {
            playerSocialRank = "Senatores";
        }
        if (characterClass.value == 0 )
        {
            playerClass = "Murmillo";
        }
        player.Name = playerName;
        player.Age = playerAge;
        player.Sex = playerSex;
        player.Race = playerRace;
        player.Class = playerClass;
        player.SocialRank = playerSocialRank;
        player.Height = playerHeight;
        player.Weight = playerWeight;
        player.Strength = STR;
        player.Dexterity = DEX;
        player.Consitution = CON;
        player.Intelligence = INT;
        player.Wisdom = WIS;
        player.Charisma = CHA;
    }
}


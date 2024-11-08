using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Rock_Paper_Scissors : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Canvas;
    public GameObject inputField;
    public string inputText;

    //public GameObject playerPot;
    public TMP_Text playerPot;
    public int pPot = 100;

    //public TMP_Text playerBet;
    public GameObject IFplayerBet;
    public string playerBet;
    public int pBet;

    public TMP_Text enemyPot;
    public int ePot = 100;

    public TMP_Text enemyBet;
    private GameObject IFenemyBet;
    private int eBet;

    public Button Rock;
    public Button Paper;
    public Button Scissors;
    private string playerChoice;
    private string enemyChoice;
    public bool win;

    void Start()
    {
        Button rock = Rock.GetComponent<Button>();
        rock.onClick.AddListener(() => SetPlayerChoice("rock"));

        Button paper = Paper.GetComponent<Button>();
        paper.onClick.AddListener(() => SetPlayerChoice("paper"));

        Button scissors = Scissors.GetComponent<Button>();
        scissors.onClick.AddListener(() => SetPlayerChoice("scissors"));

        Canvas = GameObject.Find("Canvas");
        IFplayerBet = GameObject.Find("PlayerBet");
        IFenemyBet = GameObject.Find("EnemyBet");

        inputText = ("ROCK! PAPER! SCISSORS!");


    }

    void SetPlayerChoice(string pChoice)
    {
        playerChoice = pChoice;
        Debug.Log("You have clicked the " + pChoice + " button!");

        //player pot
        playerPot.GetComponent<TMP_Text>().text = "Player pot: " + pPot.ToString();
        //enemy pot
        enemyPot.GetComponent<TMP_Text>().text = "Enemy pot: " + ePot.ToString();

        
        pBet.TryParse(playerBet);

        //Villkor för betting
        if (pBet <= 0 || playerBet == null)
        {
            inputText = ("Place bet!");
        }
        else if (pBet < pPot || pBet > pPot)
        {
            inputText = ("How much?");
        }
        //ELSE kör spelet om bet är ok
        else
        {
            //SetEnemyChoice-funktionen ligger utanför denna loop
            SetEnemyChoice(UnityEngine.Random.Range(1, 4));
            //rull för eBet & skriv ut eBet
            eBet = UnityEngine.Random.Range(1, ePot);
            Debug.Log(eBet);
            IFenemyBet.GetComponent<TMP_Text>().text = eBet.ToString();


            //Vem vann? Räkna bet
            if ((pChoice == "scissors" && enemyChoice == "paper") ||
                (pChoice == "paper" && enemyChoice == "rock") ||
                (pChoice == "rock" && enemyChoice == "scissors"))
            {
                win = true;
                inputText = ("You won this turn! Keep going!");
                ePot = (ePot - eBet);
                //ändra i UI - ändras redan?
            }
            else
            {
                if (pChoice == enemyChoice)
                {
                    inputText = ("Tie! Keep going!");
                }
                else
                {
                    win = false;
                    inputText = ("You lost this turn! Try again!");
                    pPot = (pPot - pBet);
                    //ändra i UI - ändras redan?

                }
            }
        }
 
    }
   
    void SetEnemyChoice(int eChoice)
    {
        if (eChoice == 1){
            enemyChoice = "rock";
            Debug.Log("Computer has clicked the" + enemyChoice + "button!");
        } 
        else if (eChoice == 2){
            enemyChoice = "paper";
            Debug.Log("Computer has clicked the" + enemyChoice + "button!");
        }
        else
        {
            enemyChoice = "scissors";
            Debug.Log("Computer has clicked the" + enemyChoice + "button!");
        }
    }


    void Update()
    {

        inputField.GetComponent<TMP_Text>().text = inputText;
        playerPot.GetComponent<TMP_Text>().text = "Player pot: " + pPot.ToString();
        enemyPot.GetComponent<TMP_Text>().text = "Enemy pot: " + ePot.ToString();

        Debug.Log(IFplayerBet.GetComponent<TMP_Text>().text);
    
        playerBet = IFplayerBet.GetComponent<TMP_Text>().text;
        Debug.Log(playerBet);
        //om någon inte kan betta mer är spelet slut
        if (ePot <= 0)
        {
            inputText = ("WIN!");
        }
        if (pPot <= 0)
        {
            inputText = ("YOU LOOSE!");
        }

    }
   
}




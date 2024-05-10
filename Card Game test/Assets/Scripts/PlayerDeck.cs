using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> container = new List<Card>();
    public int x;
    public static int deckSize;
    public List<Card> deck = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject[] Clones;
    public GameObject Hand;
    public GameObject CardToHand;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        deckSize = 40;
        // in this case deckSize is the amount of cards we want in our Deck
        for (int i = 0; i < deckSize; i++)
        {
            // 1, 4 as in the cards that we have in our database which currently is 4
            x = Random.Range(1, 4);
            deck[i] = CardDatabase.cardList[x];


        }

        StartCoroutine(StartGame());

    }

    // Update is called once per frame
    void Update()
    {

        staticDeck = deck;

        if (deckSize < 30)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 20)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize < 10)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }

        if (TurnSystem.startTurn == true)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startTurn = false;
        }


    }

    IEnumerator StartGame()
    {
        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(1);

            //NEW
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }


    public void Shuffle()
    {
        for (int i = 0;i < deckSize;i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
    }

    IEnumerator Draw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

}

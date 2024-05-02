using StateNamespace;
class BlackJack : State {
    // Create a deck of cards that we will fill in later
    Dictionary<string, int> Deck = new Dictionary<string, int>(); 
    List<int> PlayerList = new List<int>(); 
    List<int> DealerList = new List<int>(); 
    KeyValuePair<string, int> faceDown;
    private void Hit() {
        DealCardToPlayer();
    }

    private void StartGame() {

        // Build the deck and shuffle it
        Console.WriteLine("Building deck...");
        BuildDeck();
        Console.WriteLine("Shuffling cards...");
        ShuffleDeck();
        Console.WriteLine("Game starting...\n");

        // Deal the player 2 cards
        DealCardToPlayer();
        DealCardToPlayer();
        // Deal the dealer 2 cards, one face down
        DealCardToDealerFaceDown();
        DealCardToDealer();

        // Start the game 
        int n = Deck.Count();
        Console.WriteLine("Your turn...\n");
        Console.WriteLine($"Your current total is {CalculateTotal(PlayerList)}");
        Console.Write("Would you like to hit or stand? ");
        string input = Console.ReadLine();
        // Deal the cards to the player and dealer
        while(input.ToLower() == "hit" && n > 0) {
            n--;
            if(input.ToLower() == "hit") {
                DealCardToPlayer();
            }
            else if(input.ToLower() == "stand") {
                Console.WriteLine("You have chosen to stand.");
            }
            else {
                Console.WriteLine("Invalid input, please try again.");
            }
            Console.WriteLine($"Your current total is {CalculateTotal(PlayerList)}");
            Console.Write("Would you like to hit or stand? ");
            input = Console.ReadLine();
        }
        Console.WriteLine("Dealers turn...");
        if(DealerList.Sum() < 17) { // the dealer will hit if it has no cards or the sum is less than 17
            while (DealerList.Sum() < 17) {
                DealCardToDealer();
            }
        }
        else {
            Console.WriteLine("The Dealer has chosen to stand");
        }
        // Reveal the face-down card
        Console.WriteLine($"Dealer's face-down card was {faceDown.Key}");
        DealerList.Add(faceDown.Value); // Add the face-down card value to the dealer's list
        Console.WriteLine($"The dealer's total is {CalculateTotal(DealerList)}");
        HasWon();
    }

    private void DealCardToPlayer() {
        KeyValuePair<string, int> dealtCard = Deck.ElementAt(0);
        Console.WriteLine($"You have been dealt {dealtCard.Key}");    
        Deck.Remove(dealtCard.Key);
        PlayerList.Add(dealtCard.Value); 
    }

    private void DealCardToDealer() {
        KeyValuePair<string, int> dealtCard = Deck.ElementAt(0);
        Console.WriteLine("Dealer has chosen to hit");
        Console.WriteLine($"Dealer has been dealt {dealtCard.Key}");
        Deck.Remove(dealtCard.Key);
        DealerList.Add(dealtCard.Value); 
        Console.WriteLine($"Dealers current total is {CalculateTotal(DealerList)}\n");
    }

    private void DealCardToDealerFaceDown() {
        // Just to simulate the face-down card
        KeyValuePair<string, int> dealtCard = Deck.ElementAt(0);
        Console.WriteLine($"Dealer has been dealt a face down card");
        Deck.Remove(dealtCard.Key);
        faceDown = dealtCard;
    }

    // method for checking the win condition
    private bool HasWon() {
        int PlayerTotal = CalculateTotal(PlayerList);
        int DealerTotal = CalculateTotal(DealerList);

        if(PlayerTotal > 21) {
            Console.WriteLine("You have busted!\nThe Dealer wins!");
            return true;
        }
        else if(DealerTotal > 21) {
            Console.WriteLine("The Dealer has busted!\nYou have won!"); 
            return true;
        }
        else if(PlayerTotal == 21 && DealerTotal == 21) {
            Console.WriteLine("Both you and the dealer have BlackJack. It's a push");
            return true;
        }
        else if (DealerTotal == 21) {
            Console.WriteLine("The Dealer has won!");
            return true;
        }
        else if (PlayerTotal == 21) {
            Console.WriteLine("You have won!");
            return true;
        }
        else if(PlayerTotal > DealerTotal) {
            Console.WriteLine("You have won!");
            return true;
        }
        else if(DealerTotal > PlayerTotal) {
            Console.WriteLine("The Dealer has won!");
            return true;
        }
        return false;
    }
    // Calculate the total for each to check for the win
    private int CalculateTotal(List<int> cardList) {
        int total = 0;
        int aceCount = 0;
        
        foreach( int card in cardList ) {
            if(card == 11) {
                aceCount++;
            }
            total += card;
        }

        while(total > 21 && aceCount > 0) {
            total -= 10;
            aceCount--;
        }
        return total;
    }

    private void BuildDeck() {
        // Create the rank of cards
        string[] Cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        // Loop through each suit, and fill in the ranks for each suit.
        foreach( string suit in new string[] { "Hearts", "Diamonds", "Clubs", "Spades" } ) {
            foreach( string rank in Cards) {
                string card = rank + " of " + suit;
                int value = 0;

                if( int.TryParse( rank, out int cardValue) ) {
                    value = cardValue;
                }
                else if(rank == "A") {
                    value = 11;
                }
                else { 
                    value = 10;
                }
                //Console.WriteLine($"Card: {rank}, Suit: {suit}, Value: {value}");
                Deck.Add(card, value);
            }
        }
    }
    // Implement modern fisher-yates shuffle algorithm
    private void ShuffleDeck() {
        Random rnd = new();
        int n = Deck.Count;
        var TempDeck = Deck.ToList();
        while( n > 1) {
            n--;
            int k = rnd.Next(n+1);
            
            var temp = TempDeck[k];
            TempDeck[k] = TempDeck[n];
            TempDeck[n] = temp;
        }
        Deck = TempDeck.ToDictionary(x => x.Key, x => x.Value);
    }

    public override void Play() {
        // ConcreteStateA will be implemented by group member
        Console.WriteLine("ConcreteStateC handles request 1");
        Console.WriteLine("ConcreteStateA's game is starting...");
        StartGame();
    }
    public override void NextGame() {
        // ConcreteStateB will be implemented by group member
        Console.WriteLine("ConcreteStateC handles request 2");
        Console.WriteLine("ConcreteStateC is moving to the next game...");
        // Game A has not been implemented yet
        //currentContext.TransitionTo(new );
    }
}
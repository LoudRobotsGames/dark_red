VAR trust=25
VAR gain_trust=false

You approach the Shopkeep once more, determined to be more subtle.
*[Hello my good man!]
->shopkeep_1
*[What have you for sale?]
~trust=trust+5
->shopkeep_2

==shopkeep_1==
"Hmm? Oh it's the witch. What do you want?" 
"Just to thank you for all your hard work." you say.
*"You are a pillar of the community[."], without you we would not be half the village we are today!"
The Shopkeep smiles broadly, "You are spot on there miss."
~trust=trust+10
->shopkeep_1_1
*"And I was hoping you could help me[?"]?" The Shopkeep's face clouds over. "Unrelated to the current witchhunt," You add quickly. "of course."
~trust=trust+5
->shopkeep_2

==shopkeep_1_1==
*"People must trust you[."] a great deal" you suggest.
"They certainly do!" He says proudly. "People is always asking me for special favors, special items now and again."
"Anything interesting?"
~trust=trust+5
->shopkeep_2_2
*"You must know everything that goes on[."] in the village."
"What are you getting at?" He seems suspicious.
"Nothing, just curious is all."
"Well..." he begins.
~trust=trust-5
->shopkeep_2_2

==shopkeep_2==
"Ahh! Of Course! Anything you could possibly need young miss! Goods, sundries, something for your beau perhaps? I've a wealth of books at the moment."
*["What sorts of books?"]
->shopkeep_2_1
*["Anything intersting?"]
"Well, now that you mention it..."
->shopkeep_2_2

==shopkeep_2_1==
"No idea. Can't read myself. Here's the inventory if you like." He hands you a sheaf of parchment.
"Why do you have an inventory if you can't- Oh never mind." You examine the list.
->inventory

==shopkeep_2_2==
"Just t'other day, the Priest comes in all in a huff, going on about his book orders- he needs 'em now he says! No one needs books, I say!"
"Right..." you say. 
*["What kind of books?]
->shopkeep_2_1

==inventory==
*[Page 1] The first page contains orders for hymnals and blank parchment.
->inventory
*[Page 2] The second page is a list of obscure religious texts.
->inventory
*[Page 3] There is a single entry. "For the Priest: 'Proctor's Practical Witchcraft'"
->shopkeep_3

==shopkeep_3==
"A book on Witchcraft! Plain as day!" You exclaim excitedly.
"What!?" The Shopkeeper is outraged. "I never should have trusted him! Bloody clergy..."
You are relieved. At least someone believes you, even if it's the Shopkeeper.
~trust=trust+10
~gain_trust=true
->END
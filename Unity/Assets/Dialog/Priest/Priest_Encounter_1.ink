VAR trust=20
VAR was_hung=false
You find yourself on the gallows, a hempen noose about your neck. The Priest addresses the crowd.
"This woman is accused of Witchcraft! She has stolen all the young women of the village! For this she must hang by the neck until dead!
*["Wait, what?"]
->paragraph_1

==paragraph_1==
"Silence, witch!" Bellows the Priest. "We will hear nothing from you!"
"Is this what we have come to?" you ask "Execution without a trial?"
->crowd

==crowd==
*[Beseech the Crowd]
~trust=trust+5
->paragraph_1_1
*[Argue with the Priest]
~trust=trust-5
->paragraph_2_1
*[Try to Escape]
~trust=trust-15
->paragraph_3_1

==paragraph_1_1==
You search the crowd for friendly faces. 
*[Address the Blacksmith]
->paragraph_1_2
*[Address the Goodwife]
->paragraph_2_2
*[Address the Shopkeep]
->paragraph_3_2
*[Try to Escape]
->paragraph_3_1


==paragraph_2_1==
"You are not judge, jury, or executioner!" You proclaim, "What ever happened to the democratic process?"
The crowd appears to be confused, you are not helping your case.
->crowd

==paragraph_3_1==
You see no hope. You attempt to escape, in the process you trigger the hangman's switch, opening the trapdoor beneath you.
You plummet to your untimly death.
You didn't think it would be that easy did you?
~was_hung=true
->END 

==paragraph_1_2==
You catch the Blacksmith's eye. "You sir! Please help me!"
*[Your Daughter] "Have I not been a great friend to your daughter?"
~trust=trust+5
->paragraph_1_21
*[Loyal Customer] "Have I not been a loyal customer?"
~trust=trust-5
->paragraph_1_21

==paragraph_1_21==
He considers a moment.
{trust>20: "She's right!" He proclaims. "And must be allowed defend herself!" The crowd cheers for your release. ->priest | "You'll get no help from me, witch!" Looks like you need to find help elsewhere.}
->paragraph_1_1

==paragraph_2_2==
You catch the Goodwife's eye. "You ma'am! Please help me!"
*[Your Children] "Have I ever harmed your chiildren?"
~trust=trust+5
->paragraph_2_21
*[Illness] "Did I not bring you cake and wine when you were ill?"
~trust=trust+5
->paragraph_2_21

==paragraph_2_21==
She considers for a moment. 
{trust>20: "She's right!" She proclaims. "And must be allowed to defend herself!" The crowd cheers for your release. ->priest | "You'll get no help from me, witch!" Looks like you need to find help elsewhere.}
->paragraph_1_1

==paragraph_3_2==
You catch the Shopkeep's eye. "You sir! Please help me!"
*[Your Family] "Have I ever brought your family any harm?"
~trust=trust+5
->paragraph_3_21
*[Shop] "Have I not helped you at your Shop?"
He considers for a moment. 
~trust=trust-5
->paragraph_3_21

==paragraph_3_21==
{trust>20: "She's right!" He proclaims. "And must be allowed to defend herself!" The crowd cheers for your release. ->priest | "You'll get no help from me, witch!" Looks like you need to find help elsewhere.}
->paragraph_1_1


==priest==
*[Stare down the Priest]
~trust=trust+5
->priest_1
*[Call for your release]
~trust=trust-5
->priest_2

=priest_1
You fix the Priest with a steely gaze. After an eternity, he averts his eyes.
"Very well." He says acidly. "She shall have 2 days to clear her name."
He cuts your bonds and removes the noose. You are free.
->END


==priest_2==
"Free me Preist!" You shout. "The people have spoken! I am not a witch!"
The crowd murmers uneasily. The Priest smiles wickedly but cuts you loose.
You are free.
->END

VAR trust=25
VAR gain_trust=false

You approach the local Shopkeeper, a dim and stubborn man.
"Good morrow sir!" you begin.
"Oh no you don't!" He says. "I’ll not have witches coming round my shop!"
*"I'm no witch!" 
"Oh no? Tell me then, what happened to all them girls?"
->encounter_1

==encounter_1==
*"That's what I mean to find out[."], with your help."
"You expect me to help a filthy witch? Ha!" 
~trust=trust-5
-> paragraph_1

*"I dont know yet[."], but I will find the truth, my life depends on it."
"Your life eh? What about them girls? What about my girl?"
-> paragraph_2

*"It was the Priest who took them, not me!"
The Shopkeeper's face twists in a sneer. "Likely story! Get out of here you!"
~trust=trust-10
->END

==paragraph_1==
"How do you know I am a witch?" you ask gently.
"You look like one." he says.
*["Sigh."] "You can't judge a book by its cover. Just because I wear black does not make me a witch, why, does not the Priest dress strangely as well?" You inquire.
"I suppose that's true..." He admits.
~trust=trust+5
->paragraph_1_1

==paragraph_1_1==
*[Inquire further.] "In fact, shouldn't we always look in the place we least suspect?"
"That's where my key always is, at least when that Drunkard hasnt stolen it! And if I were to suspect someone it would be the Priest... always seemed odd that fellow." 
You nod happily, satisfied that you have cast sufficient doubt on the Priest.
~trust=trust+5
~gain_trust=true
->END

*[Suspect the Priest?] "So then should you not suspect him just as much as me?"
"He is a man of God!" the Shopkeeper exclaims. "He baptised every one of them girls!"
~trust=trust-5
->paragraph_1_2

==paragraph_1_2==
*"Be calm friend[."]. I only suggest that it is possible for, as you say, he does dress strangely"
The Shopkeeper's anger fades. "You are right, girl, I am sorry. The light of reason shines on me once more. The Priest has always been strange..."
You walk away, satisfied with your conversation.
~trust=trust+10
~gain_trust=true
->END

*"Ignorant fool[!"]! Don't you see how perfect his cover is!? No one suspects the Priest!."
Intimidated by your fury he admits: "Thats a fair point. Now I think of it, I've never liked that Priest..."
~trust=trust+5
~gain_trust=true
->END

==paragraph_2==
*"They will be forfeit[!"] if I hang, your daugter's life will be forfeit! But I can save them if you help me!"
His anger fades. "I suppose you are right. I will take any chance to save her. Say your piece."
~trust=trust+5
->paragraph_2_1
*"I care about them, [too."] they are my friends. Why would I cast suspicion on myself by attacking my friends?"
"Damn me if you're not right. It doesn't make sense. Who then?"
"Who has the most to lose?" You ask, glancing toward the church.
After a long moment. "...The Priest! Damn him!"
~trust=trust+5
~gain_trust=true
->END

==paragraph_2_1==
*"Thank you[."], all I ask is do not trust the Priest, you don't have to believe me, but do not believe him either," you implore. "He is more dangerous than you know."
{trust>25: The Shopkeeper nods slowly. As you leave, he glances at the church, doubt plain on his face. ->shopkeep_finale | "Not the Priest again! He's a man of god! Be gone girl!"}
->END

==shopkeep_finale==
~gain_trust=true
->END
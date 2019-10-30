VAR trust=25
VAR gain_trust=false

"There you are!" says the Goodwife, "I expect you'll want your washing now that you're not hung."
*"My washing[?"]? Oh of course! I hadn't really thought of that."
~trust=trust+5
->goodwife_1
*"I don't have time for washing[!"], my life is on the line!"
~trust=trust-5
->goodwife_2

==goodwife_1==
"It's not done yet so don't ask!" She says harshly. "I'm only one woman you know! You'll have to wait."
*"Thank you[."]," you say "I appreciate your work as I'm sure everyone does."
~trust=trust+5
->goodwife_1_1
*"That's fine[."]," you say "I likely won't need it."
~trust=trust+5
"You might just" says the Goodwife.
->goodwife_finale

==goodwife_2==
"Then what are you doing looking for your washing?" 
"I am not looking for my washing!" you say, perhaps too loudly.
"Well!" the Goodwife seems upset. "Such a rude girl!"
->END

==goodwife_1_1==
"Oh go on," she says with a smile "flattery doesn't work on me."
*"Of course not[."]. But I can try can't I?" You smile sweetly. 
"Oh alright then." says the Good wife.
~trust=trust+10
{trust>35: "Without you, this whole town would drown in filth!" She smiles. "I wasn't going to say nothing but..." ->finale | "You have lovely, er, skin?" You say. "Humph!" she says, clearly upset. ->END}
*"What about bribery[?"]?" you suggest. She turns her head sharply, "If the price is right."
~trust=trust+5
{trust>40: "I will keep you in cake and wine until you are fat and blind." ->goodwife_finale | "Foot massage?" You offer. "No deal!"}
->END

==goodwife_finale==
She looks furtively from side to side. "I have some imformation you might find interesting."
*["Please, anything!"]
~trust=trust+5
->goodwife_finale_1
*"Tell me what you know[!"]!" The Goodwife sneers "Not with that attitude!"
~trust=trust-5
->END

==finale==
*["Go on."]
->goodwife_finale_1

==goodwife_finale_1==
"Well, I was doing washing for the Priest and my word! The filth on his robes!"
"Why would they be filthy?" you wonder aloud.
"Also happens that I saw him slinking around the night them girls went missing." 
"You what!? Why didn't you say anything?" You leave frustrated but happy.
~gain_trust=true
->END

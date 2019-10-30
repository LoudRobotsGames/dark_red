VAR trust=25
VAR gain_trust=false

You approach the Goodwife, hopefully she will be less prickly this time...
->goodwife_1

==goodwife_1==
"It's not done yet so don't ask!" She says rather harshly. "I'm only one woman you know! You'll have to wait!"
*"Thank you[."]," you say "I appreciate your work as I'm sure everyone does."
~trust=trust+5
->goodwife_1_1
*"That's fine[."]," you say "Likely I won't need it."
~trust=trust+5
"You might just" says the Goodwife.
->goodwife_finale

==goodwife_1_1==
"Oh go on," she says with a smile "flattery doesn't work on me."
*"Of course not[."]. But I can try can't I?" You smile sweetly. "Oh alright then." says the Good wife.
~trust=trust+10
{trust>35: "Without you, this whole town would drown in filth!" She smiles. "I wasn't going to say nothing but..."->finale | "You have lovely, er, skin?" You say. "Humph!" she says, clearly upset. ->END}
*"What about bribery[?"]?" you suggest. She turns her head sharply, "If the price is right."
~trust=trust+5
{trust>35: "I will keep you in cake and wine until you are fat and blind." ->goodwife_finale | "Foot Massage?" You offer. "No deal!"}
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
"Also happens that I saw the Priest slinking around the night all them girls went missing."
"You what!? Why didn't you say anything?" You leave frustrated, but happy.
~gain_trust=true
->END

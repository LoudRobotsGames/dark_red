VAR trust=25
VAR aquire_key=false
VAR gain_trust=false

The steady clang of hammer on steel draws you to the town Smithy.
"Ho there Smithy!" you cry. The hammering stops.
{trust>50: "Ah there you are!" Says the Blacksmith. "I have something for you." He hands you a heavy iron key. "This is a key to the Church cellar, I thought you might be able to make use of it."->blacksmith_finale}
->smithy

==blacksmith_finale==
~aquire_key=true
->END

==smithy==
"Ah the young witch. Come to try your luck once more?"
*"I am sorry about your daughter[."]," you say "I hope to find her soon."
"I expect you do." He says. <>
~trust=trust+5
->smithy_1
*"I want to clear my name[."]
I expect you do." He says.
~trust=trust-5
->smithy_1

==smithy_1==
"And what do you want from me?"
"You can help me prove my innocence."
->arguments

==arguments==
*["When did you last see your daughter?"]
->smithy_1_1
*["Why do you belive the Priest?"]
~trust=trust-5
->smithy_1_2
*["Will you hear my side of the story?"]
~trust=trust+5
->smithy_1_3

==smithy_1_1==
"The night before she vanished," he says "with you."
"With me? That's impossible!" You insist.
"Well it's your word against the Priest then, and he is a man of God."
~trust=trust-5
->arguments

==smithy_1_2==
"He has never given me cause to misbelieve him." says the Smith.
You think for a moment. "Doesn't he inist that children will always be safe in God's grace?"
"Aye, he does...but witches are the work of the Devil."
*[Press on]
->smith_1_22

==smith_1_22==
"My point is, if you daughter is Godly, shouldn't she be safe despite the Devil?" The Blacksmith considers this. "You have given me much to think on..."
~trust=trust+10
{trust>25: ->smithy_2 | ->arguments}

==smithy_1_3==
"Go on," he says. It seems like he is getting impatient.
"I have been framed. Someone wants you to think I am a witch."
"Why should I believe that?"
*"Would a witch be so bold[?], wouldn't they want to be hide?"
"I suppose they would..." he replies
~trust=trust+5
->smithy_2
*"Because it's insane[!"]"
~trust=trust-5
"That's not a proper argument." He returns to his forge muttering, "Bloody witches"
->END

==smithy_2==
"That is all I ask." You say.
"I will at that," says the Smith "I never thought much of that Priest..." 
{trust>50: He thinks a moment, then hands you a heavy iron key. "This is a key to the Church cellar, I think you may be able to make use of it."->blacksmith_finale}
~trust=trust+5 
~gain_trust=true
->END
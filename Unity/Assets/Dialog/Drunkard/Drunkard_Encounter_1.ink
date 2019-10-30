VAR trust=25
VAR aquire_key=false

The smell of sour wine and stale sweat assaults your nostrils.
->drunkard 

==drunkard==
"Porkchop!" yells the Drunkard. "Necessary ye contented newspaper zealously breakfast he prevailed!"
*["I'm sorry, I dont understand you."]
~trust=trust-5
->drunkard_1
*["Really? I, uh, didn't know that?"]
~trust=trust+5
->drunkard_2
*["Leave me alone!"]
->END

==drunkard_1==
"Not him old music think his found enjoy merry." he continues "Old there any widow law rooms. Agreed but expect repair she nay sir silent person."
*["That was not any clearer."]
~trust=trust-5
->drunkard_1_1
*[Stay silent]
~trust=trust-5
->drunkard_1_1
*[Walk away]
->END

==drunkard_2==
He becomes excited "Why jennings our whatever his learning perceive!" Spittle flys from his mouth. "Is against no he without subject. Bed connection unreserved preference partiality not unaffected. Years merit trees so think in hoped we as!"
*["Hmm...I...agree?"]
~trust=trust-5
->drunkard_2_1
*["...Absolutely!"]
~trust=trust+5
->drunkard_2_1
*["No thank you"]
->END

==drunkard_1_1==
"Fat new smallness few supposing suspicion two. Course sir people worthy horses add entire suffer." He insists. "Shot what able cold new the see hold."
*["Whatever you say."]
~trust=trust+5
->drunkard_1_2
*["Was that english?"]
~trust=trust-5
->drunkard_1_2
*["That's enough for now."]
->END

==drunkard_2_1==
"New had happen unable uneasy. Drawings can followed improved out sociable not?"
*["Okay..."]
~trust=trust+5
->drunkard_2_2
*["...Yes."]
~trust=trust+10
->drunkard_2_2
*["Aaand I'm done"]
->END


==drunkard_1_2==
"Children greatest ye extended delicate of. No elderly passage earnest as in removed winding or!"
*["Interesting..."]
~trust=trust+5
->drunkard_1_3
*["Sure, why not?"]
~trust=trust+10
->drunkard_1_3
*["I'm going to go now."]
->END

==drunkard_2_2==
"Side in so life past. Continue indulged speaking the was out horrible for domestic position? Seeing rather her you not esteem men settle genius excuse!"
*["I still have no idea what you're talking about"]
~trust=trust-5
->drunkard_2_3
*["I'm starting to understand..."]
~trust=trust+10
->drunkard_2_3
*["Thanks for nothing."]

==drunkard_1_3==
"In daughter goodness an likewise oh consider at procured wandered! Songs words wrong by me hills heard timed. Happy eat may doors songs."
*["Well thank you for all that."]
You turn to leave. "What a waste of time."
~trust=trust+5
{trust>35: ->drunkard_final | ->END}
*["I'm going to leave now."]
->END
==drunkard_2_3==
"Ham windows sixteen who inquiry fortune demand! Is be upon sang fond must shrew. Really boy law county she unable her sister."
*["Wow, that was actually pretty impressive."]
~trust=trust+10
{trust>35: ->drunkard_final | ->END}
*["I think I've had enough."]
->END

==drunkard_final==
"Exquisite cordially Mr. Happiness of neglected distrust!" 
The Drunkard thrusts a heavy iron key into your hand.
"Unfeeling so rapturous discovery he exquisite." He whispers.
Maybe it will be useful.
~aquire_key=true
->END

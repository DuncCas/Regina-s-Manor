VAR allreadySaid = false
VAR sex = 0
VAR points = 0
VAR ask_about_job=false
-> FirstEncounter


===FirstEncounter===
You notice this one skelly creature by the side of X. By the looks, you can say the...
Uhm not really you can't say anything, since you can't really tell by the unreadable, pale and dead stare.
But the skeleton, even in your ignorance, notices of your presence.
"'Sup"
* ["Uh hey uhm.."]
->Greeting_Bad
* [And a talking skeleton... of course]
->Greeting_neutral
* [Hey.]
->Greeting_good



=== Greeting_Bad ===
"Yeah, hey. What you want?"
->GenericTalking1

===Greeting_neutral===
"And a cool one too if you can deal with it.."
->GenericTalking1

=== Greeting_good ===
{ ~points += 2}
"Yo, how's going.
->GenericTalking1

===GenericTalking1===
"Oh and before i forget, I'm Andrea.
* ["Soo what brings you here?"]
->WhyAreYouHere1
* ["How are you doing?"]
->HowAreYou1
* ["Why are you a skeleton?"]
->WhyAreYou1


===WhyAreYouHere1===
"Dude, i don't know, i was in my house, doing my 'Evening Janissery' like every Saturday night and then i woke up here."
"I knew that shit was strong but damn, if it made me shamble to this weird old house then it was like a Tsar bomb for me."
* ["Indeed, the.. how did you call it?"]
->Giannizzero1
* ["Soo you were soo high that you just waltzed here?"]
->AreYouHigh1

===Giannizzero1===
'Evening Janissery'. That's how i call the.. you know, like a..."
The skeleton starts make a gesture with the left pale hand, putting the two stick-like fingers up on the spot were the mouth was supposed to be.
* ["A blunt?"]
->BluntAnswer1
* ["How can you even smoke, you are a skeleton"]
->HowCanYouSmokeAnswer1
* ["Drugs?"]
->CopAnswer1

===AreYouHigh1===
"Were? Who says I'm not zonked right now."
->GoodOlDays

===BluntAnswer1===
"Yea! Right! That's right! And a really good one too."
->GoodOlDays

===HowCanYouSmokeAnswer1===
"Don't worry about that, I have my own ways to deal with my current endevour."
->GoodOlDays

===CopAnswer1===
"What are you? A cop?"
* ["Yes, and you are under arrest for doing illicit substances."]
->CopAnswer2
* ["What if i was?"]
->NotACop1
* ["A cop wouldn't act this obvious."]
->NotACop2

===CopAnswer2===
"Heh, look McClane, I only have boring and disgusting cigarettes with me." 
"Soo if you are trying to have a hold of my hand made, grade A "evidence" stuff that I do, you got bad luck.
->GoodOlDays

===NotACop1===
"I would have told you that I don't have any of the "illicit" with me."
* ["Is that true?"]
->DishonestAnswer
* ["Well I am a police officer, soo you must be honest with me."]
->CopAnswer2

===DishonestAnswer===
"..."
"..."
"No."
->HowAreYou1

===NotACop2===
"People could be very smart and asshole and also be very dumb and asshole."
"And sadly I had more experience with the smart asshole ones."
->HowAreYou1


===GoodOlDays===
"I never had a hit like that since forever. Since that one time at the graduation afterparty."
* ["Are you a graduate?"]
->Graduate1
* ["In how many homes did you break in?"]
->AfterParty0

===Graduate1===
"Yep! Wulprid University of Magic finest here! 110 with honors. Such a nerd i was."
->AfterParty1

===AfterParty0===
"Heh, more like how many tables i broke that night."
"Being a magic nerd makes you the best party rocker ever."
->AfterParty1

===AfterParty1===
"We decided to have a graduation party at the best student bar ever."
"Every bar with 5 gold Spritz deserves to have at least 5 stars in InnAdvisor."
"Anyway, i had this bag of blue magic powder that was the fucking bomb."
"And i thought to myself 'If i don't do it know it will be never' and i smoke the whole thing."
"I was seeing the rings of Saturn with this, and mixing it with the 5 gold Spritzs I slamdunkd on em!"
* ["I bet it was the best party ever."]
->BestPartyEver1
* ["I'm not a very big fan of parties."]
->Dontlikeparties

===BestPartyEver1===
"...."
"For the most part...."
->HowAreYou1

===Dontlikeparties===
"Ye, truth to be told, I hate them aswell."
"Assholes..."
->HowAreYou1



===HowAreYou1===
TODO
->END





===WhyAreYou1===
TODO
->END
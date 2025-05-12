VAR allreadySaid = false
VAR sex = 0
VAR points = 0
VAR ask_about_job=false
-> FirstEncounter


===FirstEncounter===
You notice this one skelly creature by the side of X. By the looks, you can say the...
Uhm not really you can't say anything, since you can't really tell by the unreadable, pale and dead stare.
But the skeleton, even in your ignorance, notices of your presence.
'Sup
* [Hello, gorgeous..]
->Greeting_Bad
* [And a talking skeleton... of course]
->Greeting_neutral
* [Hey.]
->Greeting_good



=== Greeting_Bad ===
Even if there are no eyes and mouth, you sense that you took her off guard with that statement.
Hey dude, we are going in weird places with that greeting. Just a hi would have been nice. I guess you humans are like this tho sooooo....
->DONE


=== Greeting_neutral ===
{ ~points += 1}
The "talking skeleton" chuckles after hearing those words, almost like it heard it so many times.
It's not like I'm the only weird thing in the room, like that dog dude over there...

\*sigh\* Ye, you know, it comes with the job i guess. Being a skeleton and all...
* What kind of job are you doing? I'm sure they require some papers to explains the "conditions" that you have.

-> JobAnswer1

=== Greeting_good ===
{ ~points += 2}
The skeleton aknowledges your reply with a little nod, then whips out a pack of cigarette from the kimono.
->Cigarette_Description



===Cigarette_Description===
Opens the packet, revealing 3 cylindric papers full of tobacco and a lighter.
{ask_about_job:
->JobAnswer1
-else:
->MindIfISmoke
}

===MindIfISmoke===
You got no problem if i smoke, right?
*Ye sure no worries
->DONE
*I FUCKING LOVE NICOTINE AND TOBACCO! NICOTINE AND TOBACCO IS THE ENGINE THAT MANTAINS THE SOCIETY WITH THE PILLARS OF KNOWLEDGE AND DESIRE! HELL YEA FOR NICOTINE
->DONE



===JobAnswer1===
Magic.
* That's an odd thing to do while being a skeleton.
->DONE
# fortis-prompt

Hello! This is a test project made to fortis.

My idea started thinking about how big this project should be, and at wich point i would stop working on it.
When i realized that is a very short project, I already started thinking about how I should organize things and getting some assets to work with.
As i was working with dependency injection for a long period and I didn't need to use it here got a idea to use service locator pattern that could be very easy to make and to use.
Once service locator is done, I went to core mechanics of the game. Starting with character spawning over time and objects pooling to make sure it will not have a memory peak problem.
When spawners were finished and characters models too, I started thinking about movement. I had 3 first ideas, NavMesh, MoveTowards or Physics.
Since physics is heavy and a boring to deal I discarted this idea soon. NavMesh seemed to be most malleable idea seeing that it can deal with different design scenarios and is not to heavy as physics, but i choosed MoveTowards.

Tha main focus with this idea was that it is the simplest/fastest to implement and i'm not creating any different terrain or anything like that, and if it is needed in any moment, it's easy to remove.
Talking about collision logic, i just went with collider system on unity, i thought about some different approachs (raycast, or distance check), but any of them seemed good enough.

The first problem that i had was when characters collided and my game just stopped because it was duplicating every time a new one was instantiate, causing a loop. The solution i had was just to create a delay that was improved later.

One more trouble that i had with collision was that i was creating 2 copies because of collider, so i started to using my collider system to deal with all collision and checks, so i can just reset delay to avoid creating 2 characters.

Honestly, there are some codes that can be improved like instantiate system(or factory system) or service locator, but i was more worried about a simple and understable code than a big and complex code.
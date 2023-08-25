# simulator-prompt

Hello! This is a test project made for test.

My idea started thinking about how big this project should be, and at which point I would stop working on it.
When I realized that it was a very short project, I started thinking about how I should organize things and get some assets to work with.
As I was working with dependency injection for a long period and didn't need to use it here got the idea to use a service locator pattern that could be very easy to make and to use.
Once the service locator was done, I went to the core mechanics of the game. Starting with character spawning over time and objects pooling to make sure it will not have a memory leak problem.
When spawners were finished and character models too, I started thinking about movement. I had 3 first ideas, NavMesh, MoveTowards, and Physics.
Since physics is heavy and boring to deal I discarded this idea soon. NavMesh seemed to be the most malleable idea seeing that it can deal with different design scenarios and is not to heavy as physics, but I chose MoveTowards.

The main focus with this idea was that it is the simplest/fastest to implement and I'm not creating any different terrain or anything like that, and if it is needed at any moment, it's easy to remove.
Talking about collision logic, I just went with the collider system on unity, I thought about some different approaches (raycast, or distance check), but any of them seemed good enough.

The first problem that I had was when characters collided and my game just stopped because it was duplicating every time a new one was instantiated, causing a loop. The solution I had was just to create a delay that was improved later.

One more trouble that I had with collision was that I was creating 2 copies because of collider, so I started to use my collider system to deal with all collision and checks, so I could just reset the delay to avoid creating 2 characters.

Honestly, there are some codes that can be improved like instantiate system(or factory system) or service locator, but I was more worried about a simple and understandable code than a big and complex code.

Talking a bit about performance, the game was slowly consuming more memory and fps was slowly decreasing, but without huge drops, some spikes of memory when the garbage collector was running, but I didn't find any huge problem with that.

Features Implemented:
1. 3D Scene:
A scene with an obstacle course has been built. There are also
some stacked rigidbody cubes for the player to interact with.

2. First Person Shooter Controls:
Unity's new input system was used to implement the first person 
character. Basic movement and double has been implemented. The
number of jumps 'in the air' is customizable from the Inspector window
and can be modified to do multiple 'air jumps'.

3. Weapons:
Three types of weapons has been implemented from a base Weapon class:
	a. Handgun: Accurate gun which fires 1 shot on the frame the
	the left mouse button is pressed.

	b. Gattling Gun: The gattling gun keeps firing while the left
	mouse button is held. The gattling gun has random accuracy. The 
	fire rate of the gattling gun can be modified from the inpecto 
	window of the gattling gun (child of main camera, which is 
	child of player). Other modifiable properties includes the
	accuracy, impact force, and range of bullets.

	c. Grenade: The grenade throw distance is based on the hold time
	of the left mouse button. The grenade is thrown on the frame the
	left mouse button is let go. This instantiates the grenade projectile
	which adds an impulse explosion to all rigid bodies around a radius 
	of the projectile.

4. Picking Up Weapons:
This is done using the weapon spawners. The player can walk into the weapon spawner
which detects the player with a isTrigger collider and equips the respective weapon
to the player. The weaponspawner respawns the weapon after 5 seconds (modifiable from
the inspector).

5. Issues encountered:
Unity's built in isGrounded does not work well with the character controller component.
It only detects the ground when the character controller is in motion. This created problems
like the jump count not being resetted if the player would jump in place, making double jump
implementation very difficult.

I implemented my own isGrounded logic using a physics overlap sphere on an empty child object
on the player. This solved the issue.
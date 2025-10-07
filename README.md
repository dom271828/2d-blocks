# 2d-blocks

## Play Link
https://play.unity.com/en/games/f4ce92c2-e30b-4088-86d7-ef928e5eb04e/gray-data

## Game Description
The game's objective is simple, collect the spiral artifacts to win the game. You win once you reach a certain score thereshold (reflected by the # of artifacts), but you lose if you touch a sawblade. I tried to make my theme engaging by juxtaposing the industrial background with more colorful spirals. 

## Technical Implementation
### Level
I made a map by outlining borders and using an image as a sort of backdrop.

### Sprites
I added sprites for important elements of the game such as the player, hazards (sawblades), border/solid walls, powerup (boost), collectibles (artifacts), metal boxes which can be moved by the player, and tar which slows the player temporarily. I used a closed sprite shape for the tar, with correct import settings for texture's sake.

### Prefabs
Pretty much everything above with the exception of the player exists as a prefab object; this allowed me to easily dupe objects for efficient level creation. I made sure that the object was edited to my liking *before* making into a prefab, i.e. adding particle effects to my original "boost" sprite.

### Colliders
Used regular colliders for border and box objs and "is trigger" colliders for most everything else. The trigger colliders are reflected in my code with each tag representing a different object that the player collided with.

### Rigidbodies
Used rigidbodies on the box objs. This created an interesting dynamic with the player - while the player was unable to completely control the direction the boxes moved, I could design areas where the player could push *through* some boxes to access an artifact. They also interact with the hazards, disappearing upon touching a blade.

### Triggers
Used trigger zones with both the tar and collectibles/hazards. The hazards/artifacts were simple: (respectively) destroy the player when touching an artifact, since I didn't have a health system, and destroy object on use while increasing score. The boost increased temporarily the speed of the player, allowing for better navigation (with the drawback being less steering control). For that, I implemented a timer in my update portion of the code. For the tar, I decreased player speed upon entering a trigger zone, and reverted it back once I left. I made sure the boost remained during the effect.

### UI Text
Three text fields were used that dynamically updated.
Status - Gives a win/loss status, visible only when player collects artifacts, or gets destroyed by hazard
Score - Updates whenever gaining an artifact, visible the whole time
Boost - Shows time elapsed whenever player hits boost object, visible when player picks up boost powerup

### Sprite Movement
Uses input system to move and steer player like a traditional top down game. Move speed changes when hitting a boost or moving within tar. Boost speed stays static for balancing.

### Particle System
Used a particle system for boosts, as well as an explositon effect similar to the one used in the previous mini-project.

### GameObject Management
Destroyed player object or collision object when touching a powerup/hazard. Implemented a restart system which simply reloads the scene when player is destroyed.

Also used a transform command to rotate saws a set # of degrees per frame.

## Future Development Plan
I feel like if this game were to expanded, I would definitely make each level smaller than the map I'm using right now. Then there could be more powerups that did various other things to the player, i.e. make it smaller so it can fit into tighter crevices using a transform command, or temporarily invulnerable to hazards (treating them like boxes) by changing the hazard collider's interactions when it touches the player.

Right now the game isn't that polished appearance wise. I had a direction for the theme/color scheme, but I think adding more assets and hazard sprites could enhance the appearance of it a lot, also making different sprite shapes for the tiles was something I could do as well. 

The theme can also be expanded upon, like making it a spaceship or underground base or similar. If I had more time/capabilities I could spin some type of short narrative with more levels/areas in the same vein as what I built.

## Reflection
I think the most challenging part of this project was the creativity part, formulating an idea and putting it into practice. There are a lot of *things* to account for that can be easily explained but oftentimes the implementation can be challenging for me. None of this stuff feels quite second nature to me yet especially when it comes to the limitless possibilities that require such careful implemention, it's a little daunting. There were times where I was worried about how the game looked, or how to get a certain mechanic to work. I ended up using stack overflow a little bit, but honestly copying stuff from older projects helped. 

What I would definitely do differently next time is organization, and actually planning out a process. Most of this development was scatterbrained where I often didn't have a set course of action of what to do. A simple checklist could have probably helped here. With the previous mini project it was more structured so I had an idea of each step, with this one it was kind of on my own. The recommended steps were a nice thing to have, but even then there was so much to every step that once again it got overwhelming thinking about it without a regimented list of things to do. I definitely missed out a bit on important steps like playtesting. I think it overall turned out okay, there's room for improvement though.








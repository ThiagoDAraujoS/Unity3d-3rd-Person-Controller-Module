# Unity3d 3rd Person Controller Module
### About
#### Description
As the name suggests this repository contains the scripts for a generic 3rd person controller.

#### Development
This repository is being developed as a sub module of [Project Byzantium](https://github.com/ThiagoDAraujoS/Unity3d-Project-Byzantium-702963), as Byzantium requires this module's elements to be created, they will be implemented as such. 

### Table of Contents
#### - North
This component exposes a *North* directional vector, this vector works as a spacial transformation for the input's _"movement"_ return values, which by default listens to the _left analog stick_.
```
For example: If *North* is set as [0, -1] (pointing left).
when a player pushes forward [1, 0], that direction will be remapped to [0, -1] instead,
as well as if in the same setting he pushes right [0, 1] it will be remapped to [1, 0].
```
_The reason behind this design decision is to allow versatility for this tool. For instance: 
a game like Bidding of Isaac could bind the North vector to the world's Forward vector.
In a more complex example, a game like Zelda Ocarina of Time, could bind the North vector to the camera's Forward vector while travelling, then dynamically change that binding to an enemy "lookat vector" to make the character's controller "Lock On" to that enemy, then change again to a predefined vector when the player is inside a constrained space._

#### - North's Compass
Bound to the *North* vector's mechanic, there's an automatic smoothing system behind it called *Compass*. Whenever *North* gets changed, the result transformation will not instantly snap into the new *North*'s identity, instead the output vector will slowly interpolate from where *North* was previously, into its new identity. That interpolation can be tightly controlled by an exposed animation curve and custom speed values.

_This design choice allows the controls to be more or less fluid depending on the game's identity._

#### - Input Pressure Curves and Sensitivity
The system also exposes a curve that remaps how the movement's axis pressure works, 
_This allows for a finer tuning of the controls, since a game designer can tune how the game responds to the controls in a more specialized way than just setting a specific value for sensitivity._

#### - Grounding Check


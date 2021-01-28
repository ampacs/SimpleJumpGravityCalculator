# Simple Jump Gravity Calculator

This Unity project provides a simple way for testing various types of physics-based jumping mechanics, namely height, time and apex fraction.
The apex fraction determines the portion of the entire jump time that the player spends ascending.
An example scene can be found at Scenes/ExampleScene where a test playground and player are available.

## Gravity Force Calculator
 
 Located at `Physics/Gravity/GravityForceCalculator`
 
 Allows calculating the upwards and downwards gravity forces necessary for achieving the given jump parameters: jump height, time and apex fraction
 
## Jump Force Calculator

 Located at `Physics/Jump/JumpForceCalculator`
 
 Allows calculating the necessary initial impulse for the player to reach the target jump height for the given gravity and mass 

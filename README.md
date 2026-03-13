# Garden Guardians

## Overview
Garden Guardians is a prototype tower defence game developed in Unity.  
The goal of the project is to explore core gameplay mechanics commonly used in tower defence games, such as enemy movement, automatic tower attacks, and basic interaction between game objects.

This project focuses on building a functional gameplay prototype before expanding the game with additional features and systems.

## Gameplay Concept
In Garden Guardians, enemies move across the map while defensive towers automatically detect and attack them when they enter their range.

The objective is to prevent enemies from progressing through the map by strategically placing towers that eliminate them before they reach the end.

This prototype currently focuses on the fundamental gameplay loop:
1. Enemies move across the level
2. Towers detect enemies within range
3. Towers attack and eliminate enemies

## Current Features
The current prototype includes the following implemented systems:

- Enemy movement across the map
- Towers that detect enemies using trigger ranges
- Automatic tower attacks when enemies enter range
- Multiple enemy objects
- Basic collision detection
- Simple game prototype demonstrating the core mechanics

## Project Structure

### Scripts

**EnemyMovement.cs** 
Handles the movement of enemy objects across the map.

Responsibilities:
- Moves enemies along a defined direction
- Controls the speed of enemy movement

**TowerAttack.cs**  
Handles tower behaviour and enemy detection.

Responsibilities:
- Detects enemies using trigger collision
- Automatically destroys enemies when they enter attack range


### Main Scene

The main scene contains:
- Enemy objects representing moving targets
- Tower objects that automatically attack enemies
- Basic game space used to demonstrate the tower defence mechanics

## Technologies Used

- Unity Game Engine
- C#
- Unity Physics and Collision System
- Unity Inspector for configuring components

## Development Process

The development process focused on building a minimal working prototype of a tower defence system. The first stage involved implementing enemy movement across the game scene.

Once enemy movement was functioning correctly, tower objects were introduced with trigger-based detection systems to identify enemies entering their range.

The tower attack logic was then implemented to automatically eliminate enemies when detected.

This iterative approach allowed the project to gradually build the core gameplay mechanics required for a tower defence game.

## Future Improvements

Several features are planned for future development:

- Enemy health system
- Enemy waves and spawning system
- Score tracking
- User interface (UI)
- Multiple tower types
- Tower upgrades
- Different enemy types
- Improved visuals and environment design
- Game balancing and difficulty scaling

These additions will expand the gameplay loop and improve the overall player experience.

## Current Status

This project represents an early gameplay prototype. The main focus at this stage is verifying that the core tower defence mechanics function correctly before expanding the game with additional systems.

## Author

Aboubakar Hameed Sultan
Game Development Project – Unity Prototype

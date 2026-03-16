# Garden Guardians

**Student Name:** Aboubakar Hameed Sultan  
**Project:** Garden Guardians Prototype  
**Engine:** Unity  
**Language:** C#

---

# Project Overview

Garden Guardians is a prototype tower defence style game developed using Unity and C#. The aim of the project is to demonstrate the core mechanics behind a tower defence game, specifically enemy pathing and interaction with a defined endpoint.

In the current prototype, enemies are represented as red spheres that move along a path toward a target location. This target is represented by a green sphere which acts as the endpoint. When enemies reach the endpoint they are removed from the scene.

The main goal of this prototype is to establish and test the fundamental gameplay systems that would support a complete tower defence game in the future.

---

# Demo Video

You can view the demonstration video here:

[https://youtu.be/VWH5S40hhas
](https://www.youtube.com/watch?v=ONi_ob_3ONQ)
The video demonstrates the enemy pathing system where enemies move along the path and disappear when they reach the endpoint.

---

# User and System Requirements

The project requirements were defined using Scrum-style user stories. These describe what both the player and the system should be able to do.

**User Story 1**  
*As a player, I want enemies to move along a path so that the game feels active and engaging.*

**User Story 2**  
*As a player, I want enemies to follow a clear path toward an endpoint so that the gameplay is easy to understand.*

**User Story 3**  
*As a player, I want enemies to disappear when they reach the endpoint so that the game can track successful enemy progression.*

**User Story 4**  
*As a developer, I want to implement enemy movement using scripts so that the behaviour can be easily controlled and modified.*

**User Story 5**  
*As a developer, I want a basic environment where enemy movement can be tested before implementing more complex mechanics.*

These requirements formed the foundation of the prototype and guided development.

---

# Scrum Backlog

The project was organised using a simple backlog system to prioritise development tasks.

| Task | Description | Priority | Status |
|-----|-------------|----------|-------|
| Create Unity project | Set up the initial Unity environment and project structure | High | Complete |
| Create path tiles | Build a simple path using tiles to represent the level layout | High | Complete |
| Create enemy objects | Add red spheres to represent enemy characters | High | Complete |
| Create endpoint object | Add a green sphere as the target location | High | Complete |
| Implement enemy movement | Develop a script that moves enemies toward the endpoint | High | Complete |
| Test enemy behaviour | Verify enemies move correctly and reach the endpoint | High | Complete |
| Fix physics issues | Adjust Rigidbody settings to stop enemies falling | Medium | Complete |
| Record demo video | Demonstrate prototype behaviour | Medium | Complete |
| Implement towers | Add defensive towers to attack enemies | Medium | Planned |

---

# Design Documentation

## Game Flow Diagram

The basic gameplay flow of the prototype can be represented as the following process:

```
Start Game
    |
Spawn Enemy
    |
Enemy Moves Along Path
    |
Reached Endpoint?
   / \
 Yes  No
  |    |
Remove Enemy
  |
Spawn Next Enemy
```

This flow shows the main logic implemented in the prototype. In later versions this would expand to include tower attacks, enemy waves and player health.

---

## Enemy Movement Pseudocode

The movement behaviour of enemies can be described with the following pseudocode:

```
Start

Set target position to endpoint

While enemy exists in the scene
    Move enemy towards the target position
    
    If enemy reaches the endpoint
        Destroy enemy object
    End If

End While

End
```

This logic forms the core gameplay mechanic that allows enemies to navigate the level.

---

## Screen Design

The prototype currently uses a simple layout designed for testing gameplay mechanics.

Main Screen Elements:

- **Path Tiles** – Define the route enemies follow
- **Enemy Objects** – Represented by red spheres
- **Endpoint Object** – Represented by a green sphere
- **Game Camera** – Displays the level and enemy movement

Future versions of the game will likely include additional interface elements such as:

- Player health display
- Resource or score indicators
- Tower placement controls
- Wave counters

---

## Concept Artwork and Visual Direction

At this stage the game uses placeholder assets (spheres and tiles) to represent game elements. These allow gameplay mechanics to be tested before detailed art assets are created.

Planned visual ideas include:

**Enemies**  
Small creature-like characters attempting to invade the garden.

**Towers**  
Plant-based defensive towers such as flower cannons or vine traps.

**Environment**  
A colourful garden environment with grass, flowers and winding paths.

The visual direction is intended to be bright and accessible, with clear visual feedback so players can easily understand what is happening in the game.

---

# Design and Development

## Game Concept

Garden Guardians is designed as a tower defence game where players must protect a garden from incoming enemies. Enemies follow a path and attempt to reach a target point. In a full version of the game, players would place towers along the path to stop enemies before they reach the endpoint.

This prototype focuses on implementing and testing the enemy movement system that would support this gameplay.

---

## Environment

The environment consists of a simple path created using tiles. These tiles define the route that enemies follow across the level.

The environment is intentionally simple so that the focus remains on testing core gameplay mechanics rather than visual design.

---

## Characters

Enemies are represented by red spheres which act as placeholder characters.

The endpoint is represented by a green sphere which acts as the destination that enemies attempt to reach.

These placeholder assets allow gameplay systems to be tested before adding detailed character models or artwork.

---

## Gameplay Loop

The gameplay loop for the prototype is currently simple:

1. The game begins and enemies appear in the scene
2. Enemies move along the defined path
3. Enemies reach the endpoint
4. The enemy object is removed from the scene

In a full implementation this loop would expand to include towers, enemy waves, player resources and increasing difficulty.

---

# Programming and Technical Implementation

The project was developed using the Unity game engine and programmed using C#.

Enemy behaviour is controlled through a movement script attached to each enemy object. The script calculates the direction between the enemy and the endpoint and moves the enemy toward that position each frame.

During development, several technical challenges were encountered. Initially enemies were falling off the path due to gravity being enabled in the Rigidbody component. This issue was resolved by disabling gravity and freezing the vertical axis to ensure enemies remain on the path.

This process demonstrated how Unity physics and scripting interact when creating gameplay mechanics.

---

# Project Management

Development followed a simplified Scrum-style workflow where tasks were divided into smaller goals and reviewed regularly.

## Development Session 1

**Completed Tasks**
- Created Unity project
- Built the initial environment using tiles

**Next Steps**
- Implement enemy objects

**Problems Encountered**
- Adjusting object positions and learning the Unity interface

---

## Development Session 2

**Completed Tasks**
- Implemented the enemy movement script

**Next Steps**
- Test enemy interaction with the endpoint

**Problems Encountered**
- Enemies were falling due to gravity settings

---

## Development Session 3

**Completed Tasks**
- Fixed Rigidbody physics settings
- Confirmed enemies move correctly toward the endpoint

**Next Steps**
- Record the demo video and finalise documentation

**Problems Encountered**
- Configuring Rigidbody constraints so enemies remained on the path

---

# Tools and Technologies

The following tools were used during development:

- **Unity** – Game engine used to build the prototype  
- **C#** – Programming language used for scripting  
- **Visual Studio Code** – Code editor used for development  
- **Git** – Version control system  
- **GitHub** – Repository hosting and documentation  
- **YouTube** – Hosting the project demo video

These tools supported both the technical development and documentation of the project.

---

# Testing

Several tests were conducted to ensure the core mechanics function correctly.

**Test 1**  
Objective: Verify enemies move toward the endpoint.  
Result: Successful.

**Test 2**  
Objective: Verify enemies disappear when reaching the endpoint.  
Result: Successful.

**Test 3**  
Objective: Ensure enemies stay on the path and do not fall.  
Result: Initially failed due to gravity settings but was fixed by adjusting Rigidbody constraints.

Testing ensured that the prototype behaves as expected and helped identify technical issues during development.

---

# Future Improvements

Several improvements could be implemented to expand the project:

- Add defensive towers that attack enemies
- Implement enemy waves and difficulty progression
- Add player health and scoring systems
- Replace placeholder spheres with detailed character models
- Add sound effects and background music
- Create multiple levels with different path layouts

These features would transform the prototype into a more complete tower defence game.

---

# Conclusion

The Garden Guardians prototype successfully demonstrates the core mechanics required for a tower defence game. The enemy movement system and endpoint interaction form the foundation for future gameplay features.

Although the current version is intentionally simple, it establishes the key systems needed for a more complete tower defence experience in future development sprints.

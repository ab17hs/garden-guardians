🌿 Garden Guardians – Game Design Document
Repository: https://github.com/ab17hs/garden-guardians.git
Student: Aboubakar Hameed Sultan | ID: 23059674
Module: Software Development 2
Engine: Unity | Language: C#
---
📋 Table of Contents
Project Overview
Sprint 1 Summary
Sprint 2 Backlog
Sprint 2 Design & Development
Development Review Meetings
Burndown Chart
Testing Plan & Results
Tools & Techniques
Code Documentation
Sprint 2 Summary & Next Steps
---
🎮 Project Overview
Garden Guardians is a tower defence game developed in Unity using C#. Players place defensive towers to prevent waves of enemies from reaching the endpoint. The game is designed around simplicity and scalability, with each sprint building progressively on a working prototype.
Core Gameplay Loop:
```
Enemy spawns → Follows path → Tower detects enemy → Tower attacks → Enemy destroyed or reaches endpoint → Score/health updated → Next wave
```
---
✅ Sprint 1 Summary
Sprint 1 delivered a functional prototype covering the core engine of the game:
Feature	Status
Enemy pathing system (Vector3.MoveTowards)	✅ Complete
Endpoint detection and enemy destruction	✅ Complete
Basic tower attack (range-based, tag detection)	✅ Complete
Physics fix (Rigidbody gravity constraints)	✅ Complete
Single-wave enemy spawning	✅ Complete
GitHub repository setup	✅ Complete
---
📌 Sprint 2 Backlog
The Sprint 2 backlog was defined using Scrum methodology. Each item includes a User Story, Acceptance Criteria, and Test Definition.
---
BACKLOG ITEM 1 — Wave Manager System
User Story:
> As a player, I want enemies to spawn in waves so that the game has escalating difficulty and a clear progression structure.
Priority: HIGH
Story Points: 5
Acceptance Criteria:
Enemies spawn in numbered waves (Wave 1, Wave 2, etc.)
Each subsequent wave contains more enemies than the last
A delay between waves allows the player time to prepare
The current wave number is displayed on the UI
Definition of Done:
WaveManager.cs script creates and manages wave sequences
EnemyCount increases by a configurable multiplier each wave
Wave number updates correctly in the UI
Tested across 5 consecutive waves with no spawn errors
Test:
```
GIVEN the game has started
WHEN Wave 1 completes (all enemies destroyed or reach endpoint)
THEN Wave 2 begins after a 5-second delay with 2 additional enemies
```
---
BACKLOG ITEM 2 — Player Health System
User Story:
> As a player, I want to lose health when enemies reach the endpoint so that reaching the endpoint feels consequential and the game has a lose condition.
Priority: HIGH
Story Points: 3
Acceptance Criteria:
Player starts with 10 health points
Each enemy reaching the endpoint deducts 1 health
Health is displayed prominently on the UI
When health reaches 0, a Game Over screen is displayed
Definition of Done:
PlayerHealth.cs tracks and updates health correctly
Game Over scene triggers when health == 0
UI health counter reflects correct value at all times
Test:
```
GIVEN the player has 10 health
WHEN 10 enemies successfully reach the endpoint
THEN the Game Over screen is displayed and the game stops
```
---
BACKLOG ITEM 3 — Score System
User Story:
> As a player, I want to earn points for destroying enemies so that I feel rewarded for effective tower placement.
Priority: MEDIUM
Story Points: 2
Acceptance Criteria:
Player earns 10 points for each enemy destroyed by a tower
Score is displayed in the UI and updates in real time
Score persists across waves within a single game session
Definition of Done:
ScoreManager.cs increments score on enemy destruction
Score UI element updates immediately on each kill
Score resets correctly on game restart
Test:
```
GIVEN the player has 0 points
WHEN a tower destroys 3 enemies
THEN the score display shows 30
```
---
BACKLOG ITEM 4 — Tower Placement System
User Story:
> As a player, I want to place towers on the map using mouse input so that I can actively defend the path rather than having towers pre-placed.
Priority: HIGH
Story Points: 8
Acceptance Criteria:
Player can click on valid grass tiles to place a tower
Towers cannot be placed on path tiles or other towers
A preview ghost of the tower follows the mouse cursor
Tower placement costs in-game currency (coins)
Definition of Done:
TowerPlacer.cs handles mouse input and raycasting to grid
Invalid placements are visually highlighted (red ghost)
Valid placements are confirmed with a green ghost
Coin cost deducted on successful placement
Test:
```
GIVEN the player has sufficient coins
WHEN the player clicks a valid grass tile
THEN a tower is placed, coins are deducted, and the ghost resets
```
---
BACKLOG ITEM 5 — Currency System
User Story:
> As a player, I want to earn coins for destroying enemies so that I can use them to place more towers and engage in a resource management loop.
Priority: MEDIUM
Story Points: 3
Acceptance Criteria:
Player starts with 100 coins
Each enemy destroyed grants 15 coins
Coins are deducted when a tower is placed
Coin balance is displayed in the UI
Definition of Done:
CurrencyManager.cs tracks coin balance
Coins awarded via event on enemy death
Tower placement blocked if insufficient coins
UI updates immediately on earn/spend
Test:
```
GIVEN the player has 100 coins and a tower costs 50
WHEN the player places 2 towers
THEN the coin balance shows 0 and further placement is blocked
```
---
BACKLOG ITEM 6 — UI System (HUD)
User Story:
> As a player, I want to see key game information (health, score, wave, coins) on screen at all times so that I can make informed decisions during gameplay.
Priority: HIGH
Story Points: 4
Acceptance Criteria:
HUD displays: Wave number, Health, Score, Coins
All values update in real time
UI is clear, readable, and does not obscure gameplay
Game Over panel appears when health reaches 0
Definition of Done:
UIManager.cs references all relevant scripts
All four counters display and update correctly
Game Over panel shows final score and restart button
Layout tested at 1920x1080 resolution
Test:
```
GIVEN the game is running
WHEN health drops to 0
THEN the Game Over panel appears with the player's final score
```
---
BACKLOG ITEM 7 — Tower Cooldown & Damage Values
User Story:
> As a player, I want towers to have a fire cooldown so that the game requires strategic placement rather than a single tower being overpowered.
Priority: MEDIUM
Story Points: 3
Acceptance Criteria:
Towers have a configurable attack cooldown (default: 1 second)
Tower damage is a configurable value (default: 1)
Cooldown timer resets correctly after each attack
Definition of Done:
Tower.cs updated with fireRate and damage variables
Timer logic implemented using Time.deltaTime
Values exposed in Unity Inspector for tuning
Test:
```
GIVEN a tower with fireRate = 1.0f and an enemy in range
WHEN 3 seconds pass
THEN the tower has attacked exactly 3 times
```
---
BACKLOG ITEM 8 — Game Over & Restart
User Story:
> As a player, I want a Game Over screen with a restart option so that I can play again without reopening the game.
Priority: LOW
Story Points: 2
Acceptance Criteria:
Game Over panel displays on health = 0
Shows final score and wave reached
Restart button reloads the game scene
Main menu button returns to a start screen
Definition of Done:
GameOverManager.cs handles scene reloading
Final score and wave displayed correctly
All enemy/tower objects cleared on restart
Test:
```
GIVEN the Game Over screen is shown
WHEN the player clicks Restart
THEN the scene reloads and health/score/wave reset to starting values
```
---
🏗️ Sprint 2 Design & Development
System Architecture Diagram
```
┌─────────────────────────────────────────────────────────┐
│                     GAME MANAGER                         │
│           (Coordinates all systems)                      │
└───────────┬─────────────────────┬───────────────────────┘
            │                     │
   ┌────────▼───────┐    ┌────────▼────────┐
   │  WAVE MANAGER  │    │   UI MANAGER    │
   │  - SpawnWave() │    │  - UpdateHUD()  │
   │  - NextWave()  │    │  - ShowGameOver │
   └────────┬───────┘    └────────┬────────┘
            │                     │
   ┌────────▼───────┐    ┌────────▼────────┐
   │    ENEMY       │    │ SCORE/CURRENCY  │
   │  - MovePath()  │    │ - AddScore()    │
   │  - TakeDamage()│    │ - AddCoins()    │
   └────────┬───────┘    └─────────────────┘
            │
   ┌────────▼───────┐
   │    TOWER       │
   │  - FindTarget()│
   │  - Attack()    │
   │  - Cooldown()  │
   └────────────────┘
```
---
Flowchart: Wave Manager Logic
```
START
  │
  ▼
Initialise Wave 1
  │
  ▼
Spawn [enemyCount] enemies ──────────────────────┐
  │                                               │
  ▼                                               │
All enemies destroyed or reached endpoint? ──No──┘
  │ Yes
  ▼
Wave Complete
  │
  ▼
Increment wave number
Increase enemyCount (+ waveMultiplier)
  │
  ▼
Delay (5 seconds)
  │
  ▼
Loop → Spawn next wave
```
---
Flowchart: Tower Attack Logic (Updated)
```
START (each frame)
  │
  ▼
Is cooldown timer > 0?
  │ Yes → Decrement timer, skip
  │ No
  ▼
Find nearest enemy within range
  │
  ▼
Enemy found?
  │ No → Wait
  │ Yes
  ▼
Deal damage to enemy
Trigger score + coin award
Reset cooldown timer
  │
  ▼
Is enemy health <= 0?
  │ Yes → Destroy enemy
  │ No → Wait for next frame
```
---
Pseudocode: WaveManager.cs
```
CLASS WaveManager
  VARIABLES:
    waveNumber = 0
    enemyCount = 5
    waveMultiplier = 2
    spawnDelay = 1.0f
    waveDelay = 5.0f
    enemyPrefab : GameObject
    spawnPoint : Transform

  FUNCTION StartGame():
    waveNumber = 1
    SpawnWave()

  FUNCTION SpawnWave():
    UIManager.UpdateWave(waveNumber)
    FOR i = 1 TO enemyCount:
      Instantiate(enemyPrefab, spawnPoint)
      Wait(spawnDelay)
    Wait for all enemies dead or at endpoint
    CALL WaveComplete()

  FUNCTION WaveComplete():
    waveNumber += 1
    enemyCount += waveMultiplier
    Wait(waveDelay)
    SpawnWave()
END CLASS
```
---
Pseudocode: Tower.cs (Updated)
```
CLASS Tower
  VARIABLES:
    range = 5.0f
    damage = 1
    fireRate = 1.0f
    fireCooldown = 0.0f
    target : Transform

  FUNCTION Update():
    IF fireCooldown > 0:
      fireCooldown -= Time.deltaTime
      RETURN

    target = FindNearestEnemy()
    IF target != NULL:
      Attack(target)
      fireCooldown = 1.0f / fireRate

  FUNCTION FindNearestEnemy():
    enemies = FindObjectsWithTag("Enemy")
    nearest = NULL
    minDist = range
    FOR each enemy IN enemies:
      dist = Distance(self, enemy)
      IF dist < minDist:
        nearest = enemy
        minDist = dist
    RETURN nearest

  FUNCTION Attack(target):
    target.GetComponent<Enemy>().TakeDamage(damage)
    ScoreManager.AddScore(10)
    CurrencyManager.AddCoins(15)
END CLASS
```
---
Pseudocode: PlayerHealth.cs
```
CLASS PlayerHealth
  VARIABLES:
    maxHealth = 10
    currentHealth = 10

  FUNCTION TakeDamage(amount):
    currentHealth -= amount
    UIManager.UpdateHealth(currentHealth)
    IF currentHealth <= 0:
      GameOver()

  FUNCTION GameOver():
    UIManager.ShowGameOver(ScoreManager.score, WaveManager.waveNumber)
    Time.timeScale = 0
END CLASS
```
---
Changes from Sprint 1 (Highlighted)
> **All items below are new additions in Sprint 2. Sprint 1 code remains unchanged as the foundation.**
File	Change Type	Description
`WaveManager.cs`	NEW	Full wave spawning system with configurable count and multiplier
`PlayerHealth.cs`	NEW	Health tracking with Game Over trigger
`ScoreManager.cs`	NEW	Score tracking with event-based increment
`CurrencyManager.cs`	NEW	Coin economy: earn on kill, spend on placement
`TowerPlacer.cs`	NEW	Mouse-click tower placement with raycast grid detection
`UIManager.cs`	NEW	HUD controller: wave, health, score, coins, game over panel
`Tower.cs`	UPDATED	Added `damage`, `fireRate`, `fireCooldown` variables and attack timer
`Enemy.cs`	UPDATED	Added `TakeDamage()` method and `health` variable
Scene: `GameScene`	UPDATED	Added UI Canvas, tower placement tiles, wave spawn point
---
📅 Development Review Meetings
---
Meeting 1 — Sprint 2 Kickoff
Date: Week 7
Format: Solo development session
What was done since last meeting (Sprint 1 complete):
Delivered working enemy pathing, endpoint detection, and basic tower attack
Confirmed all Sprint 1 tests passing
GitHub repository up to date with Sprint 1 code
What is planned for this session:
Define Sprint 2 backlog with full user stories and acceptance criteria
Design the Wave Manager system (flowchart + pseudocode)
Begin implementation of WaveManager.cs
Current problems and barriers:
Uncertain how to synchronise wave completion detection with enemy count — need to track a "living enemy" counter that decrements on death or endpoint reach
Need to decide whether to use Unity Coroutines or Update() loop for wave timing — Coroutines selected for cleaner async flow
Analysis: Sprint 1 provided a stable base. The primary complexity in Sprint 2 is coordination between multiple systems (waves, health, score, currency) — a centralised GameManager pattern will be used to reduce coupling.
---
Meeting 2 — Wave Manager & Enemy Health
Date: Week 8
What was done since last meeting:
WaveManager.cs drafted and tested with 3 waves
Enemy.cs updated with TakeDamage() and health variable
Discovered that enemy destruction via tower range check (Sprint 1) bypasses health — refactored tower to call TakeDamage() instead of Destroy()
What is planned for this session:
Implement PlayerHealth.cs and link to endpoint trigger
Begin ScoreManager.cs
Update UIManager.cs with wave counter
Current problems and barriers:
Enemy destruction was previously handled by the Tower script calling Destroy() directly — this needed refactoring to route through Enemy.TakeDamage() so health, score, and coin logic triggers correctly
Fix: Tower.cs now calls `enemy.TakeDamage(damage)` rather than `Destroy(enemy.gameObject)`
Design note: Refactoring the destruction path improved cohesion — each class now manages its own destruction rather than having Tower manage Enemy lifecycle.
---
Meeting 3 — Health, Score, Currency
Date: Week 9
What was done since last meeting:
PlayerHealth.cs implemented and tested (10 health, deducted when enemy reaches endpoint)
ScoreManager.cs implemented (+10 per kill, displays in UI)
CurrencyManager.cs implemented (start 100, +15 per kill, -50 per tower placed)
What is planned for this session:
Implement TowerPlacer.cs (mouse-click placement)
Create UI Canvas with HUD layout
Link all managers to UIManager.cs
Current problems and barriers:
Raycast grid detection for tower placement required a dedicated "PlacementTile" layer to distinguish path tiles from valid grass tiles
Initially, towers could be stacked on the same tile — added a tile occupancy check using a Dictionary<Vector2Int, bool>
---
Meeting 4 — Tower Placement & UI
Date: Week 10
What was done since last meeting:
TowerPlacer.cs completed with ghost preview (green/red) and coin deduction
UI Canvas created with health, score, wave, and coin counters
UIManager.cs links all four counters and Game Over panel
What is planned for this session:
Full end-to-end playthrough testing
Game Over and restart functionality
Final code cleanup and commenting
Current problems and barriers:
Game Over panel initially appeared mid-wave rather than after the final enemy was processed — fixed by deferring the Game Over check to the end of the enemy's OnReachEndpoint() method
UI text flickering observed at high frame rates — resolved by only updating UI on value change (event-driven) rather than every frame
---
Meeting 5 — Testing & Final Review
Date: Week 11
What was done since last meeting:
End-to-end testing completed across 5 waves
Restart and Game Over tested and confirmed working
All code commented and README updated
What is planned for this session:
Final backlog review — confirm all items marked complete
Push final commit to GitHub
Prepare project report and video vignette
Current problems and barriers:
Wave 5 produced a minor frame rate drop with 15 enemies simultaneously active — optimised by limiting active enemy count using an object pool pattern (basic implementation)
No outstanding critical bugs
---
📉 Burndown Chart
Sprint 2 Total Story Points: 30
Sprint Duration: 5 weeks
```
Story Points Remaining:

Week 7  ████████████████████████████████  30 pts (Sprint start)
Week 8  ████████████████████████          24 pts (Wave Manager + Enemy Health complete)
Week 9  █████████████████                 17 pts (Health + Score + Currency complete)
Week 10 ██████████                        10 pts (Tower Placement + UI complete)
Week 11 ████                               4 pts (Game Over + testing)
Week 12 ░                                  0 pts (Sprint complete ✅)

Ideal Burndown:
Week 7:  30 → Week 8: 24 → Week 9: 18 → Week 10: 12 → Week 11: 6 → Week 12: 0
Actual:  30 → 24 → 17 → 10 → 4 → 0

Status: ✅ On track — actual burndown closely follows ideal line
```
---
🧪 Testing Plan & Results
Unit Tests
Test ID	Feature	Input	Expected Output	Result
T01	Wave spawning	Wave 1 triggered	5 enemies spawn at spawnPoint	✅ PASS
T02	Wave progression	All Wave 1 enemies removed	Wave 2 begins after 5s delay	✅ PASS
T03	Enemy count scaling	Wave 3 starts	9 enemies spawn (5 + 2 + 2)	✅ PASS
T04	Player health deduction	Enemy reaches endpoint	Health decreases by 1	✅ PASS
T05	Game Over trigger	Health reaches 0	Game Over panel shown	✅ PASS
T06	Score increment	Tower destroys 1 enemy	Score +10	✅ PASS
T07	Coin earn	Tower destroys 1 enemy	Coins +15	✅ PASS
T08	Tower placement (valid)	Click on grass tile	Tower placed, coins deducted	✅ PASS
T09	Tower placement (invalid)	Click on path tile	Tower not placed, red ghost	✅ PASS
T10	Tower stacking prevention	Click on occupied tile	Tower not placed	✅ PASS
T11	Tower cooldown	1s fire rate, 3s elapsed	Tower attacked 3 times	✅ PASS
T12	TakeDamage routing	Enemy hit by tower	health-- called correctly	✅ PASS
T13	Restart button	Game Over → Restart clicked	Scene reloads, values reset	✅ PASS
T14	UI health update	Health changes	UI counter reflects new value	✅ PASS
T15	UI wave update	Wave increments	UI wave counter updates	✅ PASS
Integration Tests
Test ID	Systems Tested	Scenario	Result
IT01	WaveManager + Enemy	5 waves end-to-end	All waves spawn and complete correctly ✅
IT02	Tower + Enemy + Score	Tower kills enemy	Score and coins both update ✅
IT03	Enemy + PlayerHealth + UI	Enemy reaches endpoint	Health deducted, UI updates ✅
IT04	TowerPlacer + Currency	Place tower	Coins deducted correctly ✅
IT05	Full game loop	Play through to Game Over	All systems interact correctly ✅
---
🛠️ Tools & Techniques
Tool / Technique	Purpose
Unity 2022 LTS	Game engine — scene, physics, rendering
C#	Scripting all game behaviour
Visual Studio Code	Code editing with IntelliSense
GitHub	Version control — commits at each feature milestone
Unity Inspector	Exposing configurable variables (fireRate, damage, health)
Unity Coroutines	Asynchronous wave delay timing
Event-driven UI updates	UIManager subscribes to events rather than polling
Object Pooling (basic)	Reuse enemy GameObjects for performance optimisation
Scrum Backlog	Sprint planning, story points, acceptance criteria
Burndown Chart	Sprint progress tracking
---
💻 Code Documentation
New Scripts (Sprint 2)
Script	Responsibility	Key Methods
`WaveManager.cs`	Spawn and sequence enemy waves	`StartGame()`, `SpawnWave()`, `WaveComplete()`
`PlayerHealth.cs`	Track player HP and trigger Game Over	`TakeDamage()`, `GameOver()`
`ScoreManager.cs`	Track and display score	`AddScore(int)`, `ResetScore()`
`CurrencyManager.cs`	Track coins, validate placement cost	`AddCoins(int)`, `SpendCoins(int)`, `CanAfford(int)`
`TowerPlacer.cs`	Handle mouse-click tower placement	`Update()`, `PlaceTower()`, `IsValidTile()`
`UIManager.cs`	Update all HUD elements	`UpdateHealth()`, `UpdateScore()`, `UpdateCoins()`, `ShowGameOver()`
`GameOverManager.cs`	Handle restart and main menu	`RestartGame()`, `MainMenu()`
Updated Scripts (Sprint 2)
Script	Change	Reason
`Tower.cs`	Added `damage`, `fireRate`, `fireCooldown`	Enable configurable, timed attacks
`Enemy.cs`	Added `health`, `TakeDamage()`	Route destruction through health system
---
🔮 Sprint 2 Summary & Next Steps
Sprint 2 Achievements
Delivered all 8 backlog items (30 story points)
Implemented a full gameplay loop: spawn → defend → wave complete → game over
Introduced resource management through the coin/currency system
UI provides clear real-time feedback to the player
All 15 unit tests and 5 integration tests passed
Planned Sprint 3 Features (if applicable)
Multiple tower types (Slow Tower, Sniper Tower, Splash Tower)
Enemy variety (Fast Enemy, Tank Enemy)
Map editor / multiple levels
Sound effects and visual particle effects
High score persistence (PlayerPrefs or file I/O)
---
README last updated: April 2026 | Garden Guardians Sprint 2

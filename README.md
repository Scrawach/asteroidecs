# Asteroidecs
A simple example of [asteroids game](https://en.wikipedia.org/wiki/Asteroids_(video_game)) using Entity Component System implementation by [LeoEcs Lite](https://github.com/Leopotam/ecslite) for gameplay logic and Unity Engine for rendering, physics, resource management and other.

# Gameplay

<p align="center">
  <img width="600" src="doc/gameplay.gif" alt="Gameplay">
</p>

## How to play
This is an endless game, the objective is to destroy asteroids and aliens and earn points for it. Any collision with an asteroid or an alien ends in defeat, after which the game ends. After that, the game can be started from the beginning with zero points.

### Difficulty
The game has only one difficulty. However, it can be configured in the [json file settings](/src/Asteroidecs/Assets/Prefabs/Settings/Config.json): change player spaceship stats, increase or decrease spawn time of asteroids and aliens, and their stats - movement speed, health and destruction bonus.

### Control
- **WASD** - spaceship movement direction.
- **Mouse Position** - spaceship firing direction.
- **Left Click** - a simple laser that is destroyed when it collides with something. 
- **Right Click** - a red laser that is not destroyed by asteroid collisions, but aliens can destroy it.

All control logic is encapsulated in a class [UnityInput](/src/Asteroidecs/Assets/CodeBase/Engine/Services/UnityInput.cs).

# Architecture
An important issue is how the core logic communicates with the engine's external logic. Dependency inversion uses interfaces within the core assembly referenced by the engine assembly. ECS dictates a flat architecture, where there is nothing special to highlight. For ease of navigation - [components](/src/Asteroidecs/Assets/CodeBase/Core/Gameplay/Components) and [systems](/src/Asteroidecs/Assets/CodeBase/Core/Gameplay/Systems) are divided into appropriate directories. Game Engine (Unity) interacts with ECS core via [MonoLinks](/src/Asteroidecs/Assets/CodeBase/Engine/MonoLinks/Base/MonoLinkBase.cs).

## Entry Point
The game starts without an initial scene, resource management uses Addressables to load resources from the prefab folder. The game is constructed at the [entry point](/src/Asteroidecs/Assets/CodeBase/EntryPoint.cs).

## Diagram
<p align="center">
  <img width="600" src="doc/arch.svg" alt="Flat Architecture">
</p>

# Screenshots
<p align="center">
  <img width="600" src="doc/screen_0.png" alt="Gameplay">
  <img width="600" src="doc/screen_1.png" alt="Gameplay">
</p>


# TikTakToe

[![GitHub tag](https://img.shields.io/github/tag/anakwaboe4/TikTakToe?include_prereleases=&sort=semver&color=blue)](https://github.com/anakwaboe4/TikTakToe/releases/)
[![License](https://img.shields.io/badge/License-GPLv3.0-blue)](#license)

## play

the engine is played with the numpad. it is very self explaining.

![The TikTakToe gameplay](/images/tiktaktoeplay.png)

- first the egine ask my to play or type 0 to let it move.
- I play on square 5
- My move is on the board
- The engine answers 
- The engine give back his evaluation (0 = draw, 1 = X is winning, -1 = O is winning)

**good luck**
## menu 

If you type **100** you enter the menu.

 ![The TikTakToe menu](/images/tiktaktoemenu.png)

 - option 1: is to start a new game
 - option 2: is to change the AI to the AIMulti.cs class, this is the ai of v1.1. (I don't clear the transpo table between moves so i would think of this as a cheat)
 - option 2: can also be to change it back
 - option 3: benches the transpo ai with a blank board and after 2 moves.
 - option 4: benches multithreated ai with a blank board
 - option 5: benches singlethreated ai with a blank board
 - option 6: runs a full benchmarking suite with:
	- multi to warm up the cores
	- all the ai from a startup config and a blank board
	- all the ai with a second move
	- the ai's (running) from startup
- option 7: hidden option that benches multithreated transpo ai (this one was a fail because it is slower then single thread transpo)

## !! happy now BinaryPilot !!
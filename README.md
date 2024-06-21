# Clue-Analyzer

## Why

Why a program to help you play a game? I built Clue Analyzer because I personally struggle with the deductive reasoning required for Clue, not because it is too complicated, but because it is easy to mess up. It helps with the deductive reasoning process required for a game of Clue and makes a otherwise torturous game fun. Now I can actually compete without getting stressed out. This program shouldn't be considered cheating, because it does the same deductive reasoning a person could do manually.

This project took 60+ hours to create, between building UI, programming, testing and debugging. I learned a lot about object oriented programming and some of the principles behind it.

Note: This program was primarily developed locally, so any version prior to V1.1.1 is not available in GitHub.

## Features

### Analysis
- Counts cards and analyzes guesses to determine 
- Automatically determines which cards are in the secret envelope
- Automatically determines which cards each players have, and which they don't have
- Alerts you when it figures something out, whether it is a murder detail or something about a player. For example: "John has the rope."

### Guesses
- Allows editing guesses later in the game in case mistakes were made, which is not something very easy with pen and paper. This program will reanalyze everything so you don't have to
- Allows you to hover over the list of guesses to view who has that specific card, or whether that card is one of the murder details.

### Players
- Allows you to view each player individually and view the following information
    1. The number of guesses they have made
    2. The number of guesses that have included this player (for example if the player showed a card to the guessing player)
    3. The number of cards they have and how many of them you know 

### Other
- Allows you to select a set of cards that match your game
- Keeps track of the number of guesses and discoveries (the number of things found out by the program)
- A way to see all the cards out there and where they are at. Additionally it allows you to see who may or may not have those cards by hovering over them.


## Installation / Updating notes

### Installing note
- The installers are NOT signed. This is because I do not feel like purchasing a $100/year certificate for a personal project. This caveat means that Windows will most likely display an untrusted publisher warning screen. This can be bypassed by doing Advanced -> Install anyway on the warning screen.

### Updating note
- This installer works the best if you uninstall any previous versions before installing this version. You can figure out what version the application is running by navigating Help -> About in the application menu (only when a game is open)


## CREDITS: 

Check, X, and -, and reload icons were obtained from https://fonts.google.com/icons

Clue Analyzer was made by Joshua Stahl for his Final project for his C# Level 2 class CIS262AD at South Mountain Community College.
His professor was Stephen Hustedde.
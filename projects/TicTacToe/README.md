# Windows Forms Tic-Tac-Toe Game

## Overview
This is a Windows Forms (or WPF) application that allows two players to play Tic-Tac-Toe.  
The game includes:
- A playable **Tic-Tac-Toe board** where users can click to make their moves.
- A **Game Status section** that displays whose turn it is.
- A system that **detects a winner** or a tie and updates the game status accordingly.
- A visual indication of the **winning move** when a player wins.
- A **score tracker** that records:
  - The number of wins for each player.
  - The number of ties.
- A **"Start Game" button** that resets the game board and allows a new game to begin.

---

## Features
- **Turn-based gameplay** where each player takes turns making a move.
- **Game logic validation** to check for:
  - A winner (three marks in a row, column, or diagonal).
  - A tie (no empty spaces left).
  - Ongoing gameplay (game is still in progress).
- **Highlighting of the winning move** when a player wins.
- **Score tracking** for both players and ties.
- **Reset functionality** using the "Start Game" button.
- **Object-oriented design**:
  - A separate class to handle game logic.
  - The class includes an array representing the game board.
  - Methods to check for a winner, a tie, or an ongoing game.

---

## Technologies Used
- C#
- Windows Forms (WinForms) / WPF
- .NET Framework

---

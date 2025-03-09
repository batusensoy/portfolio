# WPF Math Game for Kids

## Overview
This is an interactive **math game** designed for young children, built using **WPF**.  
The game features:
- A **themed interface** with images and sounds suitable for children.
- Three windows:  
  1. **Main Menu Window** – User enters their information and selects a game type.  
  2. **Game Window** – Displays math questions, tracks time, and provides feedback.  
  3. **Final Score Window** – Shows game results and high scores.  
- A **high score system** that keeps track of the top 10 scores.

---

## Features

### **Main Menu Window**
- User enters their **name and age**.
- Age must be **between 3 and 10**.
- User selects a **game type**:
  - Addition
  - Subtraction
  - Multiplication
  - Division
- **Validation system**:
  - If the name is empty, an error message appears.
  - If age is not between **3 and 10**, an error message appears.
  - If no game type is selected, an error message appears.
- A **"Begin Game" button** to start the game if all inputs are valid.

### **Game Window**
- **10 randomly generated math questions** based on the selected game type.
- Numbers are randomly generated between **1 and 10**.
- A **timer** tracks how long the player takes to answer all questions.
- Users can:
  - Enter their answer in a text box.
  - Click **"Submit"** or press **Enter** to check their answer.
- **Immediate feedback**:
  - A message tells the user if their answer is correct or incorrect.
- The next question appears after each answer.
- The game ends after **10 questions**.

### **Final Score Window**
- Displays:
  - **User’s name and age**.
  - **Number of correct and incorrect answers**.
  - **Total time taken** to complete the game.
- Users can **return to the main menu** to start a new game.

### **High Score Feature**
- The **top 10 scores** are stored and displayed.
- A **Scores class** manages high scores.
- High scores are sorted based on:
  1. **Number of correct answers**.
  2. **Fastest completion time** (in case of a tie).
- Players are notified if they made it onto the **top 10 high scores list**.
- The high score screen allows players to return to the **main menu**.

---

## Technologies Used
- **C#**
- **WPF (Windows Presentation Foundation)**
- **.NET Framework**
- **Object-Oriented Programming (OOP)** (with a Scores class for high scores)

---

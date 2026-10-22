# "4 in a Row" – Windows Forms Desktop Game 🎮

A dynamic, event-driven desktop implementation of the classic "Connect Four" game built with C# and Windows Forms (.NET Framework).

The application features a clean user interface that dynamically builds the game board according to customized player settings, supporting both local multiplayer and player-vs-computer gameplay.

## 🌟 Key Features
- **Dynamic Board Sizing:** Configurable game board dimensions (from 4x4 up to 10x10) selected via pre-game settings, with the main form scaling its layout dynamically at runtime.
- **Multiple Game Modes:**
  - **Player vs. Player:** Local two-player turn-based mode.
  - **Player vs. Computer:** Solo mode against an automated computer opponent.
- **Event-Driven UI:**
  - Runtime button array generation and layout calculation.
  - Dynamic button disabling upon column capacity overflow.
  - Interactive win/tie notifications and state resets using `MessageBox`.
- **Decoupled Architecture:** Business logic and board state management remain separate from visual control updates and event handlers.

## 🛠️ Tech Stack
- **Language & Runtime:** C#, .NET Framework
- **UI Framework:** Windows Forms (WinForms)
- **Concepts:** Event-driven programming, Dynamic UI rendering, State management, Object-Oriented Programming (OOP)

## 📁 Project Structure
- `GameSettingsForm.cs` - Dialog form capturing player names, opponent mode, and board dimensions.
- `GameBoardForm.cs` - Interactive game board generating dynamic matrix controls and handling gameplay events.
- `GameLogic/` - Internal state validation, move verification, win detection, and AI moves.

## 🚀 Getting Started
1. Clone the repository:
   ```bash
   git clone [https://github.com/NoaGeta/connect-four-winforms-game.git](https://github.com/NoaGeta/connect-four-winforms-game.git)

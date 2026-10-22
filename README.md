# "4 in a Row" – Unified Desktop & Console Edition 🎮

A complete C# implementation of the classic "Connect Four" game, built with a strictly decoupled architecture where a core game engine powers both a terminal interface and a dynamic Windows Forms desktop application[cite: 30, 33, 35].

## 🌟 Key Features
- **Shared Decoupled Engine:** The game rules, board matrix evaluation, and win/tie detectors are isolated in a core logic layer, independent of any UI framework[cite: 35].
- **Dynamic Board Sizing:** Supports custom dimensions from 4x4 up to 10x10 (with non-square dimensions supported in terminal mode)[cite: 30, 34].
- **Dual Presentation Layers:**
  - **Windows Forms (Desktop UI):** Dynamically scales controls at runtime, binds column-drop events, and disables full columns automatically[cite: 30, 31, 32].
  - **Console UI:** Clean terminal board drawing with fast screen refreshes and defensive input sanitization[cite: 34, 35].
- **Gameplay Modes:** Supports two-player hotseat and single-player vs. computer opponent modes.

## 🛠️ Tech Stack
- **Language & Runtime:** C#, .NET Framework[cite: 30, 33]
- **UI Frameworks:** Windows Forms (WinForms), System.Console[cite: 30, 35]
- **Patterns & Concepts:** Layered Architecture, Event-Driven Programming, State Machines, Multidimensional Matrices[cite: 30, 32, 33, 35]

## 📁 Solution Architecture
- `GameLogic/` - Shared business logic and state management[cite: 35].
- `DesktopUI/` - Windows Forms application and event handlers[cite: 30, 32].
- `ConsoleUI/` - Terminal-based interface and command loops[cite: 34, 35].

## 🚀 Getting Started
1. Clone the repository:
   ```bash
   git clone [https://github.com/NoaGeta/connect-four-game.git](https://github.com/NoaGeta/connect-four-game.git)

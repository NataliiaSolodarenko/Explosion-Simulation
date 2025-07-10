# Explosion-Simulation

<h3><b>📌 About the Project</b></h3>

Explosion Simulation is a Windows Forms (WinForms) application written in C#. It simulates the radial propagation of an explosion from a user-defined origin point and visually demonstrates how obstacles block the explosion spread.
This application was created as part of coursework during the first year of studying C#, and showcases progress in working with visual rendering, collision logic, and form-based interface design.

<h3><b>🧩 Key Features</b></h3>

* Place Explosion Origin: Manually choose a point where the explosion starts.
* Draw Obstacles: Use mouse interactions to place lines representing obstacles that block the explosion.
* Animated Explosion Spread: The explosion visually propagates in real-time using a timer.
* Obstacle Analysis: Automatically detects obstacles that are irrelevant (e.g., pass through the origin or are out of range) and prompts the user to remove them.
* Cursor Labels: Tooltips appear on hover over the cursor, explosion origin, and obstacles.
* Simulation Controls:
    * Start / Pause simulation
    * Change explosion speed (3 levels)
    * Reset all elements

<h3><b>💡 Technologies Used</b></h3>

* C# (.NET Framework)
* Windows Forms (WinForms)
* System.Drawing for 2D rendering
* Timers, Events, MessageBox dialogs, Array manipulations

<h3><b>🗃 Project Structure</b></h3>

* Form1.cs: Main application logic including GUI, rendering, and simulation engine.
* Program.cs: Entry point of the application.
* Resources: Contains icons for play/pause and speed visuals.

<h3><b>📖 How It Works</b></h3>

1. Mode Selection: Choose between placing a cursor, explosion origin, or drawing obstacles.
2. Interaction: Click on the canvas to place the element.
3. Run Simulation: Explosion lines propagate from the origin and are visually clipped by obstacles.
4. Optional Cleanup: Simulation warns about and lets you remove unnecessary obstacles.

<h3><b>🚀 Getting Started</b></h3>

1. Clone the repository or download the code.
2. Open the solution in Visual Studio.
3. Run the application and interact with the interface.

<h3><b>📌 Notes</b></h3>

* This was developed as part of coursework and demonstrates foundational GUI and algorithmic skills.
* The project UI is in English

<h3><b>📬 Contact</b></h3>

Feel free to reach out for questions or collaborations:
* Developer: Nataliia  Solodarenko
* LinkedIn: https://www.linkedin.com/in/nataliia-solodarenko-5272b0305/
* Email: nataliiasolodarenko@gmail.com

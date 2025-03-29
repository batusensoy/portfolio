# Airline Reservation System (WPF - C#)

## Overview
The **Airline Reservation System** is a Windows Presentation Foundation (**WPF**) application developed in **C#** that allows users to select flights, manage passengers, and modify seating arrangements through an interactive graphical user interface (**GUI**). The program retrieves flight and passenger data from a **SQL database**, showcasing database integration and dynamic UI updates.

## Key Functionalities
**Flight Selection:**
- Users can choose between different flights, each with a **unique seating arrangement** displayed graphically.
- The **“Choose Flight”** combo box is populated dynamically from the database.
- When a flight is selected, the corresponding seat layout is displayed, and the **passenger list** is updated accordingly.

**Graphical Seat Representation:**
- The seating arrangement for each flight is displayed using **WPF controls (Canvas, Labels, etc.).**
- Each seat is visually represented, making it easy to identify occupied and available seats.

**Passenger Management:**
- Users can **add a new passenger** by opening a separate form.
- The form allows input of **first and last names**, with **Save** and **Cancel** buttons.

**Seat Modification & Reservation Management:**
- Passengers can **change seats** within the selected flight.
- Users can **delete a passenger** from the reservation system if needed.

## Technologies Used
- **C#** – Core programming language
- **WPF (Windows Presentation Foundation)** – GUI development
- **.NET Framework** – Application runtime
- **SQL Server** – Data storage and retrieval
- **Visual Studio** – Development environment